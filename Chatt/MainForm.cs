using System;
using System.Windows.Forms;

namespace Chat
{
    public partial class MainForm : Form
    {
        public string UserName { get { return userNameTextBox.Text; } set { userNameTextBox.Text = value; } }
        public string UserMessage { get { return messageTextBox.Text; } set { messageTextBox.Text = value; } }

        public event EventHandler<EventArgs> LogIn;
        public event EventHandler<EventArgs> LogOut;
        public event EventHandler<EventArgs> Send;

        private Presenter presenter;
        public MainForm()
        {
            InitializeComponent();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            messageTextBox.Enabled = false;
            chatTextBox.ReadOnly = true;
            userNameTextBox.ReadOnly = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            loginButton.Enabled = false;
            logoutButton.Enabled = true;
            sendButton.Enabled = true;
            messageTextBox.Enabled = true;
            userNameTextBox.ReadOnly = true;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {

            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            messageTextBox.Enabled = false;
            chatTextBox.ReadOnly = true;
            userNameTextBox.ReadOnly = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}