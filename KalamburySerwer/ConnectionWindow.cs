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
    public partial class ConnectionWindow : Form
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }
        private void acceptInfoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string GetIpAddress()
        {
            return this.IpAddressField.Text;
        }
        public int GetPort()
        {
            return Convert.ToInt32(this.PortField.Text);
        }
        public int GetMaxPlayers()
        {
            return Convert.ToInt32(this.MaxPlayersField.Text);
        }
    }
}
