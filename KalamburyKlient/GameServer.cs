using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburyKlient
{
    public class GameServer
    {
        private string IP_ADDRESS;
        private int PORT;

        private Socket serverSocket;
        public GameServer()
        {
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }

        public bool Connect(string userName, string ipAddress, int port)
        {
            try
            {
                this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                this.serverSocket.Connect(ipAddress, port);
                this.SendMessage(userName);
                return true;
            }catch(SocketException socException)
            {
                MessageBox.Show("Błąd po stronie serwera!");
                return false;
            }
        }
        // ODBIERANIE WIADOMOŚCI Z SOCKETU SERWERA
        public string RecieveMessage()
        {
            if (!serverSocket.Connected)
                return String.Empty;
            byte[] messageBytes = new byte[24000];
            this.serverSocket.Receive(messageBytes);
            return ASCIIEncoding.UTF8.GetString(messageBytes);
        }
        // WYSŁANIE WIADOMOŚCI NA SOCKET SERWERA
        public void SendMessage(string message)
        {
            if (!serverSocket.Connected)
                return;
            this.serverSocket.Send(ASCIIEncoding.UTF8.GetBytes(message));
        }

        public void Disconnect()
        {
            if (!serverSocket.Connected)
                return;
            this.SendMessage("USER_DISCONNECTED");
            this.serverSocket.Close();
        }
        // METODA MÓWIĄCA O TYM, CZY W BUFORZE SOCKETU SERWERA ZNAJDUJĄ SIĘ BAJTY DO ODBIORU
        public bool DataAvalibleToRecieve()
        {
            return this.serverSocket.Available > 0;
        }

        public bool Connected()
        {
            return this.serverSocket.Connected;
        }
    }
}
