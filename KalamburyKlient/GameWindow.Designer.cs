namespace KalamburyKlient
{
    partial class GameWindow
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
            this.LBL_ROOM_NAME = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.Label();
            this.drawingDesk = new System.Windows.Forms.PictureBox();
            this.LBL_ROOM_PLAYERS = new System.Windows.Forms.Label();
            this.playersInTheRoom = new System.Windows.Forms.ListBox();
            this.chatRoom = new System.Windows.Forms.ListBox();
            this.chatMessage = new System.Windows.Forms.TextBox();
            this.chatSendMessageBtn = new System.Windows.Forms.Button();
            this.catchwordGetBtn = new System.Windows.Forms.Button();
            this.catchwordField = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.catchwordFoundBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawingDesk)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_USER_NAME
            // 
            this.LBL_USER_NAME.AutoSize = true;
            this.LBL_USER_NAME.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_USER_NAME.Location = new System.Drawing.Point(21, 19);
            this.LBL_USER_NAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_USER_NAME.Name = "LBL_USER_NAME";
            this.LBL_USER_NAME.Size = new System.Drawing.Size(139, 13);
            this.LBL_USER_NAME.TabIndex = 0;
            this.LBL_USER_NAME.Text = "Nazwa użytkownika:";
            // 
            // LBL_ROOM_NAME
            // 
            this.LBL_ROOM_NAME.AutoSize = true;
            this.LBL_ROOM_NAME.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_ROOM_NAME.Location = new System.Drawing.Point(20, 44);
            this.LBL_ROOM_NAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_ROOM_NAME.Name = "LBL_ROOM_NAME";
            this.LBL_ROOM_NAME.Size = new System.Drawing.Size(86, 23);
            this.LBL_ROOM_NAME.TabIndex = 1;
            this.LBL_ROOM_NAME.Text = "Pokój: ";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.userName.Location = new System.Drawing.Point(167, 19);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(0, 13);
            this.userName.TabIndex = 2;
            // 
            // roomName
            // 
            this.roomName.AutoSize = true;
            this.roomName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.roomName.Location = new System.Drawing.Point(113, 44);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(0, 23);
            this.roomName.TabIndex = 3;
            // 
            // drawingDesk
            // 
            this.drawingDesk.BackColor = System.Drawing.Color.LightYellow;
            this.drawingDesk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.drawingDesk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawingDesk.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.drawingDesk.Location = new System.Drawing.Point(12, 125);
            this.drawingDesk.Name = "drawingDesk";
            this.drawingDesk.Size = new System.Drawing.Size(419, 397);
            this.drawingDesk.TabIndex = 4;
            this.drawingDesk.TabStop = false;
            this.drawingDesk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingDesk_MouseDown);
            this.drawingDesk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingDesk_MouseMove);
            this.drawingDesk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingDesk_MouseUp);
            // 
            // LBL_ROOM_PLAYERS
            // 
            this.LBL_ROOM_PLAYERS.AutoSize = true;
            this.LBL_ROOM_PLAYERS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_ROOM_PLAYERS.Location = new System.Drawing.Point(445, 19);
            this.LBL_ROOM_PLAYERS.Name = "LBL_ROOM_PLAYERS";
            this.LBL_ROOM_PLAYERS.Size = new System.Drawing.Size(56, 13);
            this.LBL_ROOM_PLAYERS.TabIndex = 5;
            this.LBL_ROOM_PLAYERS.Text = "Gracze:";
            // 
            // playersInTheRoom
            // 
            this.playersInTheRoom.FormattingEnabled = true;
            this.playersInTheRoom.ItemHeight = 16;
            this.playersInTheRoom.Location = new System.Drawing.Point(448, 44);
            this.playersInTheRoom.Name = "playersInTheRoom";
            this.playersInTheRoom.Size = new System.Drawing.Size(238, 148);
            this.playersInTheRoom.TabIndex = 6;
            // 
            // chatRoom
            // 
            this.chatRoom.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chatRoom.FormattingEnabled = true;
            this.chatRoom.ItemHeight = 12;
            this.chatRoom.Location = new System.Drawing.Point(448, 206);
            this.chatRoom.Name = "chatRoom";
            this.chatRoom.ScrollAlwaysVisible = true;
            this.chatRoom.Size = new System.Drawing.Size(238, 316);
            this.chatRoom.TabIndex = 7;
            this.chatRoom.TabStop = false;
            // 
            // chatMessage
            // 
            this.chatMessage.Location = new System.Drawing.Point(449, 530);
            this.chatMessage.Name = "chatMessage";
            this.chatMessage.Size = new System.Drawing.Size(195, 23);
            this.chatMessage.TabIndex = 8;
            this.chatMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chatMessage_KeyPress);
            // 
            // chatSendMessageBtn
            // 
            this.chatSendMessageBtn.Location = new System.Drawing.Point(650, 530);
            this.chatSendMessageBtn.Name = "chatSendMessageBtn";
            this.chatSendMessageBtn.Size = new System.Drawing.Size(36, 23);
            this.chatSendMessageBtn.TabIndex = 9;
            this.chatSendMessageBtn.Text = ">";
            this.chatSendMessageBtn.UseVisualStyleBackColor = true;
            this.chatSendMessageBtn.Click += new System.EventHandler(this.chatSendMessageBtn_Click);
            // 
            // catchwordGetBtn
            // 
            this.catchwordGetBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.catchwordGetBtn.Location = new System.Drawing.Point(565, 9);
            this.catchwordGetBtn.Name = "catchwordGetBtn";
            this.catchwordGetBtn.Size = new System.Drawing.Size(121, 23);
            this.catchwordGetBtn.TabIndex = 10;
            this.catchwordGetBtn.Text = "LOSUJ!";
            this.catchwordGetBtn.UseVisualStyleBackColor = true;
            this.catchwordGetBtn.Click += new System.EventHandler(this.catchwordGetBtn_Click);
            // 
            // catchwordField
            // 
            this.catchwordField.AutoSize = true;
            this.catchwordField.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.catchwordField.ForeColor = System.Drawing.Color.Firebrick;
            this.catchwordField.Location = new System.Drawing.Point(20, 99);
            this.catchwordField.Name = "catchwordField";
            this.catchwordField.Size = new System.Drawing.Size(0, 23);
            this.catchwordField.TabIndex = 11;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(12, 528);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(101, 27);
            this.clearBtn.TabIndex = 12;
            this.clearBtn.Text = "Wyczyść!";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // catchwordFoundBtn
            // 
            this.catchwordFoundBtn.Location = new System.Drawing.Point(119, 528);
            this.catchwordFoundBtn.Name = "catchwordFoundBtn";
            this.catchwordFoundBtn.Size = new System.Drawing.Size(314, 27);
            this.catchwordFoundBtn.TabIndex = 13;
            this.catchwordFoundBtn.Text = "Hasło odgadnięte!";
            this.catchwordFoundBtn.UseVisualStyleBackColor = true;
            this.catchwordFoundBtn.Click += new System.EventHandler(this.catchwordFoundBtn_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(698, 567);
            this.Controls.Add(this.catchwordFoundBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.catchwordField);
            this.Controls.Add(this.catchwordGetBtn);
            this.Controls.Add(this.chatSendMessageBtn);
            this.Controls.Add(this.chatMessage);
            this.Controls.Add(this.chatRoom);
            this.Controls.Add(this.playersInTheRoom);
            this.Controls.Add(this.LBL_ROOM_PLAYERS);
            this.Controls.Add(this.drawingDesk);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.LBL_ROOM_NAME);
            this.Controls.Add(this.LBL_USER_NAME);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gra!";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.drawingDesk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_USER_NAME;
        private System.Windows.Forms.Label LBL_ROOM_NAME;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label roomName;
        private System.Windows.Forms.PictureBox drawingDesk;
        private System.Windows.Forms.Label LBL_ROOM_PLAYERS;
        private System.Windows.Forms.ListBox playersInTheRoom;
        private System.Windows.Forms.ListBox chatRoom;
        private System.Windows.Forms.TextBox chatMessage;
        private System.Windows.Forms.Button chatSendMessageBtn;
        private System.Windows.Forms.Button catchwordGetBtn;
        private System.Windows.Forms.Label catchwordField;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button catchwordFoundBtn;
    }
}