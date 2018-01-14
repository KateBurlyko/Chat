using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chat
{
    public partial class View : Form
    {
        public event Action<string> LogIn;
        public event Action<string> Send;
        public event Action LogOut;
        public View()
        {
            InitializeComponent();
            SetEnabledState(false);
        }

        public void UpdateUsers(List<string> users)
        {
            listBox1.DataSource = users;
        }

        private void SetEnabledState(bool flag)
        {
            loginButton.Enabled = !flag;
            logoutButton.Enabled = flag;
            sendButton.Enabled = flag;
            messageTextBox.Enabled = flag;
            chatTextBox.ReadOnly = !flag;
            userNameTextBox.ReadOnly = flag;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            LogIn?.Invoke(userNameTextBox.Text);
            SetEnabledState(true);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Send?.Invoke(messageTextBox.Text);
            messageTextBox.Clear();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LogOut?.Invoke();
            SetEnabledState(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogOut?.Invoke();
        }

        public void AddMessage(string message)
        {
            chatTextBox.Text = DateTime.Now.ToShortTimeString() + " " + message + "\r\n" + chatTextBox.Text;
        }
    }
}