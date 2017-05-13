using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburySerwer
{
    class Client
    {
        private Socket _clientSocket { set; get; }
        private int _id { set; get; }
        private string _username { set; get; }
        private int _score { set; get; }
        private int _roomID;
        private string status;

        public Client(Socket clientSocket, int id)
        {
            this._clientSocket = clientSocket;
            this._id = id;
            this._username = "";
            this._score = 0;
            this._clientSocket.ReceiveTimeout = 200;
            this.status = "W menu.";
        }
        // METODA SPRAWDZAJĄCA, CZY W SOCKECIE KLIENTA SĄ BAJTY DO ODBIORU
        public bool Avalible()
        {
            return this._clientSocket.Available > 0;
        }

        public string GetStatus()
        {
            return this.status;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public int GetRoomId()
        {
            return this._roomID;
        }

        public void SetRoomId(int roomId)
        {
            this._roomID = roomId;
        }

        public void CloseConnection()
        {
            this._clientSocket.Close();
        }
        // METODA WYSYŁĄJĄCA WIADOMOŚĆ NA SOCKET KLIENTA
        public bool SendMessage(string message)
        {
            if (!this._clientSocket.Connected)
                return false;
            try
            {
                this._clientSocket.Send(ASCIIEncoding.UTF8.GetBytes(message));
                return true;
            }catch(SocketException socException)
            {
                MessageBox.Show(socException.ToString());
                return false;
            }
        }
        // METODA POBIERAJĄCA BAJTY Z BUFORA SOCKETU KLIENTA
        public string RecieveMessage()
        {
            byte[] message = new byte[24000];
            this._clientSocket.Receive(message);
            string messageConverted = ASCIIEncoding.UTF8.GetString(message);
            return messageConverted;
        }

        public void SetScore(int score)
        {
            this._score = score;
        }

        public void SetUserName(string username)
        {
            this._username = username;
        }

        public void ClearScore()
        {
            this._score = 0;
        }

        public int GetID()
        {
            return this._id;
        }

        public string GetUsername()
        {
            return this._username;
        }
        
        public int GetScore()
        {
            return this._score;
        }
    }
}
