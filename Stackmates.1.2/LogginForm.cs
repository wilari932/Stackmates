using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stackmates._1._2
{
    public partial class LogginForm : Form
    {
        RegisterForm OpenRegister;
        DatabaseHandler HandleData = new DatabaseHandler();

        public LogginForm()
        {
            InitializeComponent();
        }

        private void Button_SingIn_Click(object sender, EventArgs e)
        {
            OpenRegister = new RegisterForm();
            OpenRegister.Show();
            this.Hide();
        }

        private void Button_Loggin_Click(object sender, EventArgs e)
        {
            if(HandleData.UserLogin(TxtBox_Username.Text, TxtBox_Password.Text))
            {
                UserPage open = new UserPage();
                open.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
