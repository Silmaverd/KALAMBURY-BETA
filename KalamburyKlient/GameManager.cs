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
        private ListBox activePlayersList;      // LISTA USERNAME AKTYWNYCH GRACZY 
        private ListBox activeGameRoomsList;    // LISTA NAZW AKTYWNYCH POKOI GRY
        private Thread serverListeningThread;   // WĄTEK NASŁUCHUJĄCY NA KOMUNIKACJĘ Z SERWEREM
        private GameWindow gameWindow;          // GLOWNE OKNO GRY, TUTAJ RYSUJEMY ORAZ ODGANUJEMY HASŁA
        private Thread gameThread;              // WATEK W KTÓRYM gameWindow JEST OBSŁUGIWANE

        private string userName;
        private string roomName;

        public bool Disconnected = false;

        private string [] _userNames;
        private string [] _roomNames;

        public GameManager(ListBox users, ListBox rooms)
        {
            this.gameServer = new GameServer();
            this.activeGameRoomsList = rooms;
            this.activePlayersList = users;
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
            if (this.activePlayersList.InvokeRequired)
            {
                this.activePlayersList.Invoke(new Action(UpdateUsers));
            }else
            {
                this.activePlayersList.Items.Clear();
                for(int i = 1; i < this._userNames.Length; i++)
                    this.activePlayersList.Items.Add(this._userNames[i]);
            }
        }
        // METODA AKTUALIZUJĄCA LISTĘ ROOMNAME ISTNIEJĄCYCH POKOI
        public void UpdateRooms()
        {
            if (this.activeGameRoomsList.InvokeRequired)
            {
                this.activeGameRoomsList.Invoke(new Action(UpdateRooms));
            }
            else
            {
                this.activeGameRoomsList.Items.Clear();
                for (int i = 1; i < this._roomNames.Length; i++)
                    this.activeGameRoomsList.Items.Add(this._roomNames[i]);
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

            switch (commandHeader)
            {
                case "USER_DISCONNECTED":
                    string disconnectionReason = COMMAND[1];
                    MessageBox.Show("Rozłączenie z serwerem!\nPowód: \n" + disconnectionReason);
                    this.Disconnected = true;
                    this.Disconnect();
                    break;

                case "ROOM_USERS_UPDATE":
                    if (gameWindow != null)
                        this.gameWindow.UpdateGameRoomUsers(COMMAND);
                    break;

                case "CHAT_MESSAGE":
                    this.UpdateChatRoom(COMMAND[1]);
                    break;

                case "PRIVATE_CHAT_MESSAGE":
                    if (gameWindow != null)
                        this.gameWindow.handlePrivateChatMessage(COMMAND);
                    break;

                case "COORDINATE":
                    StringBuilder coordinates = new StringBuilder();
                    // OD 2 BO [0]->COORDINATE, [1]->COLOR
                    for (int i = 2; i < COMMAND.Length; i++)
                    {
                        coordinates.Append(COMMAND[i] + ":");
                    }
                    this.UpdateCoordinates(coordinates.ToString(), COMMAND[1]);
                    break;

                case "ROOM_CREATION_OK":
                    this.gameThread = new Thread(this.StartGame);
                    this.gameThread.Start();
                    break;

                case "ROOM_CREATION_FAILED":
                    string creationFailedReason = COMMAND[1];
                    MessageBox.Show("Nie udało się utworzyć pokoju gry.\nPowód:\n" + creationFailedReason);
                    break;

                case "ROOM_JOIN_OK":
                    this.gameThread = new Thread(this.StartGame);
                    this.gameThread.Start();
                    break;

                case "ROOM_JOIN_FAILED":
                    string joinFailedReason = COMMAND[1];
                    MessageBox.Show("Nie udało się dołączyć do pokoju gry.\nPowód:\n" + joinFailedReason);
                    break;

                case "USERS_UPDATE":
                    this._userNames = COMMAND;
                    this.UpdateUsers();
                    break;

                case "CATCHWORD":
                    string CATCHWORD = COMMAND[1];
                    this.gameWindow.SetCatchWord(CATCHWORD);
                    break;

                case "ROOMS_UPDATE":
                    this._roomNames = COMMAND;
                    this.UpdateRooms();
                    break;

                case "ROOM_ADMIN":
                    this.gameWindow.BeRoomAdmin();
                    this.gameWindow.ClearCatchWord();
                    break;

                case "ROOM_USER":
                    this.gameWindow.BeNormalUser();
                    this.gameWindow.ClearCatchWord();
                    break;

                case "DESK_CLEAR":
                    this.gameWindow.ClearDesk();
                    break;

                case "TIMER_UPDATE":
                    this.gameWindow.timerUpdate(COMMAND[1]);
                    break;
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
