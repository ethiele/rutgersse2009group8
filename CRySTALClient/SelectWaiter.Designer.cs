namespace CRySTALClient
{
    partial class SelectWaiter
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
            this.cancelBnt = new System.Windows.Forms.Button();
            this.okbnt = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cancelBnt
            // 
            this.cancelBnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBnt.Location = new System.Drawing.Point(12, 112);
            this.cancelBnt.Name = "cancelBnt";
            this.cancelBnt.Size = new System.Drawing.Size(75, 23);
            this.cancelBnt.TabIndex = 0;
            this.cancelBnt.Text = "Cancel";
            this.cancelBnt.UseVisualStyleBackColor = true;
            this.cancelBnt.Click += new System.EventHandler(this.cancelBnt_Click);
            // 
            // okbnt
            // 
            this.okbnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okbnt.Location = new System.Drawing.Point(130, 112);
            this.okbnt.Name = "okbnt";
            this.okbnt.Size = new System.Drawing.Size(75, 23);
            this.okbnt.TabIndex = 1;
            this.okbnt.Text = "Ok";
            this.okbnt.UseVisualStyleBackColor = true;
            this.okbnt.Click += new System.EventHandler(this.okbnt_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 9);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 95);
            this.listBox1.TabIndex = 2;
            // 
            // SelectWaiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 147);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.okbnt);
            this.Controls.Add(this.cancelBnt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SelectWaiter";
            this.Text = "Select Waiter";
            this.Load += new System.EventHandler(this.SelectWaiter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBnt;
        private System.Windows.Forms.Button okbnt;
        private System.Windows.Forms.ListBox listBox1;
    }
}