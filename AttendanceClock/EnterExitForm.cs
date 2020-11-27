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
        public EnterExitForm(User user)
        {
            this.user = user;
            InitializeComponent();
            headerLabel.Text = $"Hello {user.userFirstName}";
        }

        private void showClockTimer_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToLongTimeString();
            this.currentStatus.Text = $"Entered on: {user.getOpenEntry()}";
            if (this.user.getOpenEntry() != null)
            {
                setTimeStampButton.Text = "Log out";
                TimeSpan loggedFor = (TimeSpan)(DateTime.Now - this.user.getOpenEntry());
                string days = loggedFor.Days > 0 ? $"{loggedFor.Days} days and " : "";
                string hours = loggedFor.Hours < 10 ? $"0{loggedFor.Hours}" : $"{loggedFor.Hours}";
                string minutes = loggedFor.Minutes < 10 ? $"0{loggedFor.Minutes}" : $"{loggedFor.Minutes}";
                string seconds = loggedFor.Seconds < 10 ? $"0{loggedFor.Seconds}" : $"{loggedFor.Seconds}";
                loggedDurationLabel.Text = ($"{days} {hours}:{minutes}:{seconds}");
            }
            else
            {
                setTimeStampButton.Text = "Log in";
                this.currentStatus.Text = "Currently not logged in";
                loggedDurationLabel.Text = "";
            }
            
            
        }

        private void setTimeStampButton_Click(object sender, EventArgs e)
        {
            string type = this.user.getOpenEntry() != null ? "exit" : "entry";
            this.user.setTimeStamp();
        }
    }
}
