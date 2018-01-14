using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new View();
            var presenter = new Presenter(new Model(), view);
            Application.Run(view);
        }
    }
}
