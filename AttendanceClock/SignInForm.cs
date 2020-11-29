using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AttendanceClock
{
    public partial class SignInForm : Form
    {
        public SignInForm(string userName = "")
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            userNameTextBox.Text = userName;
        }

        private void goToSignUpLinkedLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            Hide();
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
                Hide();
                EnterExitForm enterExitForm = new EnterExitForm(user);
                enterExitForm.StartPosition = FormStartPosition.CenterScreen;
                enterExitForm.ShowDialog();
            }
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                signInButton_Click(sender, e);
            }
        }

        private void userNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                passwordTextBox.Focus();
            }
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            setTablesBackgroundWorker.RunWorkerAsync();
        }

        private void setTablesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DbAbstractionLayer.setUpUsersTable();
            DbAbstractionLayer.setUpEntryLogTable();
        }
    }
}
