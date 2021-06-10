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
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
using System.IO;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class PerfilUsuario : Form
    {
        //Instancias de objetos y de clases
        AuxXml miXml = new AuxXml();
        string Aux1, Aux2, Aux3, Aux4, Aux5;

        public PerfilUsuario()
        {
            InitializeComponent();
        }

        private void PerfilUsuario_Load(object sender, EventArgs e)
        {
            AuxXml aux = new AuxXml();

            // aux.leerXml("UsuarioTemp");
            using (XmlReader reader = XmlReader.Create(@"UsuarioTemp.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "Nombre":
                                lbNombre.Text = reader.ReadString();
                                break;
                            case "Usuario":
                                lbUsuario.Text = reader.ReadString();
                                break;
                            case "Biografia":
                                lbDescripcion.Text = reader.ReadString();
                                break;
                            case "Correo":
                                break;
                            case "Img":
                                pictureBox2.WaitOnLoad = false;
                                pictureBox2.LoadAsync(@"" + reader.ReadString());
                                break;
                        }
                    }
                }
            }
            buscarLista();
        }
        public void buscarLista()
        {
            ClaseUsuario objUsuario = new ClaseUsuario(lbUsuario.Text);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();

            lbSeguidos.Text = encontradoUsuario.tablaHashSeguidos.cont.ToString();
            lbSeguidores.Text = encontradoUsuario.tablaHashSeguidores.cont.ToString();
            lbPosts.Text = encontradoUsuario.miLista.cont.ToString();

            //MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());

            int i = 0;
            NodoDoble indice;
            //for (indice = miUsuario.miLista.inicio; indice != null; indice = indice.siguiente)
            for (indice = encontradoUsuario.miLista.inicio; indice != null; indice = indice.siguiente)
            {
                if (i == 0)
                {
                    pictureBox3.WaitOnLoad = false;
                    pictureBox3.LoadAsync(@"" + indice.dato.ToString());
                    Aux1 = indice.dato.ToString();
                }
                if (i == 1)
                {
                    pictureBox4.WaitOnLoad = false;
                    pictureBox4.LoadAsync(@"" + indice.dato.ToString());
                    Aux2 = indice.dato.ToString();
                }
                if (i == 2)
                {
                    pictureBox5.WaitOnLoad = false;
                    pictureBox5.LoadAsync(@"" + indice.dato.ToString());
                    Aux3 = indice.dato.ToString();
                }
                if (i == 3)
                {
                    pictureBox6.WaitOnLoad = false;
                    pictureBox6.LoadAsync(@"" + indice.dato.ToString());
                    Aux4 = indice.dato.ToString();
                }
                if (i == 4)
                {
                    pictureBox7.WaitOnLoad = false;
                    pictureBox7.LoadAsync(@"" + indice.dato.ToString());
                    Aux5 = indice.dato.ToString();
                }

                i++;
            }

        }
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            EditarPerfil Formulario = new EditarPerfil();
            Formulario.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {
            Program.tipo = "";
            Program.tipo = "Seguidos";
            PerfilListaAmigos Formulario = new PerfilListaAmigos();
            Formulario.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Program.tipo = "";
            Program.tipo = "Seguidores";
            PerfilListaAmigos Formulario = new PerfilListaAmigos();
            Formulario.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EliminarPublicacion(pictureBox3, Aux1);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EliminarPublicacion(pictureBox4, Aux1);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EliminarPublicacion(pictureBox5, Aux1);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EliminarPublicacion(pictureBox6, Aux1);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            EliminarPublicacion(pictureBox7, Aux1);
        }

        public void EliminarPublicacion (PictureBox pictureBox,string Aux)   
        {
            if (MessageBox.Show("Seguro que desea eliminar esta publicacion", "Informacion de cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {

            }
            else
            {

                pictureBox.Image.Dispose();
                pictureBox.Image = null;

                Application.DoEvents();
                if (File.Exists(@"" + Aux) != true)
                {

                }
                else
                {

                    File.Delete(@"" + Aux);
                    
                    miXml.eliminarPublicacion(Aux, lbUsuario.Text, "UsuariosInsta");
                }
               

                this.Hide();
                //Recargar formulario
                PerfilUsuario Formulario = new PerfilUsuario();
                Formulario.Show();
               
            }
        }

    }
}
