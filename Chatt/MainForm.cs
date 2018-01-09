using System;
using System.Windows.Forms;

namespace Chat
{
    public partial class MainForm : Form
    {
        private Presenter presenter;


        public MainForm()
        {
            InitializeComponent();
            presenter = new Presenter();
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