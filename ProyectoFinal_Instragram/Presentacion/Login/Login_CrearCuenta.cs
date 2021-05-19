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
    public partial class Login_CrearCuenta : Form
    {
        ArbolAvl arbol = new ArbolAvl();
        public Login_CrearCuenta()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // verifica que la contraseña este encriptada y la muestra
            if (txtCrearContraseña.PasswordChar == '*')
            {
                txtCrearContraseña.PasswordChar = '\0';
            }

            //  De lo contrario volvera a encriptar la contraseña
            else
            {
                txtCrearContraseña.PasswordChar = '*';
            }

        }

        private void btnPaginaInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Inicio login_Inicio = new Login_Inicio();
            login_Inicio.Show();
        }

        private void bntRegistrarUsuario_Click(object sender, EventArgs e)
        {
            //Aca deberia leer un xml e insetarlo en un arbol
            //y permitir colocar un foto de usuario y almacenarlo en el xml

            Informacion_Usuario infoUsuario = new Informacion_Usuario(txtNomUsuario.Text,txtNomPersona.Text,
            txtFechaNacimiento.Text,"direccion imagen",txtCrearContraseña.Text);

            
            arbol.insertar(infoUsuario);
        }

        
    }
}
