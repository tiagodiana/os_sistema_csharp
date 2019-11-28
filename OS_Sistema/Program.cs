using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OS_Sistema
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
            //Login tela_login = new Login();
            //tela_login.ShowDialog();
            Application.Run(new Inicio());
        }
    }
}
