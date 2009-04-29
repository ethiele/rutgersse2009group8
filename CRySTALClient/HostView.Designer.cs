namespace CRySTALClient
{
    partial class HostView
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
            this.Tbl1 = new System.Windows.Forms.Button();
            this.Tbl2 = new System.Windows.Forms.Button();
            this.Tbl3 = new System.Windows.Forms.Button();
            this.Tbl4 = new System.Windows.Forms.Button();
            this.Tbl6 = new System.Windows.Forms.Button();
            this.Tbl5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tbl1
            // 
            this.Tbl1.BackColor = System.Drawing.Color.LightGreen;
            this.Tbl1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tbl1.Location = new System.Drawing.Point(39, 111);
            this.Tbl1.Name = "Tbl1";
            this.Tbl1.Size = new System.Drawing.Size(76, 62);
            this.Tbl1.TabIndex = 0;
            this.Tbl1.Tag = "1";
            this.Tbl1.Text = "Table 1";
            this.Tbl1.UseVisualStyleBackColor = false;
            // 
            // Tbl2
            // 
            this.Tbl2.BackColor = System.Drawing.Color.LightGreen;
            this.Tbl2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tbl2.Location = new System.Drawing.Point(134, 29);
            this.Tbl2.Name = "Tbl2";
            this.Tbl2.Size = new System.Drawing.Size(76, 62);
            this.Tbl2.TabIndex = 1;
            this.Tbl2.Tag = "2";
            this.Tbl2.Text = "Table 2";
            this.Tbl2.UseVisualStyleBackColor = false;
            this.Tbl2.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tbl3
            // 
            this.Tbl3.BackColor = System.Drawing.Color.LightGreen;
            this.Tbl3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tbl3.Location = new System.Drawing.Point(238, 29);
            this.Tbl3.Name = "Tbl3";
            this.Tbl3.Size = new System.Drawing.Size(76, 62);
            this.Tbl3.TabIndex = 2;
            this.Tbl3.Tag = "3";
            this.Tbl3.Text = "Table 3";
            this.Tbl3.UseVisualStyleBackColor = false;
            // 
            // Tbl4
            // 
            this.Tbl4.BackColor = System.Drawing.Color.LightGreen;
            this.Tbl4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tbl4.Location = new System.Drawing.Point(336, 122);
            this.Tbl4.Name = "Tbl4";
            this.Tbl4.Size = new System.Drawing.Size(76, 62);
            this.Tbl4.TabIndex = 3;
            this.Tbl4.Tag = "4";
            this.Tbl4.Text = "Table 4";
            this.Tbl4.UseVisualStyleBackColor = false;
            // 
            // Tbl6
            // 
            this.Tbl6.BackColor = System.Drawing.Color.LightGreen;
            this.Tbl6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tbl6.Location = new System.Drawing.Point(134, 209);
            this.Tbl6.Name = "Tbl6";
            this.Tbl6.Size = new System.Drawing.Size(76, 62);
            this.Tbl6.TabIndex = 4;
            this.Tbl6.Tag = "6";
            this.Tbl6.Text = "Table 6";
            this.Tbl6.UseVisualStyleBackColor = false;
            // 
            // Tbl5
            // 
            this.Tbl5.BackColor = System.Drawing.Color.LightGreen;
            this.Tbl5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tbl5.Location = new System.Drawing.Point(238, 209);
            this.Tbl5.Name = "Tbl5";
            this.Tbl5.Size = new System.Drawing.Size(76, 62);
            this.Tbl5.TabIndex = 5;
            this.Tbl5.Tag = "5";
            this.Tbl5.Text = "Table 5";
            this.Tbl5.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // HostView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 279);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tbl5);
            this.Controls.Add(this.Tbl6);
            this.Controls.Add(this.Tbl4);
            this.Controls.Add(this.Tbl3);
            this.Controls.Add(this.Tbl2);
            this.Controls.Add(this.Tbl1);
            this.Name = "HostView";
            this.Text = "Host View - ";
            this.Load += new System.EventHandler(this.HostView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Tbl1;
        private System.Windows.Forms.Button Tbl2;
        private System.Windows.Forms.Button Tbl3;
        private System.Windows.Forms.Button Tbl4;
        private System.Windows.Forms.Button Tbl6;
        private System.Windows.Forms.Button Tbl5;
        private System.Windows.Forms.Button button1;
    }
}