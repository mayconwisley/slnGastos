using System;
using System.Windows.Forms;

namespace Gastos
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

            FrmTelaLogin frmTelaLogin = new FrmTelaLogin();

            if (frmTelaLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmPrincipal(frmTelaLogin.Login));
            }
        }
    }
}
