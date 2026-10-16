
namespace Tooded_EFCore
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

        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            txtParool = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            lblVeateade = new Label();
            SuspendLayout();

            // txtEmail
            txtEmail.Location = new Point(173, 113);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(149, 23);
            txtEmail.TabIndex = 0;

            // txtParool
            txtParool.Location = new Point(173, 142);
            txtParool.Name = "txtParool";
            txtParool.PasswordChar = '*';
            txtParool.Size = new Size(149, 23);
            txtParool.TabIndex = 1;

            // btnLogin
            btnLogin.Location = new Point(173, 188);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "button1";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(173, 71);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";

            // lblVeateade
            lblVeateade.AutoSize = true;
            lblVeateade.Location = new Point(438, 236);
            lblVeateade.Name = "lblVeateade";
            lblVeateade.Size = new Size(0, 15);
            lblVeateade.TabIndex = 4;

            // LoginForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblVeateade);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txtParool);
            Controls.Add(txtEmail);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtParool;
        private Button btnLogin;
        private Label label1;
        private Label lblVeateade;
    }
}
