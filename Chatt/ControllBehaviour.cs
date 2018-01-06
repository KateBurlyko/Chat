using Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chat
{
    partial class Form1 : Form
    {
        public void ControlsBeforeLogin()
        {
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            messageTextBox.Enabled = false;
            chatTextBox.ReadOnly = true;
            listBox1.Enabled = false;
            userNameTextBox.ReadOnly = false;
        }

        public void ControlsAfterLogin()
        {
            loginButton.Enabled = false;
            logoutButton.Enabled = true;
            sendButton.Enabled = true;
            messageTextBox.Enabled = true;
        }
    }
}
