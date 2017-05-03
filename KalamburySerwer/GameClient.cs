using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KalamburySerwer
{
    class GameClient
    {
        private Client clientInstance { set; get; }

        public void Connect(Socket clientSocket, int id)
        {
            this.clientInstance = new Client(clientSocket, id);
        }

        public string GetStatus()
        {
            return this.clientInstance.GetStatus();
        }
        
        public void SetStatus(string status)
        {
            this.clientInstance.SetStatus(status);
        }

        public void UpdateScore()
        {
            this.clientInstance.SetScore(this.clientInstance.GetScore() + 100);
        }
        public string GetScore()
        {
            return Convert.ToString(this.clientInstance.GetScore());
        }

        public void ClearScore()
        {
            this.clientInstance.SetScore(0);
        }

        public int GetRoomId()
        {
            return this.clientInstance.GetRoomId();
        }
         
        public void SetRoomId(int roomId)
        {
            this.clientInstance.SetRoomId(roomId);
        }

        public void CloseConnection()
        {
            this.clientInstance.CloseConnection();
        }
        public bool DataAvalible()
        {
            return this.clientInstance.Avalible();
        }
        public string RecieveMessage()
        {
            return this.clientInstance.RecieveMessage();
        }

        public void SendMessage(string message)
        {
            this.clientInstance.SendMessage(message);
        }

        public void SetUserName(string userName)
        {
            this.clientInstance.SetUserName(userName);
        }

        public string GetUserName()
        {
            return this.clientInstance.GetUsername();
        }

        public int GetID()
        {
            return this.clientInstance.GetID();
        }

        public GameClient() { }
    }
}
