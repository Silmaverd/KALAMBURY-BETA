using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburyKlient
{
    public partial class PrivateChat : Form
    {
        private GameWindow game;
        public PrivateChat(GameWindow game)
        {
            InitializeComponent();
            this.game = game;
        }

        public void UpdateChatRoom(string message)
        {
            if (this.chatRoom.InvokeRequired)
            {
                this.chatRoom.Invoke(new Action<string>(this.UpdateChatRoom), message);
            }
            else
            {
                this.chatRoom.Items.Add(game.ConvertToDisplayableMessage(message));
                int visibleItems = this.chatRoom.ClientSize.Height / this.chatRoom.ItemHeight;
                this.chatRoom.TopIndex = Math.Max(this.chatRoom.Items.Count - visibleItems + 1, 0);
            }
        }

        // WYSŁANIE WIADOMOŚCI NA PRYWATNYM CHACIE 
        private void chatSendMessageBtn_Click(object sender, EventArgs e)
        {
            string message = this.chatMessage.Text;

            if (userNameEntered.TextLength != 0)
            {
                if (message != String.Empty)
                {
                    this.chatMessage.Clear();
                    string safeMessage = game.ConvertToSafeMessageFormat(message);
                    Console.WriteLine("wiad  " + safeMessage + "user" + userNameEntered.Text);
                    game.getGameServer().SendMessage("PRIVATE_CHAT_MESSAGE:" + userNameEntered.Text + ":" + safeMessage);
                }
            }
            else
            {
                //todo
            }
        }

        public void pouse()
        {
            Thread.Sleep(200);
        }
    }
}
