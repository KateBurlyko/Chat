﻿namespace Chat
{
    partial class Form1
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
            this.sendButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(420, 475);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(101, 24);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(421, 12);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(101, 26);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(421, 44);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(100, 26);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(107, 12);
            this.userNameTextBox.Multiline = true;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(292, 30);
            this.userNameTextBox.TabIndex = 3;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(18, 453);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(381, 46);
            this.messageTextBox.TabIndex = 4;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Enabled = false;
            this.ChatTextBox.Location = new System.Drawing.Point(107, 73);
            this.ChatTextBox.Multiline = true;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(414, 357);
            this.ChatTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.sendButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox ChatTextBox;
    }
}
