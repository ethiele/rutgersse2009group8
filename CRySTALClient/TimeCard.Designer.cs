namespace CRySTALClient
{
    partial class TimeCard
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
            this.PunchInBnt = new System.Windows.Forms.Button();
            this.PunchOutBnt = new System.Windows.Forms.Button();
            this.GetShiftHistory = new System.Windows.Forms.Button();
            this.ShiftHistoryBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PunchInBnt
            // 
            this.PunchInBnt.Location = new System.Drawing.Point(12, 12);
            this.PunchInBnt.Name = "PunchInBnt";
            this.PunchInBnt.Size = new System.Drawing.Size(75, 23);
            this.PunchInBnt.TabIndex = 0;
            this.PunchInBnt.Text = "Punch In";
            this.PunchInBnt.UseVisualStyleBackColor = true;
            this.PunchInBnt.Click += new System.EventHandler(this.PunchInBnt_Click);
            // 
            // PunchOutBnt
            // 
            this.PunchOutBnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PunchOutBnt.Location = new System.Drawing.Point(93, 12);
            this.PunchOutBnt.Name = "PunchOutBnt";
            this.PunchOutBnt.Size = new System.Drawing.Size(75, 23);
            this.PunchOutBnt.TabIndex = 1;
            this.PunchOutBnt.Text = "Punch Out";
            this.PunchOutBnt.UseVisualStyleBackColor = true;
            this.PunchOutBnt.Click += new System.EventHandler(this.PunchOutBnt_Click);
            // 
            // GetShiftHistory
            // 
            this.GetShiftHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GetShiftHistory.Location = new System.Drawing.Point(12, 41);
            this.GetShiftHistory.Name = "GetShiftHistory";
            this.GetShiftHistory.Size = new System.Drawing.Size(156, 23);
            this.GetShiftHistory.TabIndex = 2;
            this.GetShiftHistory.Text = "Get Shift History";
            this.GetShiftHistory.UseVisualStyleBackColor = true;
            this.GetShiftHistory.Click += new System.EventHandler(this.GetShiftHistory_Click);
            // 
            // ShiftHistoryBox
            // 
            this.ShiftHistoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ShiftHistoryBox.FormattingEnabled = true;
            this.ShiftHistoryBox.Location = new System.Drawing.Point(12, 70);
            this.ShiftHistoryBox.Name = "ShiftHistoryBox";
            this.ShiftHistoryBox.Size = new System.Drawing.Size(156, 186);
            this.ShiftHistoryBox.TabIndex = 3;
            // 
            // TimeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 264);
            this.Controls.Add(this.ShiftHistoryBox);
            this.Controls.Add(this.GetShiftHistory);
            this.Controls.Add(this.PunchOutBnt);
            this.Controls.Add(this.PunchInBnt);
            this.Name = "TimeCard";
            this.Text = "TimeCard";
            this.Load += new System.EventHandler(this.TimeCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PunchInBnt;
        private System.Windows.Forms.Button PunchOutBnt;
        private System.Windows.Forms.Button GetShiftHistory;
        private System.Windows.Forms.ListBox ShiftHistoryBox;
    }
}