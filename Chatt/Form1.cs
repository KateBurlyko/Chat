using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form1 : Form
    {
        string userName;
        public Form1()
        {
            InitializeComponent();

            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            chatTextBox.ReadOnly = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void ExitChat()
        {
            string message = userName + " leave chat";
            byte[] data = Encoding.Unicode.GetBytes(message);
           
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }
    }
}
