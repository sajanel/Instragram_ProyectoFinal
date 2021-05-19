using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
namespace ProyectoFinal_Instragram.Presentacion.Login
{
    public partial class Login_Inicio : Form
    {
        ArbolAvl arbolUsuarios = new ArbolAvl();
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

            Informacion_Usuario infoUsuario = new Informacion_Usuario(txtUsuario.Text, txtContraseña.Text);
           
            //En esta parte deberia de leer el archivo xml 
            //Y a su vez deberia insertarlo en otro arbol 
            //Para hacer un busqueda y comprobar si existe ese usuario para loggearse.
            
            
            
            if (arbolUsuarios.buscar(infoUsuario) == null)
            {
                MessageBox.Show("Usuario no encontrado");
            }
            else

            {
                // Convierte la informacion a tipo cadena
                Informacion_Usuario encontradoAlum = (Informacion_Usuario)arbolUsuarios.buscar(infoUsuario).valorNodo();
                MessageBox.Show("Dato encontrado   " + encontradoAlum.busquedaInfo());
            }
        }
    }
    }

