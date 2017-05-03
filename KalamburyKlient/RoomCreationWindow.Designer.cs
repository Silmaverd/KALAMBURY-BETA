namespace KalamburyKlient
{
    partial class RoomCreationWindow
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
            this.LBL_ROOM_NAME = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_ROOM_NAME
            // 
            this.LBL_ROOM_NAME.AutoSize = true;
            this.LBL_ROOM_NAME.Location = new System.Drawing.Point(13, 13);
            this.LBL_ROOM_NAME.Name = "LBL_ROOM_NAME";
            this.LBL_ROOM_NAME.Size = new System.Drawing.Size(158, 16);
            this.LBL_ROOM_NAME.TabIndex = 0;
            this.LBL_ROOM_NAME.Text = "Podaj nazwę pokoju:";
            // 
            // roomName
            // 
            this.roomName.Location = new System.Drawing.Point(177, 10);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(215, 23);
            this.roomName.TabIndex = 1;
            // 
            // submitBtn
            // 
            this.submitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.submitBtn.ForeColor = System.Drawing.Color.Green;
            this.submitBtn.Location = new System.Drawing.Point(271, 39);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(121, 33);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Stwórz!";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // RoomCreationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(414, 75);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.LBL_ROOM_NAME);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RoomCreationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utwórz pokój!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_ROOM_NAME;
        private System.Windows.Forms.TextBox roomName;
        private System.Windows.Forms.Button submitBtn;
    }
}