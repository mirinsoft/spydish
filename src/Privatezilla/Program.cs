using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Privatezilla.Locales;

namespace Privatezilla
{
    static class Program
    {

        internal static string GetCurrentVersionTostring() => new Version(Application.ProductVersion).ToString(3);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Environment.OSVersion.Version.Build < 9200)

                MessageBox.Show(Locale.msgAppCompatibility, "Privatezilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Application.Run(new MainWindow());

        }
    }
}
