using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat
{
    class Presenter
    {
        private MainForm mainForm;
        private Model model;

        public Presenter(MainForm mainForm)
        {
            model = new Model();
            this.mainForm = mainForm;
        }

        private void LogIn(object sender, EventArgs e)
        {

        }

        private void LogOut(object sender, EventArgs e)
        {

        }

        private void Send(object sender, EventArgs e)
        {

        }
    }
}
