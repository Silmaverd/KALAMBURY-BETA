namespace KalamburySerwer
{
    partial class KickReasonWindow
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
            this.LBL_PLAYER_KICK_REASON = new System.Windows.Forms.Label();
            this.playerKickReason = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_PLAYER_KICK_REASON
            // 
            this.LBL_PLAYER_KICK_REASON.AutoSize = true;
            this.LBL_PLAYER_KICK_REASON.Location = new System.Drawing.Point(13, 13);
            this.LBL_PLAYER_KICK_REASON.Name = "LBL_PLAYER_KICK_REASON";
            this.LBL_PLAYER_KICK_REASON.Size = new System.Drawing.Size(110, 16);
            this.LBL_PLAYER_KICK_REASON.TabIndex = 0;
            this.LBL_PLAYER_KICK_REASON.Text = "Podaj powód: ";
            // 
            // playerKickReason
            // 
            this.playerKickReason.Location = new System.Drawing.Point(141, 13);
            this.playerKickReason.Name = "playerKickReason";
            this.playerKickReason.Size = new System.Drawing.Size(421, 23);
            this.playerKickReason.TabIndex = 1;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(402, 42);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(160, 23);
            this.confirmBtn.TabIndex = 2;
            this.confirmBtn.Text = "Potwierdź.";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // KickReasonWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(574, 71);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.playerKickReason);
            this.Controls.Add(this.LBL_PLAYER_KICK_REASON);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "KickReasonWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Powód wyrzucenia gracza.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_PLAYER_KICK_REASON;
        private System.Windows.Forms.TextBox playerKickReason;
        private System.Windows.Forms.Button confirmBtn;
    }
}