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
            if (user.isLoggedIn())
            {
                this.currentStatus.Text = $"Entered on: {user.getOpenEntry()}";
            }
            else
            {
                this.currentStatus.Text = "Currently not logged in";
            }            
        }

        private void showClockTimer_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToLongTimeString();
            
            TimeSpan loggedFor = (TimeSpan)(DateTime.Now - this.user.getOpenEntry());
            string days = loggedFor.Days > 0 ? $"{loggedFor.Days} days and " : "";
            loggedDurationLabel.Text = ($"{days}" +
                $"{loggedFor.Hours}:{loggedFor.Minutes}:{loggedFor.Seconds}");
            
        }

        private void setTimeStampButton_Click(object sender, EventArgs e)
        {
            string type = this.user.isLoggedIn() ? "exit" : "entry";
            this.user.setTimeStamp();
        }
    }
}
