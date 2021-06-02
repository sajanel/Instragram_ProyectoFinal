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
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;

namespace ProyectoFinal_Instragram.Presentacion.Login
{
    public partial class Login_CrearCuenta : Form
    {
        AuxXml miXml;
        ClaseUsuario objUsuario;
        OpenFileDialog buscarFoto;
        string urlFoto = "";
        public Login_CrearCuenta()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // verifica que la contraseña este encriptada y la muestra
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
            }

            //  De lo contrario volvera a encriptar la contraseña
            else
            {
                txtContraseña.PasswordChar = '*';
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
            //CREAR XML
            //miXml.crearXml("UsuariosInsta");
            //miXml.leerXml("UsuariosInsta");

            miXml.crearCarpeta(txtUsuario.Text, "UsuariosInsta");

            urlFoto = buscarFoto.FileName;
            string nuevaRuta = Path.Combine(@"Perfiles/" + txtUsuario.Text, buscarFoto.SafeFileName);

            string urlImg = "Perfiles/" + txtUsuario.Text + "/" + Path.GetFileName(urlFoto);

            if (!File.Exists(nuevaRuta))
            
            {
                File.Copy(urlFoto, nuevaRuta);
            }
            else
            {
                MessageBox.Show("La ruta de destino ya contiene un archivo con el mismo nombre.");
            }

            miXml.añadirUsuario(txtUsuario.Text, txtNombre.Text, "", txtCorreo.Text, txtContraseña.Text, urlImg, "UsuariosInsta");
            objUsuario = new ClaseUsuario(txtCorreo.Text, txtNombre.Text, txtUsuario.Text, txtContraseña.Text, "");
            Program.objArbolAvl.insertar(objUsuario);
           
            SalirFomulario();

            
        }

        private void Login_CrearCuenta_Load(object sender, EventArgs e)
        {
            objUsuario = new ClaseUsuario();
            Program.objUsuarioXml2 = new ClaseUsuario();
            Program.objArbolAvl = new ArbolAvl();
            miXml = new AuxXml();
        }

        public void SalirFomulario() 
        {
            MessageBox.Show("Se ha creado exitosamente su usuario","Accesos de cuenta",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
            Login_Inicio Formulario = new Login_Inicio();
            Formulario.Show();
            
        }
        
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            buscarFoto = new OpenFileDialog();
            if (buscarFoto.ShowDialog() == DialogResult.OK)
            {
                urlFoto = buscarFoto.FileName;
                txtFoto.Text = urlFoto;
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
