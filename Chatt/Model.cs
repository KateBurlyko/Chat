using Chatt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public class Model
    {
        public Model()
        {
            ListOfUsers = new ObservableCollection<string> { "List of active users:" };
            ListOfUsers.CollectionChanged += (obj, arg) => RequireListUpdate?.Invoke(ListOfUsers.ToList());
            Alive = false;
        }
        public ObservableCollection<string> ListOfUsers { get; set; }
        public event Action<List<string>> RequireListUpdate;
        public string UserName { get; set; }

        public UdpClient Client { get; set; }
        public IPAddress GroupAddress { get { return IPAddress.Parse(DataForConnection.Default.HOST); } }
        public bool Alive { get; set; }
    }
}
