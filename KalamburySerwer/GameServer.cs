using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburySerwer
{
    class GameServer
    {
        private Socket mainServerSocket { set; get; }
        private string IpAddress;
        private int Port;
        private int MaxPlayers;
        private int PlayersActive;
        private ClientManager clientManager;
        private Thread waitForClientsThread;
        private ListBox clientsList;
        private ListBox roomsList;

        public GameServer(string _IpAddress, int _Port, int _MaxPlayers)
        {
            this.mainServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            this.IpAddress = _IpAddress;
            this.Port = _Port;
            this.MaxPlayers = _MaxPlayers;
            this.PlayersActive = 0;
            this.clientManager = new ClientManager();
            this.waitForClientsThread = new Thread(this.WaitForClientsToConnect);

        }
        public bool Connect()
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(this.IpAddress), this.Port);
                this.mainServerSocket.Bind(serverEndPoint);
                this.mainServerSocket.Listen(this.MaxPlayers);

                this.waitForClientsThread.Start();
                this.clientManager.StartListening();
                return true;
            }
            catch (SocketException socException)
            {
                MessageBox.Show("Błąd inicjalizacji serwera!\n" + socException.ToString());
                return false;
            }
        }

        public void SetRoomsList(ListBox roomsList)
        {
            this.roomsList = roomsList;
            this.clientManager.SetInformationAboutExistingRooms(this.roomsList);
        }
        public void SetClientsList(ListBox clientsList)
        {
            this.clientsList = clientsList;
            this.clientManager.SetInformationAboutActiveClients(this.clientsList,this.PlayersActive);
        }

        public Socket GetNewClientSocket()
        {
            return this.mainServerSocket.Accept();
        }
        // METODA CZEKAJĄCA NA POŁĄCZENIE SIĘ KLIENTA
        private void WaitForClientsToConnect()
        {
            while (true)
            {
                if (this.clientManager.GetAmountOfActiveClients() >= this.MaxPlayers)
                {
                    Thread.Sleep(50);
                    continue;
                }
                Socket clientSocket = this.GetNewClientSocket();
                byte[] username = new byte[256];
                // POBRANIE USERNAME
                clientSocket.Receive(username);
                string usernameConverted = ASCIIEncoding.UTF8.GetString(username);
                usernameConverted = usernameConverted.Substring(0, usernameConverted.IndexOf('\0'));
                if (!clientManager.UsernameExists(usernameConverted))
                {
                    this.PlayersActive++;
                    this.clientManager.AddNewClient(clientSocket, usernameConverted);
                }
                this.clientManager.SetClientsModyfyingFalse();
            }
        }

        public int GetClientIDByUserName(string userName)
        {
            return this.clientManager.GetIdByUserName(userName);
        }

        public GameClient GetGameClientByID(int userId)
        {
            return this.clientManager.GetGameClientById(userId);
        }

        public bool DisconnectSelectedUser(string userName, string reason)
        {
            int userId = this.GetClientIDByUserName(userName);
            GameClient clientToRemove = this.GetGameClientByID(userId);
            clientToRemove.SendMessage("USER_DISCONNECTED:" + reason + ";");
            this.clientManager.DisconnectUserById(userId);
            this.PlayersActive--;
            return true;
        }

        public void AddNewUserNameToTheList(string userName)
        {
            if (this.clientsList.InvokeRequired)
                this.clientsList.Invoke(new Action<string>(AddNewUserNameToTheList), userName);
            else
                this.clientsList.Items.Add(userName);
        }

        public bool IsConnected()
        {
            return this.mainServerSocket.IsBound;
        }

        public int GetNumberOfActivePlayers()
        {
            return this.clientManager.GetAmountOfActiveClients();
        }

        public string GetIpAddress()
        {
            return this.IpAddress;
        }

        public int GetPort()
        {
            return this.Port;
        }

        public int GetMaxPlayers()
        {
            return this.MaxPlayers;
        }


        [SecurityPermissionAttribute(SecurityAction.Demand,ControlThread = true)]
        public void StopListening()
        {
                this.mainServerSocket.Close();
                this.waitForClientsThread.Abort();
                this.clientManager.StopListening();
        }
    }
}
