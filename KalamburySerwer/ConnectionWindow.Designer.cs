namespace KalamburySerwer
{
    partial class ConnectionWindow
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
            this.LBL_IP = new System.Windows.Forms.Label();
            this.LBL_PORT = new System.Windows.Forms.Label();
            this.LBL_MAX_PLAYERS = new System.Windows.Forms.Label();
            this.acceptInfoBtn = new System.Windows.Forms.Button();
            this.MaxPlayersField = new System.Windows.Forms.TextBox();
            this.PortField = new System.Windows.Forms.TextBox();
            this.IpAddressField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBL_IP
            // 
            this.LBL_IP.AutoSize = true;
            this.LBL_IP.Location = new System.Drawing.Point(12, 9);
            this.LBL_IP.Name = "LBL_IP";
            this.LBL_IP.Size = new System.Drawing.Size(56, 16);
            this.LBL_IP.TabIndex = 0;
            this.LBL_IP.Text = "Adres: ";
            // 
            // LBL_PORT
            // 
            this.LBL_PORT.AutoSize = true;
            this.LBL_PORT.Location = new System.Drawing.Point(12, 47);
            this.LBL_PORT.Name = "LBL_PORT";
            this.LBL_PORT.Size = new System.Drawing.Size(46, 16);
            this.LBL_PORT.TabIndex = 1;
            this.LBL_PORT.Text = "Port: ";
            // 
            // LBL_MAX_PLAYERS
            // 
            this.LBL_MAX_PLAYERS.AutoSize = true;
            this.LBL_MAX_PLAYERS.Location = new System.Drawing.Point(12, 85);
            this.LBL_MAX_PLAYERS.Name = "LBL_MAX_PLAYERS";
            this.LBL_MAX_PLAYERS.Size = new System.Drawing.Size(94, 16);
            this.LBL_MAX_PLAYERS.TabIndex = 2;
            this.LBL_MAX_PLAYERS.Text = "Max graczy: ";
            // 
            // acceptInfoBtn
            // 
            this.acceptInfoBtn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.acceptInfoBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.acceptInfoBtn.Location = new System.Drawing.Point(272, 116);
            this.acceptInfoBtn.Name = "acceptInfoBtn";
            this.acceptInfoBtn.Size = new System.Drawing.Size(95, 23);
            this.acceptInfoBtn.TabIndex = 3;
            this.acceptInfoBtn.Text = "OK!";
            this.acceptInfoBtn.UseVisualStyleBackColor = true;
            this.acceptInfoBtn.Click += new System.EventHandler(this.acceptInfoBtn_Click);
            // 
            // MaxPlayersField
            // 
            this.MaxPlayersField.Location = new System.Drawing.Point(112, 78);
            this.MaxPlayersField.Name = "MaxPlayersField";
            this.MaxPlayersField.Size = new System.Drawing.Size(162, 23);
            this.MaxPlayersField.TabIndex = 4;
            // 
            // PortField
            // 
            this.PortField.Location = new System.Drawing.Point(112, 44);
            this.PortField.Name = "PortField";
            this.PortField.Size = new System.Drawing.Size(162, 23);
            this.PortField.TabIndex = 5;
            // 
            // IpAddressField
            // 
            this.IpAddressField.Location = new System.Drawing.Point(112, 9);
            this.IpAddressField.Name = "IpAddressField";
            this.IpAddressField.Size = new System.Drawing.Size(162, 23);
            this.IpAddressField.TabIndex = 6;
            // 
            // ConnectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(379, 142);
            this.Controls.Add(this.IpAddressField);
            this.Controls.Add(this.PortField);
            this.Controls.Add(this.MaxPlayersField);
            this.Controls.Add(this.acceptInfoBtn);
            this.Controls.Add(this.LBL_MAX_PLAYERS);
            this.Controls.Add(this.LBL_PORT);
            this.Controls.Add(this.LBL_IP);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConnectionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectionWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_IP;
        private System.Windows.Forms.Label LBL_PORT;
        private System.Windows.Forms.Label LBL_MAX_PLAYERS;
        private System.Windows.Forms.Button acceptInfoBtn;
        private System.Windows.Forms.TextBox MaxPlayersField;
        private System.Windows.Forms.TextBox PortField;
        private System.Windows.Forms.TextBox IpAddressField;
    }
}