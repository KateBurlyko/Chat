using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public class Model
    {
        public ObservableCollection<string> ListOfUsers { get; set; }
        public string UserName { get; set; }
    }
}
