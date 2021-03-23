using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SongsAndVotesCommon.Interfaces;

namespace SongsAndVotesAdmin.Formulare
{
    public partial class LoginForm : Form
    {
        SongsAndVotesCommon.Repos.UserRepo userRepo = new SongsAndVotesCommon.Repos.UserRepo();

        public LoginForm(bool b)
        {
            InitializeComponent();
            if(b == true)
            {
                textBoxUsername.BackColor = Color.Red;
                textBoxPassword.BackColor = Color.Red;
            }
        }

        public void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SongsAndVotesCommon.BusinessObjects.User user = new 
                SongsAndVotesCommon.BusinessObjects.User(Convert.ToString(textBoxUsername), Convert.ToString(textBoxPassword));
            if(userRepo.Exists(user) == true)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                this.Hide();
                //this.Close();
                ErrorForm errorForm = new ErrorForm();
                errorForm.ShowDialog();
            }
        }
    }
}
