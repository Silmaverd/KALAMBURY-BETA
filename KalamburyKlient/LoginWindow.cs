﻿using System;
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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.userNameEntered.TextLength != 0)
                this.Hide();
            else MessageBox.Show("Nazwa użytkownika nie może być pusta!");
        }
    }
}
