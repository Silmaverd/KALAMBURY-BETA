namespace KalamburyKlient
{
    partial class PrivateChat
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
            this.label1 = new System.Windows.Forms.Label();
            this.userNameEntered = new System.Windows.Forms.TextBox();
            this.chatRoom = new System.Windows.Forms.ListBox();
            this.chatMessage = new System.Windows.Forms.TextBox();
            this.chatSendMessageBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username odbiorcy:";
            // 
            // userNameEntered
            // 
            this.userNameEntered.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.userNameEntered.Location = new System.Drawing.Point(183, 10);
            this.userNameEntered.Name = "userNameEntered";
            this.userNameEntered.Size = new System.Drawing.Size(205, 26);
            this.userNameEntered.TabIndex = 2;
            // 
            // chatRoom
            // 
            this.chatRoom.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chatRoom.FormattingEnabled = true;
            this.chatRoom.ItemHeight = 12;
            this.chatRoom.Location = new System.Drawing.Point(8, 52);
            this.chatRoom.Name = "chatRoom";
            this.chatRoom.ScrollAlwaysVisible = true;
            this.chatRoom.Size = new System.Drawing.Size(380, 232);
            this.chatRoom.TabIndex = 8;
            this.chatRoom.TabStop = false;
            // 
            // chatMessage
            // 
            this.chatMessage.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.chatMessage.Location = new System.Drawing.Point(8, 290);
            this.chatMessage.Name = "chatMessage";
            this.chatMessage.Size = new System.Drawing.Size(317, 26);
            this.chatMessage.TabIndex = 9;
            // 
            // chatSendMessageBtn
            // 
            this.chatSendMessageBtn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.chatSendMessageBtn.Location = new System.Drawing.Point(331, 290);
            this.chatSendMessageBtn.Name = "chatSendMessageBtn";
            this.chatSendMessageBtn.Size = new System.Drawing.Size(57, 27);
            this.chatSendMessageBtn.TabIndex = 10;
            this.chatSendMessageBtn.Text = ">";
            this.chatSendMessageBtn.UseVisualStyleBackColor = true;
            this.chatSendMessageBtn.Click += new System.EventHandler(this.chatSendMessageBtn_Click);
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(400, 329);
            this.Controls.Add(this.chatSendMessageBtn);
            this.Controls.Add(this.chatMessage);
            this.Controls.Add(this.chatRoom);
            this.Controls.Add(this.userNameEntered);
            this.Controls.Add(this.label1);
            this.Name = "PrivateChat";
            this.Text = "PrivateChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox userNameEntered;
        private System.Windows.Forms.ListBox chatRoom;
        private System.Windows.Forms.TextBox chatMessage;
        private System.Windows.Forms.Button chatSendMessageBtn;
    }
}