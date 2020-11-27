
namespace AttendanceClock
{
    partial class AdminReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userNamesComboBox = new System.Windows.Forms.ComboBox();
            this.userNamesDataSet = new AttendanceClock.UserNamesDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new AttendanceClock.UserNamesDataSetTableAdapters.UsersTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.upToLabel = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.upToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showAllUsersCheckBox = new System.Windows.Forms.CheckBox();
            this.fromAnyCheckBox = new System.Windows.Forms.CheckBox();
            this.untilTodayCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.userNamesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // userNamesComboBox
            // 
            this.userNamesComboBox.DataSource = this.usersBindingSource;
            this.userNamesComboBox.DisplayMember = "userName";
            this.userNamesComboBox.FormattingEnabled = true;
            this.userNamesComboBox.Location = new System.Drawing.Point(160, 54);
            this.userNamesComboBox.Name = "userNamesComboBox";
            this.userNamesComboBox.Size = new System.Drawing.Size(131, 24);
            this.userNamesComboBox.TabIndex = 0;
            // 
            // userNamesDataSet
            // 
            this.userNamesDataSet.DataSetName = "UserNamesDataSet";
            this.userNamesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.userNamesDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show report for:";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(314, 54);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(53, 20);
            this.fromLabel.TabIndex = 2;
            this.fromLabel.Text = "From:";
            // 
            // upToLabel
            // 
            this.upToLabel.AutoSize = true;
            this.upToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upToLabel.Location = new System.Drawing.Point(603, 54);
            this.upToLabel.Name = "upToLabel";
            this.upToLabel.Size = new System.Drawing.Size(54, 20);
            this.upToLabel.TabIndex = 3;
            this.upToLabel.Text = "Up to:";
            this.upToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Location = new System.Drawing.Point(373, 54);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.fromDateTimePicker.TabIndex = 4;
            // 
            // upToDateTimePicker
            // 
            this.upToDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upToDateTimePicker.Location = new System.Drawing.Point(663, 55);
            this.upToDateTimePicker.Name = "upToDateTimePicker";
            this.upToDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.upToDateTimePicker.TabIndex = 5;
            // 
            // showAllUsersCheckBox
            // 
            this.showAllUsersCheckBox.AutoSize = true;
            this.showAllUsersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllUsersCheckBox.Location = new System.Drawing.Point(29, 91);
            this.showAllUsersCheckBox.Name = "showAllUsersCheckBox";
            this.showAllUsersCheckBox.Size = new System.Drawing.Size(127, 22);
            this.showAllUsersCheckBox.TabIndex = 6;
            this.showAllUsersCheckBox.Text = "Show all users";
            this.showAllUsersCheckBox.UseVisualStyleBackColor = true;
            // 
            // fromAnyCheckBox
            // 
            this.fromAnyCheckBox.AutoSize = true;
            this.fromAnyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromAnyCheckBox.Location = new System.Drawing.Point(373, 91);
            this.fromAnyCheckBox.Name = "fromAnyCheckBox";
            this.fromAnyCheckBox.Size = new System.Drawing.Size(125, 22);
            this.fromAnyCheckBox.TabIndex = 7;
            this.fromAnyCheckBox.Text = "From any date";
            this.fromAnyCheckBox.UseVisualStyleBackColor = true;
            // 
            // untilTodayCheckBox
            // 
            this.untilTodayCheckBox.AutoSize = true;
            this.untilTodayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.untilTodayCheckBox.Location = new System.Drawing.Point(663, 91);
            this.untilTodayCheckBox.Name = "untilTodayCheckBox";
            this.untilTodayCheckBox.Size = new System.Drawing.Size(99, 22);
            this.untilTodayCheckBox.TabIndex = 8;
            this.untilTodayCheckBox.Text = "Until today";
            this.untilTodayCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdminReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 450);
            this.Controls.Add(this.untilTodayCheckBox);
            this.Controls.Add(this.fromAnyCheckBox);
            this.Controls.Add(this.showAllUsersCheckBox);
            this.Controls.Add(this.upToDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.upToLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userNamesComboBox);
            this.Name = "AdminReportsForm";
            this.Text = "Admin reports";
            this.Load += new System.EventHandler(this.AdminReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userNamesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox userNamesComboBox;
        private UserNamesDataSet userNamesDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private UserNamesDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label upToLabel;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker upToDateTimePicker;
        private System.Windows.Forms.CheckBox showAllUsersCheckBox;
        private System.Windows.Forms.CheckBox fromAnyCheckBox;
        private System.Windows.Forms.CheckBox untilTodayCheckBox;
    }
}