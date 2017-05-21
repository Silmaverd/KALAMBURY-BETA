using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalamburyKlient
{
    public partial class RoomCreationWindow : Form
    {
        public string ROOM_NAME { set; get; }
        public string TIMER_VALUE { set; get; }

        public RoomCreationWindow()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            this.ROOM_NAME = this.roomName.Text;
            this.TIMER_VALUE = this.timeToAnswer.Text;
            this.Hide();
        }
    }
}
