using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
using ProyectoFinal_Instragram.Presentacion.InterfazUsuario;

namespace ProyectoFinal_Instragram.Presentacion.Login
{
    public partial class Login_Inicio : Form
    {
        AuxXml miXml;
        //AuxXml miXmlTemp;

        public Login_Inicio()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // verifica que la contraseña este encriptada y la muestra
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
            }

          //  De lo contrario volvera a encriptar la contraseña
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                this.Hide();
                Login_CrearCuenta formularioAdmin = new Login_CrearCuenta();
                formularioAdmin.Show();   
        }

        private void bntIniciarSesion_Click(object sender, EventArgs e)
        {
            //En esta parte deberia de leer el archivo xml 
            //Y a su vez deberia insertarlo en otro arbol 
            //Para hacer un busqueda y comprobar si existe ese usuario para loggearse.

            ClaseUsuario objUsuario = new ClaseUsuario(txtUsuario.Text, txtContraseña.Text);

            if (Program.objArbolAvl == null)
            {
                MessageBox.Show("No Existen Usuarios");
                this.Hide();
                Login_CrearCuenta formularioAdmin = new Login_CrearCuenta();
                formularioAdmin.Show();
            }
            else
            {
                if (Program.objArbolAvl.buscar(objUsuario) == null)
                {
                    MessageBox.Show("Usuario no encontrado");
                }
                else
                {
                    ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscar(objUsuario).valorNodo();
                    MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());

                    Program.miUsuario = encontradoUsuario.usuario;

                    miXml.eliminarXml("UsuarioTemp");
                    miXml.crearXml("UsuarioTemp");
                    miXml.añadirUsuario(encontradoUsuario.usuario, encontradoUsuario.nombre, "", encontradoUsuario.correo,
                        encontradoUsuario.contraseña, encontradoUsuario.imagenProfile , encontradoUsuario.fechaUsurio,"UsuarioTemp");
                    //miXmlTemp.leerXml("UsuarioTemp");

                    Navegation Formulario = new Navegation();
                    Formulario.Show();
                    this.Hide();

                }
            }
            
        }

        
        private void Login_Inicio_Load(object sender, EventArgs e)
        {
            Program.objArbolAvl = new ArbolAvl();
            
            miXml = new AuxXml();
            miXml.crearXml("UsuariosInsta");

            //miXml.leerXml("UsuariosInsta");
            miXml.leerXmlCompleto("UsuariosInsta");
        }
    }
}

