using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class ServerStatisticsWindow : Form
    {
        private GameServer gameServer { set; get; }
        Thread serverStaticsWritingThread;
        public ServerStatisticsWindow()
        {
            InitializeComponent();
            this.serverStaticsWritingThread = new Thread(this.MonitorServerStatistics);
        }

        private void initializeServerBtn_Click(object sender, EventArgs e)
        {
            ConnectionWindow serverParameters = new ConnectionWindow();
            serverParameters.ShowDialog();

            string IpAddress = serverParameters.GetIpAddress();
            int Port = serverParameters.GetPort();
            int MaxPlayers = serverParameters.GetMaxPlayers();

            this.gameServer = new GameServer(IpAddress,Port,MaxPlayers);
            this.gameServer.SetClientsList(this.activePlayersList);
             
            this.gameServer = new GameServer(IpAddress, Port, MaxPlayers);
            this.gameServer.SetClientsList(this.activePlayersList);
            this.gameServer.SetRoomsList(this.activeGameRooms);

            if (this.gameServer.Connect())
            {
                this.serverStaticsWritingThread.Start();
                this.initializeServerBtn.Enabled = false;
            }
        }

        private void DisplayServerStatistics()
        {
                if (!this.serverStatistics.InvokeRequired)
                {
                    this.serverStatistics.Text = "";
                    if (this.gameServer.IsConnected())
                    {
                        this.serverStatistics.Text = "ONLINE\n";
                        this.serverStatistics.Text += this.gameServer.GetIpAddress() + ":" +
                            this.gameServer.GetPort() + "\n" + "Maksymalnie graczy: " + this.gameServer.GetMaxPlayers() + "\n" +
                            "Aktywnych graczy: " + this.gameServer.GetNumberOfActivePlayers();
                    }
                    else
                    {
                        this.serverStatistics.Text = "OFFLINE\n";
                    }
                }
                else
                {
                    this.serverStatistics.Invoke(new Action(DisplayServerStatistics));
                }  
        }
        private void MonitorServerStatistics()
        {
            while (true)
            {
                this.DisplayServerStatistics();
                Thread.Sleep(150);
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void ServerStatisticsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.serverStaticsWritingThread.Abort();
            this.gameServer.StopListening();
        }
        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void ServerStatisticsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.serverStaticsWritingThread.Abort();
            this.gameServer.StopListening();
        }

        private void playerKickButton_Click(object sender, EventArgs e)
        {
            KickReasonWindow kickReasonWindow = new KickReasonWindow();
            kickReasonWindow.ShowDialog();
            string disconnectionReason = kickReasonWindow.GetKickReason();
            string selectedClient = this.activePlayersList.SelectedItem.ToString();
            this.gameServer.DisconnectSelectedUser(selectedClient,disconnectionReason);
        }
    }
}
