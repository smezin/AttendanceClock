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
    public partial class AdminReportsForm : Form
    {
        public AdminReportsForm()
        {
            InitializeComponent();
        }

        private void AdminReportsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userNamesDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.userNamesDataSet.Users);

        }

        private void showAllUsersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            userNamesComboBox.Enabled = !userNamesComboBox.Enabled;
        }

        private void fromAnyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fromDateTimePicker.Enabled = !fromDateTimePicker.Enabled;
        }

        private void untilTodayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            upToDateTimePicker.Enabled = !upToDateTimePicker.Enabled;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string userName = showAllUsersCheckBox.Checked ? null : userNamesComboBox.Text;
            DateTime? from = null, upTo = null;
            if (!fromAnyCheckBox.Checked)
                from = fromDateTimePicker.Value;
            if (!untilTodayCheckBox.Checked)
                upTo = upToDateTimePicker.Value;
            Search search = new Search(from, upTo, userName);
        }
    }
}
