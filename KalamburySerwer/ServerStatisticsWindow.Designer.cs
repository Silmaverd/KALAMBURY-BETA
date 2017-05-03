namespace KalamburySerwer
{
    partial class ServerStatisticsWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.initializeServerBtn = new System.Windows.Forms.Button();
            this.LBL_ACTIVE_PLAYERS = new System.Windows.Forms.Label();
            this.activePlayersList = new System.Windows.Forms.ListBox();
            this.LBL_SERVER_STATS = new System.Windows.Forms.Label();
            this.serverStatistics = new System.Windows.Forms.Label();
            this.LBL_ACTIVE_ROOMS = new System.Windows.Forms.Label();
            this.activeGameRooms = new System.Windows.Forms.ListBox();
            this.playerKickButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // initializeServerBtn
            // 
            this.initializeServerBtn.Location = new System.Drawing.Point(19, 411);
            this.initializeServerBtn.Name = "initializeServerBtn";
            this.initializeServerBtn.Size = new System.Drawing.Size(177, 23);
            this.initializeServerBtn.TabIndex = 0;
            this.initializeServerBtn.Text = "Włącz serwer.";
            this.initializeServerBtn.UseVisualStyleBackColor = true;
            this.initializeServerBtn.Click += new System.EventHandler(this.initializeServerBtn_Click);
            // 
            // LBL_ACTIVE_PLAYERS
            // 
            this.LBL_ACTIVE_PLAYERS.AutoSize = true;
            this.LBL_ACTIVE_PLAYERS.Location = new System.Drawing.Point(215, 14);
            this.LBL_ACTIVE_PLAYERS.Name = "LBL_ACTIVE_PLAYERS";
            this.LBL_ACTIVE_PLAYERS.Size = new System.Drawing.Size(115, 16);
            this.LBL_ACTIVE_PLAYERS.TabIndex = 1;
            this.LBL_ACTIVE_PLAYERS.Text = "Aktywni gracze:";
            // 
            // activePlayersList
            // 
            this.activePlayersList.FormattingEnabled = true;
            this.activePlayersList.ItemHeight = 16;
            this.activePlayersList.Location = new System.Drawing.Point(218, 33);
            this.activePlayersList.Name = "activePlayersList";
            this.activePlayersList.Size = new System.Drawing.Size(120, 372);
            this.activePlayersList.TabIndex = 2;
            // 
            // LBL_SERVER_STATS
            // 
            this.LBL_SERVER_STATS.AutoSize = true;
            this.LBL_SERVER_STATS.Location = new System.Drawing.Point(13, 13);
            this.LBL_SERVER_STATS.Name = "LBL_SERVER_STATS";
            this.LBL_SERVER_STATS.Size = new System.Drawing.Size(139, 16);
            this.LBL_SERVER_STATS.TabIndex = 3;
            this.LBL_SERVER_STATS.Text = "Statystyki serwera:";
            // 
            // serverStatistics
            // 
            this.serverStatistics.AutoSize = true;
            this.serverStatistics.ForeColor = System.Drawing.Color.Black;
            this.serverStatistics.Location = new System.Drawing.Point(16, 33);
            this.serverStatistics.Name = "serverStatistics";
            this.serverStatistics.Size = new System.Drawing.Size(0, 16);
            this.serverStatistics.TabIndex = 4;
            // 
            // LBL_ACTIVE_ROOMS
            // 
            this.LBL_ACTIVE_ROOMS.AutoSize = true;
            this.LBL_ACTIVE_ROOMS.Location = new System.Drawing.Point(16, 158);
            this.LBL_ACTIVE_ROOMS.Name = "LBL_ACTIVE_ROOMS";
            this.LBL_ACTIVE_ROOMS.Size = new System.Drawing.Size(119, 16);
            this.LBL_ACTIVE_ROOMS.TabIndex = 5;
            this.LBL_ACTIVE_ROOMS.Text = "Aktywne pokoje:";
            // 
            // activeGameRooms
            // 
            this.activeGameRooms.FormattingEnabled = true;
            this.activeGameRooms.ItemHeight = 16;
            this.activeGameRooms.Location = new System.Drawing.Point(19, 177);
            this.activeGameRooms.Name = "activeGameRooms";
            this.activeGameRooms.Size = new System.Drawing.Size(177, 228);
            this.activeGameRooms.TabIndex = 6;
            // 
            // playerKickButton
            // 
            this.playerKickButton.Location = new System.Drawing.Point(218, 410);
            this.playerKickButton.Name = "playerKickButton";
            this.playerKickButton.Size = new System.Drawing.Size(120, 23);
            this.playerKickButton.TabIndex = 7;
            this.playerKickButton.Text = "Wyrzuć!";
            this.playerKickButton.UseVisualStyleBackColor = true;
            this.playerKickButton.Click += new System.EventHandler(this.playerKickButton_Click);
            // 
            // ServerStatisticsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(358, 442);
            this.Controls.Add(this.playerKickButton);
            this.Controls.Add(this.activeGameRooms);
            this.Controls.Add(this.LBL_ACTIVE_ROOMS);
            this.Controls.Add(this.serverStatistics);
            this.Controls.Add(this.LBL_SERVER_STATS);
            this.Controls.Add(this.activePlayersList);
            this.Controls.Add(this.LBL_ACTIVE_PLAYERS);
            this.Controls.Add(this.initializeServerBtn);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServerStatisticsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statystyki serwera.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerStatisticsWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerStatisticsWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button initializeServerBtn;
        private System.Windows.Forms.Label LBL_ACTIVE_PLAYERS;
        private System.Windows.Forms.ListBox activePlayersList;
        private System.Windows.Forms.Label LBL_SERVER_STATS;
        private System.Windows.Forms.Label serverStatistics;
        private System.Windows.Forms.Label LBL_ACTIVE_ROOMS;
        private System.Windows.Forms.ListBox activeGameRooms;
        private System.Windows.Forms.Button playerKickButton;
    }
}

