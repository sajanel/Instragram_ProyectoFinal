using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Presentacion.Login;
using ProyectoFinal_Instragram.Presentacion.InterfazUsuario;

namespace ProyectoFinal_Instragram
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Inicio());
            //Application.Run(new Navegation());
            //Application.Run(new Login_CrearCuenta());
            //Application.Run(new PerfilUsuario());
        }
    }
}
