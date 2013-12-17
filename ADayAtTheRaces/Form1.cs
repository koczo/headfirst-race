using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MetroFramework.Forms;

namespace ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        bool logedin= false;
        MySqlDBConnect db = new MySqlDBConnect();
        UserControlLogin userControlLogin;
        UserControlCreateAcount userControlCreateAcount;
        UserControlMainGame userControlMainGame;

        public Form1()
        {
            InitializeComponent();
            userControlLogin = new UserControlLogin();
            this.Controls.Add(userControlLogin);
            userControlLogin.LinkClicked += userControlLogin_LinkClicked;
            userControlLogin.LoginButtonCliced += userControlLogin_LoginButtonClicked;

            userControlCreateAcount = new UserControlCreateAcount();
            this.Controls.Add(userControlCreateAcount);
            userControlCreateAcount.CreatAcountButtonClicked += userControlCreateAcount_CreatAcountButtonClicked;

            
           
        }

        void userControlCreateAcount_CreatAcountButtonClicked(object sender, EventArgs e)
        {
            DisplayUserControl(userControlLogin);
        }

        void userControlLogin_LoginButtonClicked(object sender, EventArgs e)
        {
            userControlMainGame = new UserControlMainGame();
            userControlMainGame.GamerLogin = userControlLogin.Login;
            this.Controls.Add(userControlMainGame);
            logedin = true;
            this.loginToolStripMenuItem.Text = String.Format("Welcom {0} ! -  Log out !",userControlLogin.Login);
            
            DisplayUserControl(userControlMainGame);
        }

        void userControlLogin_LinkClicked(object sender, EventArgs e)
        {
            DisplayUserControl(userControlCreateAcount);
            
        }

        internal  void DisplayUserControl(UserControl userControl)
        {
            foreach (Control control in this.Controls)
            {
                if (control is UserControl)
                {
                    if (control == userControl)
                    {
                        control.Visible = true;
                        control.Enabled = true;
                        control.BringToFront();
                        control.Dock = DockStyle.Fill;
                    }
                    else 
                    {
                        control.Visible = false;
                        control.Enabled = false;
                        control.Dock = DockStyle.None;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DisplayUserControl(userControlLogin);

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logedin)
            {
                logedin = false;
                loginToolStripMenuItem.Text = "Login";
                this.Controls.Remove(userControlMainGame);
                DisplayUserControl(userControlLogin);
                
            }
            else
                DisplayUserControl(userControlLogin);

        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistic stat = new FormStatistic();
            stat.ShowDialog();
        }


            
    }
}
