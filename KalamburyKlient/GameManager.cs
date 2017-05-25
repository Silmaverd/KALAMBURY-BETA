using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburyKlient
{
    class GameManager
    {
        private GameServer gameServer;          // INSTANCJA SERWERA GRY
        private ListBox activePlayers;          // LISTA USERNAME AKTYWNYCH GRACZY 
        private ListBox activeGameRooms;        // LISTA NAZW AKTYWNYCH POKOI GRY
        private Thread serverListeningThread;   // WĄTEK NASŁUCHUJĄCY NA KOMUNIKACJĘ Z SERWEREM
        private GameWindow gameWindow;          // GLOWNE OKNO GRY, TUTAJ RYSUJEMY ORAZ ODGANUJEMY HASŁA
        private Thread gameThread;              // WATEK W KTÓRYM gameWindow JEST OBSŁUGIWANE

        private string userName;
        private string roomName;

        public bool Disconnected = false;

        private string [] _userNames;
        private string [] _roomNames;

        private Coordinate[] roomCoordinates;

        public GameManager(ListBox users, ListBox rooms)
        {
            this.gameServer = new GameServer();
            this.activeGameRooms = rooms;
            this.activePlayers = users;
            this.gameThread = new Thread(this.StartGame);
        }

        // INICJALIZACJA POŁĄCZENIA Z SERWEREM
        public void Connect(string userName, string ipAddress, int port)
        {
            this.gameServer.Connect(userName,ipAddress,port);
            this.serverListeningThread = new Thread(this.ListenToServerMessages);
            this.serverListeningThread.Start();
        }

        public void Disconnect()
        {
            this.gameServer.Disconnect();
        }

        // REQUEST DO SERWERA O STWORZENIE POKOJU GRY
        public void CreateRoom()
        {
            if (!this.gameServer.Connected())
                return;
            RoomCreationWindow roomCreatingWindow = new RoomCreationWindow();
            roomCreatingWindow.ShowDialog();
            this.gameServer.SendMessage("ROOM_CREATE:" + roomCreatingWindow.ROOM_NAME+":"+ roomCreatingWindow.TIMER_VALUE);
            this.SetGameRoomName(roomCreatingWindow.ROOM_NAME);
        }

        // PROŚBA O DOŁĄCZENIE DO ISTNIEJĄCEGO POKOJU
        public void JoinRoom(string RoomName)
        {
            if (!this.gameServer.Connected())
                return;
            this.SetGameRoomName(RoomName.Substring(0,RoomName.IndexOf('(')));
            this.gameServer.SendMessage("ROOM_JOIN:" + this.roomName);
        }

        // PROŚBA O WYJŚCIE Z POKOJU
        public void ExitFromGameRoom()
        {
            if (!this.gameServer.Connected())
                return;
            this.gameServer.SendMessage("ROOM_EXIT");
        }
        // METODA AKTUALIZUJĄCA LISTĘ USERNAME AKTYWNYCH UŻYTKOWNIKÓW
        public void UpdateUsers()
        {
            if (this.activePlayers.InvokeRequired)
            {
                this.activePlayers.Invoke(new Action(UpdateUsers));
            }else
            {
                this.activePlayers.Items.Clear();
                for(int i = 1; i < this._userNames.Length; i++)
                    this.activePlayers.Items.Add(this._userNames[i]);
            }
        }
        // METODA AKTUALIZUJĄCA LISTĘ ROOMNAME ISTNIEJĄCYCH POKOI
        public void UpdateRooms()
        {
            if (this.activeGameRooms.InvokeRequired)
            {
                this.activeGameRooms.Invoke(new Action(UpdateRooms));
            }
            else
            {
                this.activeGameRooms.Items.Clear();
                for (int i = 1; i < this._roomNames.Length; i++)
                    this.activeGameRooms.Items.Add(this._roomNames[i]);
            }
        }
        // METODA NASŁUCHUJĄCA NA WIADOMOŚCI OD SERWERA
        public void ListenToServerMessages()
        {
            while (true)
            {
                if (!this.gameServer.Connected())
                    break;
                if (!this.gameServer.DataAvalibleToRecieve())
                {
                    Thread.Sleep(50);
                    continue;
                }
                string RAW_COMMAND = this.gameServer.RecieveMessage();
                // PODZIEL OTRZYMANY ZESTAW KOMEND WZGLĘDEM ZNAKU ';'
                string[] ALL_COMMANDS = this.GetAllCommandsFromRaw(RAW_COMMAND);
                // DLA KAZDEJ Z KOMEND WYDOBĄDŹ POLECENIE ORAZ PARAMETRY PO ZNAKU ':'
                foreach(string PENDING_COMMAND in ALL_COMMANDS)
                {
                    string[] COMMAND = this.ConvertToProperCommandForm(PENDING_COMMAND);
                    // ORAZ KAZDA Z OSOBNA ZIN TERPRETUJ
                    this.InterpeteCommand(COMMAND);
                }
            }
        }

        private string [] GetAllCommandsFromRaw(string RAW_COMMAND)
        {
            string COMMAND;
            try
            {
                COMMAND = RAW_COMMAND.Substring(0, RAW_COMMAND.IndexOf('\0'));
                return COMMAND.Split(';');
            }
            catch (ArgumentOutOfRangeException)
            {
                COMMAND = RAW_COMMAND.Substring(0, RAW_COMMAND.Length);
            }
            return COMMAND.Split(';');
        }
        private string [] ConvertToProperCommandForm(string COMMAND_RAW)
        {
            return COMMAND_RAW.Split(':');
        }

        // METODA INTERPRETUJĄCA OTRZYMANE OD SERWERA KOMENDY
        private void InterpeteCommand(string [] COMMAND)
        {
            string commandHeader = COMMAND[0];

            if (commandHeader.Equals("USER_DISCONNECTED"))
            {
                string disconnectionReason = COMMAND[1];
                MessageBox.Show("Rozłączenie z serwerem!\nPowód: \n" + disconnectionReason);
                this.Disconnected = true;
                this.Disconnect();
            }
            if (commandHeader.Equals("ROOM_USERS_UPDATE"))
            {
                if(gameWindow!= null)
                    this.gameWindow.UpdateGameRoomUsers(COMMAND);
            }
            if(commandHeader.Equals("CHAT_MESSAGE"))
            {
                this.UpdateChatRoom(COMMAND[1]);
            }
            if (commandHeader.Equals("PRIVATE_CHAT_MESSAGE"))
            {
                if (gameWindow != null)
                    this.gameWindow.handlePrivateChatMessage(COMMAND);
            }
            // OTRZYMANO KOORDYNATY DO NARYSOWANIA
            if (commandHeader.Equals("COORDINATE"))
            {
                StringBuilder coordinates = new StringBuilder();
                // OD 2 BO [0]->COORDINATE, [1]->COLOR
                for(int i = 2; i < COMMAND.Length; i++) {
                    coordinates.Append(COMMAND[i] + ":");
                }
                this.UpdateCoordinates(coordinates.ToString(),COMMAND[1]);
            }
            if (commandHeader.Equals("ROOM_CREATION_OK"))
            {
                this.gameThread = new Thread(this.StartGame);
                this.gameThread.Start();
            }
            if (commandHeader.Equals("ROOM_CREATION_FAILED"))
            {
                string reason = COMMAND[1];
                MessageBox.Show("Nie udało się utworzyć pokoju gry.\nPowód:\n" + reason);
            }
            if (commandHeader.Equals("ROOM_JOIN_OK"))
            {
                this.gameThread = new Thread(this.StartGame);
                this.gameThread.Start();
            }
            if (commandHeader.Equals("ROOM_JOIN_FAILED"))
            {
                string reason = COMMAND[1];
                MessageBox.Show("Nie udało się dołączyć do pokoju gry.\nPowód:\n" + reason);
            }
            if (commandHeader.Equals("USERS_UPDATE"))
            {
                this._userNames = COMMAND;
                this.UpdateUsers();   
            }
            // OTRZYMANO CATCHWORD
            if (commandHeader.Equals("CATCHWORD"))
            {
                string CATCHWORD = COMMAND[1];
                this.gameWindow.SetCatchWord(CATCHWORD);
            }
            if (commandHeader.Equals("ROOMS_UPDATE"))
            {
                this._roomNames = COMMAND;
                this.UpdateRooms();
            }
            // OTRZYMANO INFORMACJE O BYCIU ADMINEM
            if (commandHeader.Equals("ROOM_ADMIN"))
            {
                this.gameWindow.BeRoomAdmin();
                this.gameWindow.ClearCatchWord();
            }
            // OTRZYMANO INFORMACJE O BYCIU ZGADUJĄCYM
            if (commandHeader.Equals("ROOM_USER"))
            {
                this.gameWindow.BeNormalUser();
                this.gameWindow.ClearCatchWord();
            }
            if (commandHeader.Equals("DESK_CLEAR"))
            {
                this.gameWindow.ClearDesk();
            }
            if (commandHeader.Equals("TIMER_UPDATE"))
            {
                this.gameWindow.timerUpdate(COMMAND[1]);
            }
        }

        private void UpdateChatRoom(string message)
        {
            this.gameWindow.UpdateChatRoom(message);
        }

        private void UpdateCoordinates(string coordinates, string COLOR)
        {
            this.gameWindow.DrawCoordinates(coordinates.Split(':'),COLOR);
        }
        // METODA WŁĄCZAJĄCA GAMEROOM ORAZ ROZPOCZYNAJĄCA ROZGRYWKĘ
        private void StartGame()
        {
            this.gameWindow = new GameWindow(this.userName, this.roomName);
            this.gameWindow.SetServer(this.gameServer);
            this.gameWindow.ShowDialog();
        }
        // ZAMYKANIE DZIAŁAJĄCYCH WĄTKÓW
        public void StopListening()
        {
            if (this.serverListeningThread.IsAlive)
                this.serverListeningThread.Abort();
            if (this.gameThread.IsAlive)
                this.gameThread.Abort();
        }

        public void SetUserName(string userName)
        {
            this.userName = userName;
        }

        public void SetGameRoomName(string roomName)
        {
            this.roomName = roomName;
        }
    }
}
