using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Presentacion.Login;
using ProyectoFinal_Instragram.Presentacion.InterfazUsuario;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;

namespace ProyectoFinal_Instragram
{
    static class Program
    {
        static public ArbolAvl objArbolAvl;
        static public ClaseUsuario objUsuarioXml2;
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
            //static ArbolAvl arbol2;
            
        }
    }
}
