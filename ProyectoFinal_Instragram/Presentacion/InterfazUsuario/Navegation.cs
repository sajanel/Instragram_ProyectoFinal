using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Presentacion.Login;
using System.Xml;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class Navegation : Form
    {
        AuxXml miXmlTemp;
        public Navegation()
        {
            InitializeComponent();
        }

        private void PerfilUsuario_Load(object sender, EventArgs e)
        {
            miXmlTemp = new AuxXml();
            PanelOpciones.Visible = false;
            //miXmlTemp.leerXml("UsuarioTemp");
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
                                //  lbDescripcion.Text = reader.ReadString();
                                break;
                            case "Correo":
                                break;
                            case "Img":
                                ProfileUser.WaitOnLoad = false;
                                ProfileUser.LoadAsync(@"" + reader.ReadString());
                                break;
                        }
                    }
                }
            }
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
      
        }

        private void ProfileUser_Click(object sender, EventArgs e)
        {
            // verifica que el panel este visible
            if (PanelOpciones.Visible == false)
            {
                PanelOpciones.Visible=true;
            }

            //  De lo contrario volvera a esconder
            else
            {
                PanelOpciones.Visible = false;
            }
        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario Formulario = new PerfilUsuario();
            Formulario.Show();
            this.Hide();

        }

        private void lblConfiguracion_Click(object sender, EventArgs e)
        {
            EditarPerfil Formulario = new EditarPerfil();
            Formulario.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            miXmlTemp.eliminarXml("UsuarioTemp");

            Login_Inicio Formulario = new Login_Inicio();
            Formulario.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
