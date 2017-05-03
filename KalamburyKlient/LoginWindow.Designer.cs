namespace KalamburyKlient
{
    partial class LoginWindow
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
            this.userNameEntered = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.LBL_IP_ADDRESS = new System.Windows.Forms.Label();
            this.LBL_PORT = new System.Windows.Forms.Label();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBL_USER_NAME
            // 
            this.LBL_USER_NAME.AutoSize = true;
            this.LBL_USER_NAME.Location = new System.Drawing.Point(13, 13);
            this.LBL_USER_NAME.Name = "LBL_USER_NAME";
            this.LBL_USER_NAME.Size = new System.Drawing.Size(178, 18);
            this.LBL_USER_NAME.TabIndex = 0;
            this.LBL_USER_NAME.Text = "Nazwa użytkownika:";
            // 
            // userNameEntered
            // 
            this.userNameEntered.Location = new System.Drawing.Point(223, 10);
            this.userNameEntered.Name = "userNameEntered";
            this.userNameEntered.Size = new System.Drawing.Size(355, 26);
            this.userNameEntered.TabIndex = 1;
            // 
            // submitBtn
            // 
            this.submitBtn.ForeColor = System.Drawing.Color.Green;
            this.submitBtn.Location = new System.Drawing.Point(415, 104);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(163, 40);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Potwierdź!";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // LBL_IP_ADDRESS
            // 
            this.LBL_IP_ADDRESS.AutoSize = true;
            this.LBL_IP_ADDRESS.Location = new System.Drawing.Point(13, 50);
            this.LBL_IP_ADDRESS.Name = "LBL_IP_ADDRESS";
            this.LBL_IP_ADDRESS.Size = new System.Drawing.Size(86, 18);
            this.LBL_IP_ADDRESS.TabIndex = 3;
            this.LBL_IP_ADDRESS.Text = "Adres IP:";
            // 
            // LBL_PORT
            // 
            this.LBL_PORT.AutoSize = true;
            this.LBL_PORT.Location = new System.Drawing.Point(13, 87);
            this.LBL_PORT.Name = "LBL_PORT";
            this.LBL_PORT.Size = new System.Drawing.Size(49, 18);
            this.LBL_PORT.TabIndex = 4;
            this.LBL_PORT.Text = "Port:";
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(223, 42);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(215, 26);
            this.ipAddress.TabIndex = 5;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(223, 79);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(103, 26);
            this.port.TabIndex = 6;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(590, 145);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.LBL_PORT);
            this.Controls.Add(this.LBL_IP_ADDRESS);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.userNameEntered);
            this.Controls.Add(this.LBL_USER_NAME);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zaloguj się!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_USER_NAME;
        public System.Windows.Forms.TextBox userNameEntered;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label LBL_IP_ADDRESS;
        private System.Windows.Forms.Label LBL_PORT;
        public System.Windows.Forms.TextBox ipAddress;
        public System.Windows.Forms.TextBox port;
    }
}