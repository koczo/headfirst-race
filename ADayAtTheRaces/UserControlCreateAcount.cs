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
    public partial class UserControlCreateAcount : UserControl
    {
        public event EventHandler CreatAcountButtonClicked;
        //public event EventHandler CancelButtonClicked;

        public UserControlCreateAcount()
        {
            InitializeComponent();
        }

        private void buttonCreateAcount_Click(object sender, EventArgs e)
        {
            this.CreatAcountButtonClicked(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.CreatAcountButtonClicked(sender, e);
        }

        private void textBoxRepeatPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelRepeatPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
