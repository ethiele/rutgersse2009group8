namespace CRySTALClient
{
    partial class LoginForm
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
            this.LoginBnt = new System.Windows.Forms.Button();
            this.CancelBnt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // LoginBnt
            // 
            this.LoginBnt.Location = new System.Drawing.Point(278, 88);
            this.LoginBnt.Name = "LoginBnt";
            this.LoginBnt.Size = new System.Drawing.Size(75, 23);
            this.LoginBnt.TabIndex = 0;
            this.LoginBnt.Text = "Login";
            this.LoginBnt.UseVisualStyleBackColor = true;
            this.LoginBnt.Click += new System.EventHandler(this.LoginBnt_Click);
            // 
            // CancelBnt
            // 
            this.CancelBnt.Location = new System.Drawing.Point(197, 88);
            this.CancelBnt.Name = "CancelBnt";
            this.CancelBnt.Size = new System.Drawing.Size(75, 23);
            this.CancelBnt.TabIndex = 1;
            this.CancelBnt.Text = "Cancel";
            this.CancelBnt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Location = new System.Drawing.Point(89, 24);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(264, 20);
            this.UsernameTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(89, 51);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(264, 20);
            this.PasswordTxt.TabIndex = 5;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 119);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelBnt);
            this.Controls.Add(this.LoginBnt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.Text = "Login To Crystal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginBnt;
        private System.Windows.Forms.Button CancelBnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox PasswordTxt;
    }
}