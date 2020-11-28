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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void goToSignInLinkedLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            this.Hide();
            signInForm.StartPosition = FormStartPosition.CenterScreen;
            signInForm.ShowDialog();
        }

        private void signUpBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            string reEnterPassword = reEnterPasswordTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            bool isValidData = DataValidator.isValidUserName(userName) &&
                               DataValidator.isValidPassword(password, reEnterPassword) &&
                               DataValidator.isValidName(firstName) &&
                               DataValidator.isValidName(lastName);
            if (!isValidData)
            {
                MessageBox.Show("Some of the data is invalid. \n " +
                    "All fields are required and has to be 4 to 16 chars long", 
                    "Please check form");
                return;
            } else if (!DataValidator.isUserNameFree(userName))
            {
                MessageBox.Show("User name is already taken by another user",
                    "Please try another user name");
                return;
            }

            User.addNewUserToDb(userName, firstName, lastName, password);
            e.Result = userName;
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            signUpButton.Enabled = false;
            signUpBackgroundWorker.RunWorkerAsync();
        }

        private void signUpBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            signUpButton.Enabled = true;
            if (e.Result != null)
            {
                this.Hide();
                SignInForm signInForm = new SignInForm(e.Result.ToString());
                signInForm.StartPosition = FormStartPosition.CenterScreen;
                signInForm.ShowDialog();
            }
        }
    }
}
