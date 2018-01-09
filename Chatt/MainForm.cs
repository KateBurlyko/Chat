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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}