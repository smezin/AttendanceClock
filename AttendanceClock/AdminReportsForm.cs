using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace AttendanceClock
{
    public partial class AdminReportsForm : Form
    {
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        public AdminReportsForm()
        {
            InitializeComponent();
            upToDateTimePicker.MaxDate = DateTime.Now;
            fromDateTimePicker.MaxDate = DateTime.Now;
            
            
        }

        private void AdminReportsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            List<string> users = Search.getAllUsers();
            users.ForEach(delegate (String user)
            {
                usersComboBox.Items.Add(user);
            });
            usersComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void showAllUsersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            usersComboBox.Enabled = !usersComboBox.Enabled;
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
            string userName = showAllUsersCheckBox.Checked ? "all" : usersComboBox.Text;
            DateTime? from = null, upTo = null;
            if (!fromAnyCheckBox.Checked)
                from = fromDateTimePicker.Value;
            if (!untilTodayCheckBox.Checked)
                upTo = upToDateTimePicker.Value;
            Search search = new Search(from, upTo, userName);
            bindingSource1.DataSource = search.searchResult;
            for (int i = 0; i <= dataGridView1.ColumnCount - 2; i++)            
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[dataGridView1.ColumnCount-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void usersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void logOutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignInForm signInForm = new SignInForm();
            signInForm.StartPosition = FormStartPosition.CenterScreen;
            signInForm.ShowDialog();
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            upToDateTimePicker.MinDate = fromDateTimePicker.Value;
        }

        private void upToDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDateTimePicker.MaxDate = upToDateTimePicker.Value;
        }
    }
}
