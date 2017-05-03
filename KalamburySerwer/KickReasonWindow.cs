using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburySerwer
{
    public partial class KickReasonWindow : Form
    {
        public KickReasonWindow()
        {
            InitializeComponent();
        }

        public string GetKickReason()
        {
            return this.playerKickReason.Text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
