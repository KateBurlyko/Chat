using Chatt;
using System;
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
        IPAddress groupAddress;

        string userName;

        public Form1()
        {
            //user = new Users();
            InitializeComponent();
            groupAddress = IPAddress.Parse(DataForConnection.Default.HOST);

            ControlsBeforeLogin();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                //creating of channel
                client = new UdpClient(DataForConnection.Default.CONNECTION_PORT);
                client.JoinMulticastGroup(groupAddress, DataForConnection.Default.TTL);

                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                string message = userName + " intered in chat";
                byte[] data = Encoding.Unicode.GetBytes(message);
                //user.addUser(userName);
                // listBox1.DataSource = null;
                //listBox1.DataSource = user.userN;
                client.Send(data, data.Length, DataForConnection.Default.HOST, DataForConnection.Default.MESSAGES_PORT);

                ControlsAfterLogin();

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
                client.Send(data, data.Length, DataForConnection.Default.HOST, DataForConnection.Default.MESSAGES_PORT);
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
            ControlsBeforeLogin();
        }

        private void ExitChat()
        {
            string message = userName + " leved chat";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, DataForConnection.Default.HOST, DataForConnection.Default.MESSAGES_PORT);
            client.DropMulticastGroup(groupAddress);
            // user.deleteUser(userName);
            //  listBox1.DataSource = null;
            //listBox1.DataSource = user.userN;
            alive = false;
            client.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }
    }
}
