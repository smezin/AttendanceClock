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
    public partial class EnterExitForm : Form
    {
        public User user { get; }
        private string currentSession = "";
        public EnterExitForm(User user)
        {
            this.user = user;
            InitializeComponent();
            headerLabel.Text = $"Hello {user.userFirstName}";
            if (user.accessLevel == 1)
                goAdminButton.Enabled = true;
            else
                goAdminButton.Enabled = false;
            
        }
        private void showClockTimer_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToLongTimeString();
            
            this.currentStatus.Text = $"Entered on: {user.getOpenEntry()}";
            if (this.user.getOpenEntry() != null)
            {
                setTimeStampButton.Text = "Log out";
                TimeSpan logDurtion = (TimeSpan)(DateTime.Now - this.user.getOpenEntry());
                string days = logDurtion.Days > 0 ? $"{logDurtion.Days} days and " : "";
                string hours =  logDurtion.Hours < 10 ? $"0{logDurtion.Hours}" : $"{logDurtion.Hours}";
                string minutes = logDurtion.Minutes < 10 ? $"0{logDurtion.Minutes}" : $"{logDurtion.Minutes}";
                string seconds = logDurtion.Seconds < 10 ? $"0{logDurtion.Seconds}" : $"{logDurtion.Seconds}";
                this.currentSession = $"{days} {hours}h:{minutes}m:{seconds}s";
                loggedDurationLabel.Text = this.currentSession;
            }
            else
            {
                setTimeStampButton.Text = "Log in";
                this.currentStatus.Text = "Currently not logged in";
                loggedDurationLabel.Text = this.currentSession != "" ? $"you were logged for:\n {this.currentSession}" : "";
            }        
 
        }

        private void setTimeStampButton_Click(object sender, EventArgs e)
        {
            string type = this.user.getOpenEntry() != null ? "exit" : "entry";
            this.user.setTimeStamp();
        }

        private void goAdminButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminReportsForm adminReportsForm = new AdminReportsForm();
            adminReportsForm.StartPosition = FormStartPosition.CenterScreen;
            adminReportsForm.ShowDialog();
        }

        private void logOutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignInForm signInForm = new SignInForm(user.userName);
            signInForm.StartPosition = FormStartPosition.CenterScreen;
            signInForm.ShowDialog();
        }
    }
}
