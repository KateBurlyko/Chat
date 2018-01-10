using Chatt;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public class Model
    {
        public ObservableCollection<string> ListOfUsers { get; set; }
        public string UserName { get; set; }

        public UdpClient Client { get; set; }
        public IPAddress GroupAddress { get { return IPAddress.Parse(DataForConnection.Default.HOST); } }
        public bool Alive { get; set; }
    }
}
