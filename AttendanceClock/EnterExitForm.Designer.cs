
namespace AttendanceClock
{
    partial class EnterExitForm
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
            this.showClockTimer = new System.Windows.Forms.Timer(this.components);
            this.clockLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentStatus = new System.Windows.Forms.Label();
            this.loggedDurationLabel = new System.Windows.Forms.Label();
            this.setTimeStampButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.goAdminButton = new System.Windows.Forms.Button();
            this.logOutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // showClockTimer
            // 
            this.showClockTimer.Enabled = true;
            this.showClockTimer.Interval = 1000;
            this.showClockTimer.Tick += new System.EventHandler(this.showClockTimer_Tick);
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockLabel.Location = new System.Drawing.Point(222, 98);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(56, 24);
            this.clockLabel.TabIndex = 2;
            this.clockLabel.Text = "--:--:--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time:";
            // 
            // currentStatus
            // 
            this.currentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStatus.Location = new System.Drawing.Point(12, 163);
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(378, 25);
            this.currentStatus.TabIndex = 3;
            this.currentStatus.Text = "checking...";
            this.currentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loggedDurationLabel
            // 
            this.loggedDurationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loggedDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggedDurationLabel.Location = new System.Drawing.Point(12, 213);
            this.loggedDurationLabel.Name = "loggedDurationLabel";
            this.loggedDurationLabel.Size = new System.Drawing.Size(378, 69);
            this.loggedDurationLabel.TabIndex = 4;
            this.loggedDurationLabel.Text = "checking...";
            this.loggedDurationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // setTimeStampButton
            // 
            this.setTimeStampButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setTimeStampButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setTimeStampButton.Location = new System.Drawing.Point(120, 310);
            this.setTimeStampButton.Name = "setTimeStampButton";
            this.setTimeStampButton.Size = new System.Drawing.Size(158, 52);
            this.setTimeStampButton.TabIndex = 5;
            this.setTimeStampButton.Text = "button1";
            this.setTimeStampButton.UseVisualStyleBackColor = true;
            this.setTimeStampButton.Click += new System.EventHandler(this.setTimeStampButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(378, 55);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Hello";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // goAdminButton
            // 
            this.goAdminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goAdminButton.Location = new System.Drawing.Point(120, 377);
            this.goAdminButton.Name = "goAdminButton";
            this.goAdminButton.Size = new System.Drawing.Size(158, 32);
            this.goAdminButton.TabIndex = 6;
            this.goAdminButton.Text = "Get reports";
            this.goAdminButton.UseVisualStyleBackColor = true;
            this.goAdminButton.Click += new System.EventHandler(this.goAdminButton_Click);
            // 
            // logOutLinkLabel
            // 
            this.logOutLinkLabel.AutoSize = true;
            this.logOutLinkLabel.Location = new System.Drawing.Point(334, 417);
            this.logOutLinkLabel.Name = "logOutLinkLabel";
            this.logOutLinkLabel.Size = new System.Drawing.Size(60, 17);
            this.logOutLinkLabel.TabIndex = 7;
            this.logOutLinkLabel.TabStop = true;
            this.logOutLinkLabel.Text = "Sign out";
            this.logOutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logOutLinkLabel_LinkClicked);
            // 
            // EnterExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 443);
            this.Controls.Add(this.logOutLinkLabel);
            this.Controls.Add(this.goAdminButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.setTimeStampButton);
            this.Controls.Add(this.loggedDurationLabel);
            this.Controls.Add(this.currentStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clockLabel);
            this.MinimumSize = new System.Drawing.Size(420, 490);
            this.Name = "EnterExitForm";
            this.Text = "Enter & Exit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer showClockTimer;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentStatus;
        private System.Windows.Forms.Label loggedDurationLabel;
        private System.Windows.Forms.Button setTimeStampButton;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button goAdminButton;
        private System.Windows.Forms.LinkLabel logOutLinkLabel;
    }
}