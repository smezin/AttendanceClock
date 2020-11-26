using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    


namespace AttendanceClock
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void goToSignUpLinkedLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            this.Hide();
            signUpForm.StartPosition = FormStartPosition.CenterScreen;
            signUpForm.ShowDialog();
        }
        private void signInButton_Click(object sender, EventArgs e)
        {
            signInButton.Enabled = false;
            signInBackgroundWorker.RunWorkerAsync();
        }       
        private void signInBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            string userName = userNameTextBox.Text;         
            string password = passwordTextBox.Text;
            User user = new User(userName, password);
            bool isValid = user.userName != null;
            if (isValid)
            {              
                e.Result = user;
                MessageBox.Show("granted");
            }
            else
            {
                MessageBox.Show("Invalid user name or password", "Can not sign in");
                e.Result = null;
            }
        }

        private void signInBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            signInButton.Enabled = true;
            User user = (User)e.Result;
            //goto next form
        }
        private bool isValidUserName (string userName)
        {
            return (userName.Length >= 4 && 
                    userName.Length <= 16 &&
                    !userName.Contains("(") && 
                    !userName.Contains(")"));           
        }
        private bool isValidPassword (string password)
        {
            return (password.Length >= 4 &&
                    password.Length <= 16 &&
                    !password.Contains("(") &&
                    !password.Contains(")"));
        }
    }
}
