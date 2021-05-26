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

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class PerfilUsuario : Form
    {
        //Instancias de objetos y de clases
        AuxXml miXml = new AuxXml();
     

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
            
            if ("Sergio" == txtBusqueda.Text)
            {
                MessageBox.Show("Si son iugales");
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            miXml.añadirInfoAmigo(txtComentario.Text, "Siguiendo", "seguir", "UsuariosInsta", lbUsuario.Text);
        }

        private void btnSeguidor_Click(object sender, EventArgs e)
        {
         
            miXml.añadirInfoAmigo(txtComentario.Text, "Seguidores", "seguidor", "UsuariosInsta", lbUsuario.Text);
        
        }


        //Codigo utilizado para los seguidores y seguiendo

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    miXml.añadirInfoAmigo(txtComentario.Text, "Siguiendo", "seguir", "UsuariosInsta", lbUsuario.Text);
        //}

        //private void btnSeguidor_Click(object sender, EventArgs e)
        //{

        //    miXml.añadirInfoAmigo(txtComentario.Text, "Seguidores", "seguidor", "UsuariosInsta", lbUsuario.Text);

        //}
    }
}
