using System.Collections.Generic;

namespace Chat
{
    class Model
    {
        public List<User> ActiveUsers { get; set; }
        public List<string> SentMessages { get; set; }
    }
}
