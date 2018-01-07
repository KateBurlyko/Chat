using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        ObservableCollection<string> listOfUsers;
        ActionsW actions;

        public Form1()
        {
            InitializeComponent();
            groupAddress = IPAddress.Parse(DataForConnection.Default.HOST);
            listOfUsers = new ObservableCollection<string>();
            listOfUsers.Add("List of active users");
            ControlsBeforeLogin();
            listBox1.DataSource = listOfUsers;
            listOfUsers.CollectionChanged += updatingOfUserList;
            actions = new ActionsW();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            try
            {
                client = new UdpClient(DataForConnection.Default.CONNECTION_PORT);
                client.JoinMulticastGroup(groupAddress, DataForConnection.Default.TTL);

                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                string message = userName + " intered in chat";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, DataForConnection.Default.HOST, DataForConnection.Default.MESSAGES_PORT);
                actions.AddOrRemoveUserFromList(message, listOfUsers);
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
            string message = userName + " leaved chat";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, DataForConnection.Default.HOST, DataForConnection.Default.MESSAGES_PORT);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            actions.AddOrRemoveUserFromList(message, listOfUsers);
            client.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        private void updatingOfUserList(object sender, NotifyCollectionChangedEventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = listOfUsers;
        }
    }
}