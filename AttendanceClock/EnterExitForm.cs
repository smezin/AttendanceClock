using System;
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

            currentStatus.Text = $"Entered on: {DbAbstractionLayer.getOpenEntry(user.userName)}";
            if (DbAbstractionLayer.getOpenEntry(user.userName) != null)
            {
                setTimeStampButton.Text = "Log out";
                TimeSpan logDurtion = (TimeSpan)(DateTime.Now - DbAbstractionLayer.getOpenEntry(user.userName));
                string days = logDurtion.Days > 0 ? $"{logDurtion.Days} days and " : "";
                string hours = logDurtion.Hours < 10 ? $"0{logDurtion.Hours}" : $"{logDurtion.Hours}";
                string minutes = logDurtion.Minutes < 10 ? $"0{logDurtion.Minutes}" : $"{logDurtion.Minutes}";
                string seconds = logDurtion.Seconds < 10 ? $"0{logDurtion.Seconds}" : $"{logDurtion.Seconds}";
                currentSession = $"{days} {hours}h:{minutes}m:{seconds}s";
                loggedDurationLabel.Text = currentSession;
            }
            else
            {
                setTimeStampButton.Text = "Log in";
                currentStatus.Text = "Currently not logged in";
                loggedDurationLabel.Text = currentSession != "" ? $"you were logged for:\n {currentSession}" : "";
            }
        }

        private void setTimeStampButton_Click(object sender, EventArgs e)
        {
            string type = DbAbstractionLayer.getOpenEntry(user.userName) != null ? "exit" : "entry";
            DbAbstractionLayer.setTimeStamp(user.userName);
        }

        private void goAdminButton_Click(object sender, EventArgs e)
        {
            Hide();
            AdminReportsForm adminReportsForm = new AdminReportsForm();
            adminReportsForm.StartPosition = FormStartPosition.CenterScreen;
            adminReportsForm.ShowDialog();
        }

        private void logOutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            SignInForm signInForm = new SignInForm(user.userName);
            signInForm.StartPosition = FormStartPosition.CenterScreen;
            signInForm.ShowDialog();
        }
    }
}
