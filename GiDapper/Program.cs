using Dapper;
using System;
using System.Windows.Forms;

namespace GiDapper
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Revisiones());
        }
    }
}
