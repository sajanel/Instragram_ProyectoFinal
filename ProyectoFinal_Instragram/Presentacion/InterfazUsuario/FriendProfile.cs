using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
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
        AuxXml miXml = new AuxXml();
        public FriendProfile()
        {
            InitializeComponent();
        }

        string urlImgPerfil;
        private void FriendProfile_Load(object sender, EventArgs e)
        {
            ClaseUsuario objUsuario = new ClaseUsuario(Program.usuario,Program.contraseña);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscar(objUsuario).valorNodo();
            //MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());

            lbSeguidos.Text = encontradoUsuario.tablaHashSeguidos.cont.ToString();
            lbSeguidores.Text = encontradoUsuario.tablaHashSeguidores.cont.ToString();
            lbPosts.Text = encontradoUsuario.miLista.cont.ToString();

            fotoPerfil.WaitOnLoad = false;
            fotoPerfil.LoadAsync(@"" + encontradoUsuario.imagenProfile);

            urlImgPerfil = encontradoUsuario.imagenProfile;

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

        private void btnSeguir_Click(object sender, EventArgs e)
        {
            
            ClaseUsuario objMiUsuario2 = new ClaseUsuario(Program.miUsuario);
            ClaseUsuario encontradoMiUsuario2 = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objMiUsuario2).valorNodo();
            
            if(encontradoMiUsuario2.tablaHashSeguidos.Buscar(converId(lbUsuario.Text)) != null)
            {
                MessageBox.Show("Usted esta siguiendo a " + lbUsuario.Text, "Información Usuario",MessageBoxButtons.OK, MessageBoxIcon.Information );
                btnSeguir.Enabled = false;
            }
            else
            {
                

                miXml.añadirInfoAmigo(urlImgPerfil, lbUsuario.Text, "Siguiendo", "siguiendo", "UsuariosInsta", Program.miUsuario);

                miXml.añadirInfoAmigo(Program.miFoto,Program.miUsuario, "Seguidores", "seguidor", "UsuariosInsta", lbUsuario.Text);

                //converId(lbUsuario.Text);

                //Program.objUsuarioXml2.insertarSiguiendo(lbUsuario.Text, Convert.ToString(converId(lbUsuario.Text)));

                //------------------------------Mi Usuario
                ClaseUsuario objMiUsuario = new ClaseUsuario(Program.miUsuario);
                ClaseUsuario miUsuarioEncontrado = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objMiUsuario).valorNodo();

                //-------------Usuario Amigo
                ClaseUsuario objUsuarioAmigo = new ClaseUsuario(lbUsuario.Text);
                ClaseUsuario usuarioAmigoEncontrado = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuarioAmigo).valorNodo();


                //----INSERTAR USUARIO A MI TABLA SIGUIENDO
                ClasePerfil perfilAmigo = new ClasePerfil(usuarioAmigoEncontrado.imagenProfile, lbUsuario.Text);
                miUsuarioEncontrado.insertarSiguiendo(perfilAmigo, Convert.ToString(converId(lbUsuario.Text)));

                //----INSERTAR MI USUARIO A LA TABLA DE LA OTRA PERSONA
                ClasePerfil miPerfil = new ClasePerfil(Program.miFoto, Program.miUsuario);
                usuarioAmigoEncontrado.insertarSeguidores(miPerfil, Convert.ToString(converId(Program.miUsuario)));

                //-------------Mostrar la cantidad
                lbSeguidos.Text = usuarioAmigoEncontrado.tablaHashSeguidos.cont.ToString();
                lbSeguidores.Text = usuarioAmigoEncontrado.tablaHashSeguidores.cont.ToString();
                lbPosts.Text = usuarioAmigoEncontrado.miLista.cont.ToString();

                MessageBox.Show("Usted a seguido a " + lbUsuario.Text, "Información Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSeguir.Enabled = false;
            }




        }

        public string converId(string user)
        {
            byte[] asscInt = Encoding.ASCII.GetBytes(user);
            string cadena = "";
            foreach (byte item in asscInt)
            {
                cadena = cadena + item;
            }
            return cadena;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }
    }
}
