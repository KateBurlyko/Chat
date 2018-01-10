using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        }

        private void LogIn(string name)
        {
            Model.UserName = name;
        }

        private void LogOut()
        {

        }

        private void Send()
        {

        }
    }
}
