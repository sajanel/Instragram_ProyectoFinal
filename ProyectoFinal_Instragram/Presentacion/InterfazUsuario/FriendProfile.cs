using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class FriendProfile : Form
    {
        public FriendProfile()
        {
            InitializeComponent();
        }

        private void FriendProfile_Load(object sender, EventArgs e)
        {
            ClaseUsuario objUsuario = new ClaseUsuario(Program.usuario,Program.contraseña);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscar(objUsuario).valorNodo();
            //MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());

            fotoPerfil.WaitOnLoad = false;
            fotoPerfil.LoadAsync(@"" + encontradoUsuario.imagenProfile);

            lbNombre.Text = encontradoUsuario.nombre;
            lbUsuario.Text = encontradoUsuario.usuario;

            

            int i = 0;
            NodoDoble indice;

            for (indice = encontradoUsuario.miLista.inicio; indice != null; indice = indice.siguiente)
            {
                if (i == 0)
                {
                    pictureBox3.WaitOnLoad = false;
                    pictureBox3.LoadAsync(@"" + indice.dato.ToString());
                }
                if (i == 1)
                {
                    pictureBox4.WaitOnLoad = false;
                    pictureBox4.LoadAsync(@"" + indice.dato.ToString());
                }
                if (i == 2)
                {
                    pictureBox5.WaitOnLoad = false;
                    pictureBox5.LoadAsync(@"" + indice.dato.ToString());
                }
                if (i == 3)
                {
                    pictureBox6.WaitOnLoad = false;
                    pictureBox6.LoadAsync(@"" + indice.dato.ToString());
                }

                i++;
            }
        }

       

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
