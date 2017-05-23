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
            this.chosenColorVisualizer = new System.Windows.Forms.PictureBox();
            this.chosenBLACK = new System.Windows.Forms.PictureBox();
            this.chosenRED = new System.Windows.Forms.PictureBox();
            this.chosenBLUE = new System.Windows.Forms.PictureBox();
            this.chosenGREEN = new System.Windows.Forms.PictureBox();
            this.chosenYELLOW = new System.Windows.Forms.PictureBox();
            this.timerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.drawingDesk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenColorVisualizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenBLACK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenRED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenBLUE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenGREEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenYELLOW)).BeginInit();
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
            this.drawingDesk.Size = new System.Drawing.Size(761, 490);
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
            this.LBL_ROOM_PLAYERS.Location = new System.Drawing.Point(776, 38);
            this.LBL_ROOM_PLAYERS.Name = "LBL_ROOM_PLAYERS";
            this.LBL_ROOM_PLAYERS.Size = new System.Drawing.Size(56, 13);
            this.LBL_ROOM_PLAYERS.TabIndex = 5;
            this.LBL_ROOM_PLAYERS.Text = "Gracze:";
            // 
            // playersInTheRoom
            // 
            this.playersInTheRoom.FormattingEnabled = true;
            this.playersInTheRoom.ItemHeight = 16;
            this.playersInTheRoom.Location = new System.Drawing.Point(779, 54);
            this.playersInTheRoom.Name = "playersInTheRoom";
            this.playersInTheRoom.Size = new System.Drawing.Size(327, 148);
            this.playersInTheRoom.TabIndex = 6;
            // 
            // chatRoom
            // 
            this.chatRoom.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chatRoom.FormattingEnabled = true;
            this.chatRoom.ItemHeight = 12;
            this.chatRoom.Location = new System.Drawing.Point(779, 208);
            this.chatRoom.Name = "chatRoom";
            this.chatRoom.ScrollAlwaysVisible = true;
            this.chatRoom.Size = new System.Drawing.Size(327, 436);
            this.chatRoom.TabIndex = 7;
            this.chatRoom.TabStop = false;
            // 
            // chatMessage
            // 
            this.chatMessage.Location = new System.Drawing.Point(779, 650);
            this.chatMessage.Name = "chatMessage";
            this.chatMessage.Size = new System.Drawing.Size(284, 23);
            this.chatMessage.TabIndex = 8;
            this.chatMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chatMessage_KeyPress);
            // 
            // chatSendMessageBtn
            // 
            this.chatSendMessageBtn.Location = new System.Drawing.Point(1069, 650);
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
            this.catchwordGetBtn.Location = new System.Drawing.Point(933, 12);
            this.catchwordGetBtn.Name = "catchwordGetBtn";
            this.catchwordGetBtn.Size = new System.Drawing.Size(172, 36);
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
            this.clearBtn.Location = new System.Drawing.Point(12, 621);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(101, 52);
            this.clearBtn.TabIndex = 12;
            this.clearBtn.Text = "Wyczyść!";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // chosenColorVisualizer
            // 
            this.chosenColorVisualizer.BackColor = System.Drawing.Color.Black;
            this.chosenColorVisualizer.Location = new System.Drawing.Point(119, 623);
            this.chosenColorVisualizer.Name = "chosenColorVisualizer";
            this.chosenColorVisualizer.Size = new System.Drawing.Size(125, 50);
            this.chosenColorVisualizer.TabIndex = 13;
            this.chosenColorVisualizer.TabStop = false;
            // 
            // chosenBLACK
            // 
            this.chosenBLACK.BackColor = System.Drawing.Color.Black;
            this.chosenBLACK.Location = new System.Drawing.Point(474, 621);
            this.chosenBLACK.Name = "chosenBLACK";
            this.chosenBLACK.Size = new System.Drawing.Size(55, 50);
            this.chosenBLACK.TabIndex = 14;
            this.chosenBLACK.TabStop = false;
            this.chosenBLACK.Click += new System.EventHandler(this.chosenBLACK_Click);
            // 
            // chosenRED
            // 
            this.chosenRED.BackColor = System.Drawing.Color.Red;
            this.chosenRED.Location = new System.Drawing.Point(535, 621);
            this.chosenRED.Name = "chosenRED";
            this.chosenRED.Size = new System.Drawing.Size(55, 50);
            this.chosenRED.TabIndex = 15;
            this.chosenRED.TabStop = false;
            this.chosenRED.Click += new System.EventHandler(this.chosenRED_Click);
            // 
            // chosenBLUE
            // 
            this.chosenBLUE.BackColor = System.Drawing.Color.Blue;
            this.chosenBLUE.Location = new System.Drawing.Point(596, 621);
            this.chosenBLUE.Name = "chosenBLUE";
            this.chosenBLUE.Size = new System.Drawing.Size(55, 50);
            this.chosenBLUE.TabIndex = 16;
            this.chosenBLUE.TabStop = false;
            this.chosenBLUE.Click += new System.EventHandler(this.chosenBLUE_Click);
            // 
            // chosenGREEN
            // 
            this.chosenGREEN.BackColor = System.Drawing.Color.Lime;
            this.chosenGREEN.Location = new System.Drawing.Point(657, 621);
            this.chosenGREEN.Name = "chosenGREEN";
            this.chosenGREEN.Size = new System.Drawing.Size(55, 50);
            this.chosenGREEN.TabIndex = 17;
            this.chosenGREEN.TabStop = false;
            this.chosenGREEN.Click += new System.EventHandler(this.chosenGREEN_Click);
            // 
            // chosenYELLOW
            // 
            this.chosenYELLOW.BackColor = System.Drawing.Color.Yellow;
            this.chosenYELLOW.Location = new System.Drawing.Point(718, 621);
            this.chosenYELLOW.Name = "chosenYELLOW";
            this.chosenYELLOW.Size = new System.Drawing.Size(55, 50);
            this.chosenYELLOW.TabIndex = 18;
            this.chosenYELLOW.TabStop = false;
            this.chosenYELLOW.Click += new System.EventHandler(this.chosenYELLOW_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timerLabel.Location = new System.Drawing.Point(274, 42);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(79, 25);
            this.timerLabel.TabIndex = 19;
            this.timerLabel.Text = "Timer";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1118, 685);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.chosenYELLOW);
            this.Controls.Add(this.chosenGREEN);
            this.Controls.Add(this.chosenBLUE);
            this.Controls.Add(this.chosenRED);
            this.Controls.Add(this.chosenBLACK);
            this.Controls.Add(this.chosenColorVisualizer);
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
            ((System.ComponentModel.ISupportInitialize)(this.chosenColorVisualizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenBLACK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenRED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenBLUE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenGREEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenYELLOW)).EndInit();
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
        private System.Windows.Forms.PictureBox chosenColorVisualizer;
        private System.Windows.Forms.PictureBox chosenBLACK;
        private System.Windows.Forms.PictureBox chosenRED;
        private System.Windows.Forms.PictureBox chosenBLUE;
        private System.Windows.Forms.PictureBox chosenGREEN;
        private System.Windows.Forms.PictureBox chosenYELLOW;
        private System.Windows.Forms.Label timerLabel;
    }
}