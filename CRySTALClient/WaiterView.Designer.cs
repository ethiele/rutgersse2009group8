namespace CRySTALClient
{
    partial class WaiterView
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RequestCheck = new System.Windows.Forms.Button();
            this.AddItemToBill = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PaiedBnt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 51);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(112, 199);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tables Assigned:";
            // 
            // RequestCheck
            // 
            this.RequestCheck.Location = new System.Drawing.Point(131, 226);
            this.RequestCheck.Name = "RequestCheck";
            this.RequestCheck.Size = new System.Drawing.Size(114, 23);
            this.RequestCheck.TabIndex = 3;
            this.RequestCheck.Text = "Request Check";
            this.RequestCheck.UseVisualStyleBackColor = true;
            this.RequestCheck.Click += new System.EventHandler(this.RequestCheck_Click);
            // 
            // AddItemToBill
            // 
            this.AddItemToBill.Location = new System.Drawing.Point(131, 197);
            this.AddItemToBill.Name = "AddItemToBill";
            this.AddItemToBill.Size = new System.Drawing.Size(114, 23);
            this.AddItemToBill.TabIndex = 4;
            this.AddItemToBill.Text = "Add Item To Check";
            this.AddItemToBill.UseVisualStyleBackColor = true;
            this.AddItemToBill.Click += new System.EventHandler(this.AddItemToBill_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(131, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Order Item";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(247, 53);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(112, 199);
            this.listBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "In Payment:";
            // 
            // PaiedBnt
            // 
            this.PaiedBnt.Location = new System.Drawing.Point(365, 226);
            this.PaiedBnt.Name = "PaiedBnt";
            this.PaiedBnt.Size = new System.Drawing.Size(80, 23);
            this.PaiedBnt.TabIndex = 8;
            this.PaiedBnt.Text = "Paied";
            this.PaiedBnt.UseVisualStyleBackColor = true;
            this.PaiedBnt.Click += new System.EventHandler(this.PaiedBnt_Click);
            // 
            // WaiterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 264);
            this.Controls.Add(this.PaiedBnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.AddItemToBill);
            this.Controls.Add(this.RequestCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "WaiterView";
            this.Text = "WaiterView";
            this.Load += new System.EventHandler(this.WaiterView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RequestCheck;
        private System.Windows.Forms.Button AddItemToBill;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PaiedBnt;
    }
}