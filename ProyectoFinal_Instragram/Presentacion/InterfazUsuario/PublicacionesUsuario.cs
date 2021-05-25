using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class PublicacionesUsuario : Form
    {
        ClaseUsuario infoUsuario = new ClaseUsuario();
       // PublicacionesUsuario publicacionesUser = new PublicacionesUsuario();
        listaDoble listaPublicaciones = new listaDoble();
       // NodoDoble miNodoUsuario;

        AuxXml miXml = new AuxXml();
        OpenFileDialog buscarFoto;
        string urlFoto = "";
        public PublicacionesUsuario()
        {
            InitializeComponent();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {

            //miXml.crearCarpeta(txtUsuario.Text, "UsuariosInsta");

            urlFoto = buscarFoto.FileName;
            string nuevaRuta = Path.Combine(@"Perfiles/" + "Sergio", buscarFoto.SafeFileName);

            string urlImg = "Perfiles/" + "Sergio" + "/" + Path.GetFileName(urlFoto);

            if (!File.Exists(nuevaRuta))

            {
                File.Copy(urlFoto, nuevaRuta);
            }
            else
            {
                MessageBox.Show("La ruta de destino ya contiene un archivo con el mismo nombre.");
            }

            miXml.añadirPublicacion(urlImg,txtComentario.Text, "UsuariosInsta","");
            listaPublicaciones = infoUsuario.instarPublicacion(txtComentario.Text, txtComentario.Text);

            ////Convertir la infromacion en cadena
            //miNodoUsuario = listaPublicaciones.inicio;
            //publicacionesUsuario = (PublicacionesUsuario)miNodoUsuario.dato;
            //miNodoUsuario.dato.ToString();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            buscarFoto = new OpenFileDialog();
            if (buscarFoto.ShowDialog() == DialogResult.OK)
            {
                urlFoto = buscarFoto.FileName;
                txtPublicaciones.Text = urlFoto;
                string extension = Path.GetExtension(buscarFoto.FileName);

                if (!extension.Equals(".png") && !extension.Equals(".jpg") && !extension.Equals(".PNG") && !extension.Equals(".jpeg"))
                {
                    MessageBox.Show("Sólo se admiten archivos en formatos .png, .jpg, .jpeg");
                    return;
                }

            }
        }
    }
}
