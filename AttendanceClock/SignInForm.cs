using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
    


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
            e.Result = isValid ? user : null;
        }

        private void signInBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            signInButton.Enabled = true;
            User user = (User)e.Result;
            //goto next form
            if (user == null)
            {
                MessageBox.Show("Invalid user name or password", "Can not sign in");
            } 
            else
            {
                if (user.accessLevel == 0)
                {
                    this.Hide();
                    EnterExitForm enterExitForm = new EnterExitForm(user);
                    enterExitForm.StartPosition = FormStartPosition.CenterScreen;
                    enterExitForm.ShowDialog();
                }
                else if (user.accessLevel == 1)
                {
                    this.Hide();
                    AdminReportsForm adminMenuForm = new AdminReportsForm();
                    adminMenuForm.StartPosition = FormStartPosition.CenterScreen;
                    adminMenuForm.ShowDialog();
                }
            }
        }
    }
}
