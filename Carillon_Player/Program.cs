using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Carillon_Player
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
            Form1 dialog = new Form1(true);
            dialog.ShowDialog();
            //Application.Run(new Form1());
        }
    }
}
