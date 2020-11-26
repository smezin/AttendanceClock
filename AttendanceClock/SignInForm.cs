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
            User user = new User();
            //user.addNewUser("Lmezin", "reef", "mezin", "123123");
            //user.getUserLastName("smezin");
            //user.validatePassword()
            bool isValid = user.validatePassword("123124", "j6NfaRAsRprdOqzV2Hw039UTIW4V6oaAqbV/Ntame+tWuZGT");
            if (isValid)
                MessageBox.Show("ok");
            else
                MessageBox.Show("bad");

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
