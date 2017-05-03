namespace KalamburyKlient
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_USER_NAME = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.loggedUsers = new System.Windows.Forms.ListBox();
            this.activeGameRooms = new System.Windows.Forms.ListBox();
            this.LBL_ACTIVE_ROOMS = new System.Windows.Forms.Label();
            this.LBL_ACTIVE_PLAYERS = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.joinRoomBtn = new System.Windows.Forms.Button();
            this.createRoomBtn = new System.Windows.Forms.Button();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_USER_NAME
            // 
            this.LBL_USER_NAME.AutoSize = true;
            this.LBL_USER_NAME.Location = new System.Drawing.Point(9, 9);
            this.LBL_USER_NAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_USER_NAME.Name = "LBL_USER_NAME";
            this.LBL_USER_NAME.Size = new System.Drawing.Size(160, 16);
            this.LBL_USER_NAME.TabIndex = 0;
            this.LBL_USER_NAME.Text = "Nazwa użytkownika: ";
            this.LBL_USER_NAME.Visible = false;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.ForeColor = System.Drawing.Color.Green;
            this.userName.Location = new System.Drawing.Point(176, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(0, 16);
            this.userName.TabIndex = 1;
            // 
            // loggedUsers
            // 
            this.loggedUsers.FormattingEnabled = true;
            this.loggedUsers.ItemHeight = 16;
            this.loggedUsers.Location = new System.Drawing.Point(215, 67);
            this.loggedUsers.Name = "loggedUsers";
            this.loggedUsers.Size = new System.Drawing.Size(191, 196);
            this.loggedUsers.TabIndex = 2;
            // 
            // activeGameRooms
            // 
            this.activeGameRooms.FormattingEnabled = true;
            this.activeGameRooms.ItemHeight = 16;
            this.activeGameRooms.Location = new System.Drawing.Point(12, 67);
            this.activeGameRooms.Name = "activeGameRooms";
            this.activeGameRooms.Size = new System.Drawing.Size(176, 196);
            this.activeGameRooms.TabIndex = 3;
            // 
            // LBL_ACTIVE_ROOMS
            // 
            this.LBL_ACTIVE_ROOMS.AutoSize = true;
            this.LBL_ACTIVE_ROOMS.Location = new System.Drawing.Point(12, 48);
            this.LBL_ACTIVE_ROOMS.Name = "LBL_ACTIVE_ROOMS";
            this.LBL_ACTIVE_ROOMS.Size = new System.Drawing.Size(129, 16);
            this.LBL_ACTIVE_ROOMS.TabIndex = 4;
            this.LBL_ACTIVE_ROOMS.Text = "Aktywne pokoje:";
            // 
            // LBL_ACTIVE_PLAYERS
            // 
            this.LBL_ACTIVE_PLAYERS.AutoSize = true;
            this.LBL_ACTIVE_PLAYERS.Location = new System.Drawing.Point(212, 48);
            this.LBL_ACTIVE_PLAYERS.Name = "LBL_ACTIVE_PLAYERS";
            this.LBL_ACTIVE_PLAYERS.Size = new System.Drawing.Size(63, 16);
            this.LBL_ACTIVE_PLAYERS.TabIndex = 5;
            this.LBL_ACTIVE_PLAYERS.Text = "Gracze:";
            // 
            // connectBtn
            // 
            this.connectBtn.ForeColor = System.Drawing.Color.Green;
            this.connectBtn.Location = new System.Drawing.Point(444, 9);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(123, 35);
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "Połącz!";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // joinRoomBtn
            // 
            this.joinRoomBtn.Location = new System.Drawing.Point(444, 152);
            this.joinRoomBtn.Name = "joinRoomBtn";
            this.joinRoomBtn.Size = new System.Drawing.Size(123, 38);
            this.joinRoomBtn.TabIndex = 7;
            this.joinRoomBtn.Text = "Dołącz do gry!";
            this.joinRoomBtn.UseVisualStyleBackColor = true;
            this.joinRoomBtn.Click += new System.EventHandler(this.joinRoomBtn_Click);
            // 
            // createRoomBtn
            // 
            this.createRoomBtn.Location = new System.Drawing.Point(444, 196);
            this.createRoomBtn.Name = "createRoomBtn";
            this.createRoomBtn.Size = new System.Drawing.Size(123, 67);
            this.createRoomBtn.TabIndex = 8;
            this.createRoomBtn.Text = "Stwórz grę!";
            this.createRoomBtn.UseVisualStyleBackColor = true;
            this.createRoomBtn.Click += new System.EventHandler(this.createRoomBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.disconnectBtn.Location = new System.Drawing.Point(444, 51);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(123, 28);
            this.disconnectBtn.TabIndex = 9;
            this.disconnectBtn.Text = "Rozłącz.";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(580, 269);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.createRoomBtn);
            this.Controls.Add(this.joinRoomBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.LBL_ACTIVE_PLAYERS);
            this.Controls.Add(this.LBL_ACTIVE_ROOMS);
            this.Controls.Add(this.activeGameRooms);
            this.Controls.Add(this.loggedUsers);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.LBL_USER_NAME);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kalambury!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_USER_NAME;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.ListBox loggedUsers;
        private System.Windows.Forms.ListBox activeGameRooms;
        private System.Windows.Forms.Label LBL_ACTIVE_ROOMS;
        private System.Windows.Forms.Label LBL_ACTIVE_PLAYERS;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button joinRoomBtn;
        private System.Windows.Forms.Button createRoomBtn;
        private System.Windows.Forms.Button disconnectBtn;
    }
}

