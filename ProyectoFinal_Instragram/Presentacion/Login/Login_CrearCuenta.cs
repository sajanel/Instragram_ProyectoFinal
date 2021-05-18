using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_Instragram.Presentacion.Login
{
    public partial class Login_CrearCuenta : Form
    {
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bntRegistrarUsuario_Click(object sender, EventArgs e)
        {
            string nombre;
        }
    }
}
