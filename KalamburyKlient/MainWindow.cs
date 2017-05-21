using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburyKlient
{
    public partial class MainWindow : Form
    {
        private string USER_NAME;
        private string USER_ID;
        private string ROOM_ID;

        private GameManager gameManager;

        public MainWindow()
        {
            InitializeComponent();
            this.disconnectBtn.Enabled = false;
            this.joinRoomBtn.Enabled = false;
            this.createRoomBtn.Enabled = false;
            this.gameManager = new GameManager(this.loggedUsers,this.activeGameRooms);
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            this.USER_NAME = loginWindow.userNameEntered.Text;
            this.LBL_USER_NAME.Visible = true;
            this.userName.Visible = true;
            this.disconnectBtn.Enabled = true;
            this.connectBtn.Enabled = false;
            this.userName.Text = this.USER_NAME;
            this.gameManager.Connect(this.USER_NAME,loginWindow.ipAddress.Text,Convert.ToInt32(loginWindow.port.Text));
            this.gameManager.SetUserName(this.USER_NAME);
            this.joinRoomBtn.Enabled = true;
            this.createRoomBtn.Enabled = true;
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            this.disconnectBtn.Enabled = false;
            this.connectBtn.Enabled = true;
            this.LBL_USER_NAME.Visible = false;
            this.userName.Visible = true;
            this.userName.Text = "";
            this.USER_NAME = String.Empty;
            this.USER_ID = "0";
            this.gameManager.SetUserName("");
            this.gameManager.SetGameRoomName("");
            this.gameManager.Disconnect();
        }

        private void createRoomBtn_Click(object sender, EventArgs e)
        {
            this.gameManager.CreateRoom();
        }

        private void roomExitBtn_Click(object sender, EventArgs e)
        {
            this.gameManager.ExitFromGameRoom();
        }

        private void joinRoomBtn_Click(object sender, EventArgs e)
        {
            this.gameManager.JoinRoom(this.activeGameRooms.SelectedItem.ToString());
        }
    }
}
