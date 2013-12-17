using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public partial class UserControlLogin : UserControl
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public event EventHandler LinkClicked;
        public event EventHandler LoginButtonCliced;
        

        public UserControlLogin()
        {
            InitializeComponent();
            
        }

        private void linkLabelCreateAcount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LinkClicked(sender, e);
        }

        private void UserControlLogin_Load(object sender, EventArgs e)
        {
            this.LoginButtonCliced(sender, e);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login = textBoxLogin.Text;
            this.LoginButtonCliced(sender, e);
        }
    }
}
