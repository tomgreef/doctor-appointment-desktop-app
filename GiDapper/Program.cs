using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using GiDapper.Database;
using System;
using System.Text.RegularExpressions;
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
            FluentMapper.Initialize(c => {
                c.AddMap(new EyeMap());
                c.AddMap(new ClientMap());
                c.ForDommel();
            });
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Revisiones());
        }
    }
}
