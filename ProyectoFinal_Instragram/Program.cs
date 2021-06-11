using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Presentacion.Login;
using ProyectoFinal_Instragram.Presentacion.Grafico_Arbol;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;

namespace ProyectoFinal_Instragram
{
    static class Program
    {
        static public string usuario, contraseña;
        static public string miUsuario, miFoto;
        static public ArbolAvl objArbolAvl;
        static public ClaseUsuario objUsuarioXml2;
        static public string tipo;
        static public int cont;
        static public listaDoble navPublicaciones = new listaDoble();

        static public PictureBox[] pictureBoxes = new PictureBox[20];

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
          //Application.Run(new Grafica());
            //Application.Run(new Navegation());
            //Application.Run(new Login_CrearCuenta());
            //Application.Run(new PerfilUsuario());
            //static ArbolAvl arbol2;

        }
    }
}
