using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat
{
    class Presenter
    {
        private  MainForm mainForm;
        private Model model;
        public Presenter()
        {
            mainForm = new MainForm();
            model = new Model();
        }
    }
}
