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

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class PerfilUsuario : Form
    {
        public PerfilUsuario()
        {
            InitializeComponent();
        }

        private void PerfilUsuario_Load(object sender, EventArgs e)
        {
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
    }
}
