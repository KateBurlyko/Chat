using Chatt;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    class Presenter
    {
        public Model Model { get; set; }
        public View View { get; set; }

        public Presenter(Model model, View view)
        {
            Model = model;
            View = view;

            View.LogIn += LogIn;
        }

        private void LogIn(string name)
        {
            Model.UserName = name;
            try
            {
                Model.Client = new UdpClient(DataForConnection.Default.CONNECTION_PORT);
                Model.Client.JoinMulticastGroup(Model.GroupAddress, DataForConnection.Default.TTL);

                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                string message = name + " intered in chat";
                byte[] data = Encoding.Unicode.GetBytes(message);
                Model.Client.Send(data, data.Length, DataForConnection.Default.HOST, DataForConnection.Default.MESSAGES_PORT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogOut()
        {
           
        }

        private void Send()
        {

        }

        private void ReceiveMessages()
        {
            Model.Alive = true;
            try
            {
                while (Model.Alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = Model.Client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    View.Invoke(new MethodInvoker(() => { View.AddMessage(message); }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!Model.Alive) return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
