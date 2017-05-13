using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburySerwer
{
    class ClientManager
    {
        private List<int> _reservedClientIDs;       // LISTA ZAREZERWOWANYCH ID'S DLA KLIENTÓW
        private List<int> _reservedRoomIDs;         // LISTA ZARESERWOWANYCH ID,S DLA POKOI GIER
        private List<string> _catchWords;           // LISTA HASEŁ DO WYLOSOWANIA DLA KLIENTÓW
        private List<GameClient> _clients;          // LISTA INSTANCJI KLIENTÓW W SERWERZE
        private List<GameRoom> _rooms;              // LISTA INSTANCJI POKOI W SERWERZE
        private bool _clientsModyfying;             // DO TEJ PORY NIE MAM POJĘCIA PO CO MI TO BYŁO, ALE NIE RUSZAĆ !
        private Thread _commandListenerThread;      // WĄTEK NASŁUCHUJĄCY NA KOMUNKACJĘ KLIENTÓW Z SERWEREM
        private ListBox _activeClients;             // LISTA USERNAME AKTYWNYCH KLIENTÓW
        private ListBox _existingRooms;             // LISTA ROOMNAME ISTNIEJĄCYCH POKOI
        private int _amountOfActiveClients;         // LICZBA AKTUALNIE AKTYWNYCH GRACZY

        public void AddNewClient(Socket clientSocket, string username)
        {
            this.SetClientsModyfyingTrue();
            this._amountOfActiveClients++;
            GameClient newGameClient = new GameClient();
            newGameClient.Connect(clientSocket, this.GetFreeClientID());
            newGameClient.SetUserName(username);
            this._clients.Add(newGameClient);
            this.AddClientUsername(username);
            this.SendUpdateAboutClients();
            this.SendUpdateAboutRooms();
            this.SetClientsModyfyingFalse();
        }
        // METODA LOSUJĄCA NIEZAREZERWOWANE PRZEZ ŻADNEGO KLIENTA ID
        private int GetFreeClientID()
        {
            Random randomID = new Random();
            while (true)
            {
                int newID = randomID.Next(10000) + 1;
                if (!this._reservedClientIDs.Contains(newID))
                {
                    this._reservedClientIDs.Add(newID);
                    return newID;
                }
            }
        }
        // JAK WYŻEJ, TYLKO DLA POKOI
        private int GetFreeRoomID()
        {
            while (true)
            {
                Random randomID = new Random();
                int newID = randomID.Next(10000) + 1;
                if (!this._reservedRoomIDs.Contains(newID))
                {
                    this._reservedRoomIDs.Add(newID);
                    return newID;
                }
            }
        }

        private void AddClientUsername(string username)
        {
            if (this._activeClients.InvokeRequired)
            {
                this._activeClients.Invoke(new Action<string>(AddClientUsername), username);
            }
            else
            {
                this._activeClients.Items.Add(username);
            }
        }
        private void RemoveClientUsername(string username)
        {
            if (this._activeClients.InvokeRequired)
            {
                this._activeClients.Invoke(new Action<string>(RemoveClientUsername), username);
            }
            else this._activeClients.Items.Remove(username);
        }
        // METODA NASŁUCHUJĄCA KOMUNIKACJI KLIENTÓW Z SERWEREM
        public void ListenToClientsMessages()
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < this._clients.Count; i++)
                    {
                        if (this._clientsModyfying)
                            break;
                        GameClient actualGameClient = this._clients.ElementAt(i);
                        if (!actualGameClient.DataAvalible())
                            continue;
                        // POBRANIE KOMENDY Z BUFORA
                        string clientMessage = actualGameClient.RecieveMessage();
                        Command command = new Command();
                        // PRZYPISANIE KOMENDY
                        command.COMMAND = clientMessage;
                        // ORAZ ID UŻYTKOWNIKA, OD KTÓREGO JĄ OTRZYMANO
                        command.ID = actualGameClient.GetID();
                        // INTERPERETACJA 
                        this.InterpretTheCommand(command);
                    }
                }
                catch (Exception e)
                {}
            }
        }
        // JEZELI KTOŚ SIĘ ZALOGOWAŁ, LUB WYLOGOWAŁ TO TA METODA 
        // SLUZY TO WYSŁANIA WSZYSTKIM OBECNYM LISTY AKTYWNYCH GRACZY
        private void SendUpdateAboutClients()
        {
            string Items = String.Empty;
            foreach(Object obj in this._activeClients.Items)
            {
                int userId = this.GetIdByUserName(obj.ToString());
                GameClient client = this.GetGameClientById(userId);
                Items += ":" + obj.ToString() + " - " + client.GetStatus();
            }
            for (int i = 0; i < this._clients.Count; i++)
            {
                GameClient client = this._clients.ElementAt(i);
                client.SendMessage("USERS_UPDATE" + Items+";");
            }
        }
        // JAK WYZEJ TYLKO DLA POKOI
        private void SendUpdateAboutRooms()
        {
            string Items = String.Empty;
            foreach (Object obj in this._existingRooms.Items)
            {
                GameRoom gRoom = this.GetGameRoomByName(obj.ToString());
                string roomStatus = gRoom.STATUS;
                Items += ":" + obj.ToString() + "(" + gRoom.PLAYER_COUNT+")" + " " + roomStatus;

            }

            for (int i = 0; i < this._clients.Count; i++)
            {
                GameClient client = this._clients.ElementAt(i);
                client.SendMessage("ROOMS_UPDATE" + Items+";");
            }
        }
        // TA METODA NATOMIAST AKTUALIZUJE AKTYWNYCH GRACZY, ALE TYLKO DLA DANEGO GAME_ROOM, 
        // W KTÓRYM ZNAJDUJE SIĘ GRACZ
        private void SendRoomUsersUpdate(int RID)
        {
            foreach(GameClient gameClient in this._clients)
            {
                string COMMAND = this.GetGameRoomUsers(RID);
                if (gameClient.GetRoomId().Equals(RID))
                    gameClient.SendMessage(COMMAND);
            }
        }

        private string GetGameRoomUsers(int RID)
        {
            StringBuilder gameRoomUsers = new StringBuilder("ROOM_USERS_UPDATE");
            foreach(GameClient gameClient in this._clients)
            {
                if (gameClient.GetRoomId().Equals(RID))
                    gameRoomUsers.Append(":" + gameClient.GetUserName() + "(" + gameClient.GetScore() + ")");
            }
            gameRoomUsers.Append(";");
            return gameRoomUsers.ToString();
        }
        // KONWERSJA SUROWEJ KONENDY NA TĄ, ROZUMIANĄ PRZEZ INTERPRETER,
        // TAK SAMO JAK W APLIKACJI KLIENCKIEJ, POLECENIE ORAZ PARAMETRY ODSEPAROWANE SĄ ZNAKIEM ":"
        public string [] GetCommandInRightFormat(Command rawCommand) 
        {
            string COMMAND = rawCommand.COMMAND.Substring(0, rawCommand.COMMAND.IndexOf('\0'));
            return COMMAND.Split(':');
        }
        // WYSLIJ USEROWI INFORMACJE O TYM, ŻE JEST ADMINEM
        public void SendAdminInformation(int userId)
        {
            GameClient roomAdmin = this.GetGameClientById(userId);
            roomAdmin.SendMessage("ROOM_ADMIN;");
        }
        // METODA INTERPRETUJĄCA PODANĄ KOMENDĘ
        private void InterpretTheCommand(Command userCommand)
        {
            string []COMMAND = this.GetCommandInRightFormat(userCommand);
            int userId = userCommand.ID;
          
            if (COMMAND[0].Equals("USER_DISCONNECTED"))
            {
                this.DisconnectUserById(userId);
            }

            if (COMMAND[0].Equals("ROOM_CREATE"))
            {
                if (!this.GetGameClientById(userId).GetRoomId().Equals(0))
                {
                    this.SendRoomJoinFailedMessage(userId, "Nie można należeć do kilku pokoi na raz!");
                    return;
                }

                string roomName = COMMAND[1];
                if (this.RoomNameExists(roomName))
                {
                    this.SendRoomCreationFailedMsg(userId, "PODANA NAZWA POKOJU JUŻ ISTNIEJE!");
                }else
                {
                    GameClient client = this.GetGameClientById(userId);
                    client.SetStatus("W grze!");
                    GameRoom newGameRoom = new GameRoom();
                    newGameRoom.NAME = roomName;
                    newGameRoom.ID = this.GetFreeRoomID();
                    newGameRoom.PLAYER_COUNT = 1;
                    newGameRoom.ADMIN_ID = client.GetID();
                    this._rooms.Add(newGameRoom);
                    this.AddNewGameRoomName(newGameRoom.NAME);
                    this.SendRoomAcceptMsgAndInitialize(userId, newGameRoom.ID);
                    Thread.Sleep(1000);
                    this.SendAdminInformation(client.GetID());
                    Thread.Sleep(100);
                    this.SendUpdateAboutRooms();
                    Thread.Sleep(100);
                    this.SendRoomUsersUpdate(newGameRoom.ID);
                    Thread.Sleep(100);
                    this.SendUpdateAboutClients();
                }
            }
            if (COMMAND[0].Equals("ROOM_JOIN"))
            {
                if (!this.GetGameClientById(userId).GetRoomId().Equals(0))
                {
                    this.SendRoomJoinFailedMessage(userId, "Nie można należeć do kilku pokoi na raz!");
                    return;
                }
                string gameRoomName = COMMAND[1];
                if (this.GameRoomExists(gameRoomName))
                { 
                    GameClient gameClient = this.GetGameClientById(userId);
                    GameRoom gameRoom = this.GetGameRoomByName(gameRoomName);
                    if(gameRoom.STATUS.Equals("W GRZE!")) {
                        this.SendRoomJoinFailedMessage(gameClient.GetID(), "W pokoju trwa obecnie rozgrywka!");
                        return;
                    }
                    gameClient.SetStatus("W grze!");
                    gameRoom.PLAYER_COUNT++;
                    gameClient.SetRoomId(gameRoom.ID);
                    this.SendRoomJoinOkMessageAndInitialize(gameClient.GetID(),gameRoom.ID);
                    Thread.Sleep(100);
                    this.SendUpdateAboutRooms();
                    Thread.Sleep(100);
                    this.SendUpdateAboutClients();
                    Thread.Sleep(100);
                    this.SendRoomUsersUpdate(gameRoom.ID);
                }
                else this.SendRoomJoinFailedMessage(userId, "POKÓJ NIE ISTNIEJE!");
            }
            if (COMMAND[0].Equals("ROOM_EXIT"))
            {
                GameClient gameClient = this.GetGameClientById(userId);
                gameClient.ClearScore();
                gameClient.SetStatus("W menu.");
                GameRoom gameRoom = this.GetGameRoomByID(gameClient.GetRoomId());
                int ROOM_ID = gameClient.GetRoomId();
                this._reservedRoomIDs.Remove(ROOM_ID);
                gameClient.SetRoomId(0);
                gameRoom.PLAYER_COUNT--;
                // JEZELI OSOBA OPUSZCZAJĄCA GAMEROOM JEST JEGO ADMINEM
                // TO WYLOSUJ NOWEGO
                if (gameRoom.ADMIN_ID.Equals(gameClient.GetID()))
                {
                    gameRoom.STATUS = "OCZEKUJE";
                    Thread.Sleep(500);
                    this.InitializeNewRoomAdmin(ROOM_ID);
                }
                Thread.Sleep(100);
                this.SendRoomUsersUpdate(gameRoom.ID);
                // JEZELI PO OPUSCZENIU POKOJU LICZBA GRACZY W NIM SPADNIE DO 0
                // TO USUN DANY GAMEROOM
                if (gameRoom.PLAYER_COUNT.Equals(0))
                {
                    this.RemoveGameRoomName(gameRoom.NAME);
                    this._rooms.Remove(gameRoom);          
                }
                Thread.Sleep(100);
                this.SendUpdateAboutRooms();
                Thread.Sleep(100);
                this.SendUpdateAboutClients();
            }

            if (COMMAND[0].Equals("CHAT_MESSAGE"))
            {
                GameClient gameClient = this.GetGameClientById(userId);
                if (gameClient.GetRoomId().Equals(0))
                    return;
                int ROOM_ID = gameClient.GetRoomId();
                string username = gameClient.GetUserName() + " - ";
                this.SendChatMessage(username + COMMAND[1], ROOM_ID);

                GameRoom gameRoom = this.GetGameRoomByID(ROOM_ID);
                if (COMMAND[1].Equals(String.Empty))
                    return;
                if (gameRoom.CATCHWORD.Equals(COMMAND[1]))
                {
                    gameClient.UpdateScore();
                    this.SendChatMessage("ODPOWIEDŹ<colon> " + " - "+ COMMAND[1], gameRoom.ID);
                    Thread.Sleep(200);
                    this.InitializeNewRoomAdmin(gameRoom.ID);
                    gameRoom.CATCHWORD = String.Empty;
                    Thread.Sleep(100);
                    this.SendRoomUsersUpdate(gameRoom.ID);
                    return;
                }

                string[] answerSplitted = COMMAND[1].Split(' ');
                // TO TAK SREDNIO DZIALA
                foreach(string answer in answerSplitted)
                {
                    if(gameRoom.CATCHWORD.Contains(answer) && answer.Length >= 5)
                    {
                        this.SendChatMessage("BLISKO<colon> " + username  + COMMAND[1], gameRoom.ID);
                        return;
                    }
                }
            }
            // ZAPYTANIE O HASŁO
            if (COMMAND[0].Equals("GET_CATCHWORD"))
            {
                GameClient roomAdmin = this.GetGameClientById(userId);
                GameRoom gameRoom = this.GetGameRoomByID(roomAdmin.GetRoomId());
                gameRoom.STATUS = "W GRZE!";
                string CATCHWORD = this.GetRandomCatchWord();
                gameRoom.CATCHWORD = CATCHWORD;
                roomAdmin.SendMessage("CATCHWORD:"+CATCHWORD+";");
                this.SendUpdateAboutRooms();
            }
            if (COMMAND[0].Equals("DESK_CLEAR"))
            {
                GameClient adminClient = this.GetGameClientById(userId);
                int roomId = adminClient.GetRoomId();
                foreach(GameClient gameClient in this._clients)
                {
                    if (gameClient.GetRoomId().Equals(roomId))
                    {
                        gameClient.SendMessage("DESK_CLEAR");
                    }
                }
            }
            // KOORDYNATÓW NIE INTERPRETUJEMY, TYLKO ROZSYŁAMY DO WSZYSTKICH POZOSTAŁYCH W GAMEROOM
            if (COMMAND[0].Equals("COORDINATE"))
            {
                GameClient adminClient = this.GetGameClientById(userId);
                int roomId = adminClient.GetRoomId();

                StringBuilder command = new StringBuilder("COORDINATE:");
                for(int i = 1; i < COMMAND.Length; i++)
                {
                    command.Append(COMMAND[i] + ":");
                }
                foreach (GameClient gameClient in this._clients)
                {
                    if (gameClient.GetRoomId().Equals(roomId))
                    {
                        gameClient.SendMessage(command.ToString() + ";");
                    }
                }
            }
        }
        // METODA INICJALIZUJĄCA NOWEGO ADMINA DLA DANEGO GAMEROOMU
        private void InitializeNewRoomAdmin(int RID)
        {
            GameRoom gameRoom = this.GetGameRoomByID(RID);
            List<int> roomUsersIds = new List<int>();
            foreach(GameClient roomClient in this._clients)
            {
                if (roomClient.GetRoomId().Equals(gameRoom.ID))
                {
                    roomUsersIds.Add(roomClient.GetID());
                }
            }
            Random randomIndexGenerator = new Random();
            int[] userIDs = roomUsersIds.ToArray();
            if (userIDs.Length < 1)
                return;
            int newAdminIDindex;
            while (true)
            {
                newAdminIDindex = randomIndexGenerator.Next(0, userIDs.Length);
                if (userIDs[newAdminIDindex].Equals(gameRoom.ADMIN_ID))
                    continue;
                else break;
            }
            int newAdminID = userIDs[newAdminIDindex];
            gameRoom.ADMIN_ID = newAdminID;
            foreach (GameClient roomClient in this._clients)
            {
                if (roomClient.GetID().Equals(newAdminID))
                    roomClient.SendMessage("ROOM_ADMIN;");
                else roomClient.SendMessage("ROOM_USER");
            }
        }

        private void SendChatMessage(string message, int RID)
        {
            foreach(GameClient roomClient in this._clients)
            {
                if(roomClient.GetRoomId().Equals(RID))
                    roomClient.SendMessage("CHAT_MESSAGE:" + message + ";");
            }
        }

        public GameRoom GetGameRoomByName(string gameRoomName)
        {
            foreach(GameRoom gameRoom in this._rooms)
            {
                if (gameRoom.NAME.Equals(gameRoomName))
                    return gameRoom;
            }
            return null;
        }

        public GameRoom GetGameRoomByID(int RID)
        {
            foreach (GameRoom gameRoom in this._rooms)
            {
                if (gameRoom.ID.Equals(RID))
                    return gameRoom;
            }
            return null;
        }

        private bool GameRoomExists(string roomName)
        {
            foreach(GameRoom gameRoom in this._rooms)
            {
                if (gameRoom.NAME.Equals(roomName))
                    return true;
            }
            return false;
        }

        private void SendRoomJoinFailedMessage(int UID, string reason)
        {
            GameClient gameClient = this.GetGameClientById(UID);
            gameClient.SendMessage("ROOM_JOIN_FAILED:" + reason + ";");
        }

        private void SendRoomJoinOkMessageAndInitialize(int UID, int RID)
        {
            GameClient gameClient = this.GetGameClientById(UID);
            gameClient.SendMessage("ROOM_JOIN_OK:" + RID.ToString() + ";");
            gameClient.SetRoomId(RID);
            Thread.Sleep(50);
            this.SendRoomUsersUpdate(RID);
        }

        private void SendRoomAcceptMsgAndInitialize(int UID, int RID)
        {
            GameClient gameClient = this.GetGameClientById(UID);
            gameClient.SendMessage("ROOM_CREATION_OK:" + RID.ToString() + ";");
            gameClient.SetRoomId(RID);
        }

        private void SendRoomCreationFailedMsg(int UID, string reason)
        {
            GameClient gameClient = this.GetGameClientById(UID);
            gameClient.SendMessage("ROOM_CREATION_FAILED:" + reason + "");
        }

        public int GetAmountOfActiveClients()
        {
            return this._amountOfActiveClients;
        }
        public void SetInformationAboutActiveClients(ListBox activeClients, int amountOfActiveClients)
        {
            this._activeClients = activeClients;
            this._amountOfActiveClients = amountOfActiveClients;
        }
        public void SetInformationAboutExistingRooms(ListBox existingRooms)
        {
            this._existingRooms = existingRooms;
        }

        public bool UsernameExists(string username)
        {
            foreach (GameClient actualGameClient in this._clients)
            {
                if (actualGameClient.GetUserName().Equals(username))
                    return true;
            }
            return false;
        }
        public ClientManager()
        {
            this._clients = new List<GameClient>();
            this._rooms = new List<GameRoom>();
            this._reservedClientIDs = new List<int>();
            this._reservedRoomIDs = new List<int>();
            this._catchWords = new List<string>();
            this._amountOfActiveClients = 0;
            this._commandListenerThread = new Thread(this.ListenToClientsMessages);
            this.InitializeCatchWordList();
        }
        // LOSOWANIE HASŁA
        private string GetRandomCatchWord()
        {
            Random randomNumber = new Random();
            string[] cathwords = this._catchWords.ToArray();
            int randomCatchwordIndex = randomNumber.Next(0, cathwords.Length);
            return cathwords.ElementAt(randomCatchwordIndex);
        }
        // INICJALIZACJA LISTY HASEŁ, POBRANIE ICH Z PLIKU 
        private void InitializeCatchWordList()
        {
            try{
                using(StreamReader catchwordReader = new StreamReader("CATCHWORD_LST.txt"))
                {
                    string catchword = String.Empty;
                    while((catchword = catchwordReader.ReadLine())!= null)
                    {
                        this._catchWords.Add(catchword);
                    }
                }
            }catch(FileNotFoundException fNotFoundExc)
            {
                MessageBox.Show(fNotFoundExc.ToString());
                Application.Exit();
            }
        }

        public bool RoomNameExists(string roomName)
        {
            foreach(GameRoom gameRoom in this._rooms){
                if (gameRoom.NAME.Equals(roomName))
                    return true;
            }
            return false;
        }

        public void StartListening()
        {
            this._commandListenerThread.Start();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void StopListening()
        {
            foreach (GameClient gameClient in this._clients)
                gameClient.CloseConnection();
            this._commandListenerThread.Abort();
        }

        public void SetClientsModyfyingTrue()
        {
            this._clientsModyfying = true;
        }

        public string GetUserNameById(int id)
        {
            foreach (GameClient gameClient in this._clients)
            {
                if (gameClient.GetID().Equals(id))
                    return gameClient.GetUserName();
            }
            return String.Empty;
        }

        public bool DisconnectUserById(int userID)
        {
            try
            {
                this.SetClientsModyfyingTrue();
                GameClient gameClient = this.GetGameClientById(userID);
                this._amountOfActiveClients--;
                this._clients.Remove(gameClient);
                this.RemoveClientUsername(gameClient.GetUserName());
                this.SendUpdateAboutClients();
                this.SetClientsModyfyingFalse();
                return true;
            }
            catch (Exception e)
            {
                this.SetClientsModyfyingFalse();
                return false;
            }
            this.SetClientsModyfyingFalse();
        }

        public int GetIdByUserName(string userName)
        {
            foreach (GameClient gameClient in this._clients)
            {
                if (gameClient.GetUserName().Equals(userName))
                    return gameClient.GetID();
            }
            return 0;
        }

        public GameClient GetGameClientById(int userId)
        {
            foreach (GameClient gameClient in this._clients)
            {
                if (gameClient.GetID().Equals(userId))
                    return gameClient;
            }
            return null;
        }
        public void SetClientsModyfyingFalse()
        {
            this._clientsModyfying = false;
        }

        private void AddNewGameRoomName(string gameRoomName)
        {
            if (this._existingRooms.InvokeRequired)
            {
                this._existingRooms.Invoke(new Action<string>(AddNewGameRoomName), gameRoomName);
            }
            else this._existingRooms.Items.Add(gameRoomName);
        }

        private void RemoveGameRoomName(string gameRoomName)
        {
            if (this._existingRooms.InvokeRequired)
            {
                this._existingRooms.Invoke(new Action<string>(RemoveGameRoomName), gameRoomName);
            }
            else this._existingRooms.Items.Remove(gameRoomName);
        }

    }
}
