using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form1 : Form
    {
        bool alive = false;
        UdpClient client;
        const int TTL = 20;
        const string HOST = "235.166.1.4";
        IPAddress groupAddress;

        string userName;
        int _port1;
        int _port2;

        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            chatTextBox.ReadOnly = true;

            groupAddress = IPAddress.Parse(HOST);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            getPort1();
            getPort2();
            try
            {
                client = new UdpClient(_port1);
                client.JoinMulticastGroup(groupAddress, TTL);

                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                string message = userName + " вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, _port2);

                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n" + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, _port2);
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
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }

        private void ExitChat()
        {
            string message = userName + " покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, HOST, _port2);
            client.DropMulticastGroup(groupAddress);

            alive = false;
            client.Close();

            userNameTextBox.ReadOnly = false;
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }

        private void getPort1()
        {
            _port1 = int.Parse(port1.Text);
        }

        private void getPort2()
        {
            _port2 = int.Parse(port2.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }
    }
}
