using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class EditarPerfil : Form
    {
        public EditarPerfil()
        {
            InitializeComponent();
        }
        XmlDocument doc;

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscarFoto = new OpenFileDialog();
            if (buscarFoto.ShowDialog() == DialogResult.OK)
            {
                string urlFoto = buscarFoto.FileName;

                string extension = System.IO.Path.GetExtension(buscarFoto.FileName);

                if (!extension.Equals(".png") && !extension.Equals(".jpg") && !extension.Equals(".PNG") && !extension.Equals(".jpeg"))
                {
                    MessageBox.Show("Sólo se admiten archivos en formatos .png, .jpg, .jpeg");
                    return;
                }

                string nuevaRuta = Path.Combine(@"Perfiles", buscarFoto.SafeFileName);

                if (!File.Exists(nuevaRuta))
                {
                    File.Copy(urlFoto, nuevaRuta);
                }
                else
                {
                    MessageBox.Show("La ruta de destino ya contiene un archivo con el mismo nombre.");
                }
            }
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            //ELIMINAR LOS DATOS DEL ARBOL Y LUEGO LEER OTRA VEZ EL XML USUARIOSINTA
            

            try
            {
                doc = new XmlDocument();

                doc.Load(@"UsuarioTemp.xml");


                XmlElement usuarios = doc.DocumentElement;

                XmlNodeList listaEmpleados = doc.SelectNodes("Usuarios/usuario");

                XmlNode editarUsuario = editarXml(txtNombre.Text, txtUsuario.Text, txtBiografia.Text, txtCorreo.Text);

                foreach (XmlNode item in listaEmpleados)
                {

                    if (item.FirstChild.InnerText == txtUsuario.Text)
                    {
                        XmlNode nodoOld = item;
                        usuarios.ReplaceChild(editarUsuario, nodoOld);

                    }
                }

                doc.Save(@"UsuarioTemp.xml");
                MessageBox.Show("EDITADO CORRECTAMENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO EN LA EDICION"+ex);
            }
        }

        private XmlNode editarXml(string nombre, string usuario, string biografia, string correo)
        {

            XmlNode usser = doc.CreateElement("usuario");

            XmlElement xmlUsuario = doc.CreateElement("Usuario");
            xmlUsuario.InnerText = usuario;
            usser.AppendChild(xmlUsuario);

            XmlElement xmlNombre = doc.CreateElement("Nombre");
            xmlNombre.InnerText = nombre;
            usser.AppendChild(xmlNombre);

            XmlElement xmlBiografia = doc.CreateElement("Biografia");
            xmlBiografia.InnerText = biografia;
            usser.AppendChild(xmlBiografia);


            XmlElement xmlCorreo = doc.CreateElement("Correo");
            xmlCorreo.InnerText = correo;
            usser.AppendChild(xmlCorreo);

            XmlElement xmlContraseña = doc.CreateElement("Contraseña");
            xmlContraseña.InnerText = "325";
            usser.AppendChild(xmlContraseña);

            XmlElement xmlImg = doc.CreateElement("Img");
            xmlImg.InnerText = "IMG.png";
            usser.AppendChild(xmlImg);


            return usser;
        }

        private void EditarPerfil_Load(object sender, EventArgs e)
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
                                txtNombre.Text = reader.ReadString();
                                break;
                            case "Usuario":
                                txtUsuario.Text = reader.ReadString();
                                break;
                            case "Biografia":
                                txtBiografia.Text = reader.ReadString();
                                break;
                            case "Correo":
                                txtCorreo.Text = reader.ReadString();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }
    }
}
