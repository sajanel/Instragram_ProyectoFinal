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
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Presentacion.Login;
using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;
using System.Xml;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class EditarPerfil : Form
    {

        ClaseUsuario infoUsuario = new ClaseUsuario();
        // PublicacionesUsuario publicacionesUser = new PublicacionesUsuario();
        listaDoble listaPublicaciones = new listaDoble();
        // NodoDoble miNodoUsuario;

        AuxXml miXml = new AuxXml();
        OpenFileDialog buscarFoto;
        OpenFileDialog buscarFoto2;
        string urlFoto = "";
        string urlFoto2 = "";
        string urProfile = "";
        string fechaNacimiento = "";

        public EditarPerfil()
        {
            InitializeComponent();
            dateTimePicker1.Visible = false;
            txtContraseña.Enabled = false;
            desbloquearComandos(false);
            
        }
        

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            buscarFoto2 = new OpenFileDialog();
            if (buscarFoto2.ShowDialog() == DialogResult.OK)
            {
                urlFoto2 = buscarFoto2.FileName;
                txtPublicaciones.Text = urlFoto2;
                string extension = Path.GetExtension(buscarFoto2.FileName);

                if (!extension.Equals(".png") && !extension.Equals(".jpg") && !extension.Equals(".PNG") && !extension.Equals(".jpeg"))
                {
                    MessageBox.Show("Sólo se admiten archivos en formatos .png, .jpg, .jpeg");
                    return;
                }
            }
            pictureBox2.WaitOnLoad = false;
            pictureBox2.LoadAsync(@"" + urlFoto2);

        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            //ELIMINAR LOS DATOS DEL ARBOL Y LUEGO LEER OTRA VEZ EL XML USUARIOSINTA

            urlFoto2 = buscarFoto2.FileName;
            string nuevaRuta = Path.Combine(@"Perfiles/" + auxUsuario.Text, buscarFoto2.SafeFileName);

            string urlImg = "Perfiles/" + auxUsuario.Text + "/" + Path.GetFileName(urlFoto2);

            if (!File.Exists(nuevaRuta))

            {
                File.Copy(urlFoto2, nuevaRuta);
                //File.Delete(urProfile);
            }
            else
            {
                MessageBox.Show("La ruta de destino ya contiene un archivo con el mismo nombre.");
            }

            if (txtBiografia.Text == "" || txtContraPrueva.Text == "" || txtNuevaContra.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Llene todos los campos", "Modificar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtNuevaContra.Text != txtContraPrueva.Text)
            {
                MessageBox.Show("las contraseñas son distintas", "Modificar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                fechaNacimiento = dateTimePicker1.Value.ToString("dd/MM/yyyy"); //Fecha Usuario
                miXml.actualizarUsuario(txtUsuario.Text, txtNombre.Text, txtBiografia.Text, txtCorreo.Text, txtNuevaContra.Text, urlImg, "UsuariosInsta", fechaNacimiento);
                
                miXml.actualizarUsuario(txtUsuario.Text, txtNombre.Text, txtBiografia.Text, txtCorreo.Text, txtNuevaContra.Text, urlImg, "UsuarioTemp", fechaNacimiento);

                //ClaseUsuario objUsuario = new ClaseUsuario(txtUsuario.Text);
                //ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();
                //encontradoUsuario.imagenProfile = "";

                SalirFomulario();
            }
        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
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
                            case "Contraseña":
                                txtContraseña.Text = reader.ReadString();
                                break; 
                            case "Img":
                                urProfile = reader.ReadString();
                                pictureBox2.WaitOnLoad = false;
                                pictureBox2.LoadAsync(@"" + urProfile);
                                break;
                            case "FechaNacimiento":
                                lblFecha.Text = reader.ReadString();
                                break;
                        }
                    }
                }
            }

            auxUsuario.Text = txtUsuario.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PerfilUsuario Formulario = new PerfilUsuario();
            Formulario.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
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
            pictureBox3.WaitOnLoad = false;
            pictureBox3.LoadAsync(@"" + urlFoto);
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {

            if (txtComentario.Text == "" || txtPublicaciones.Text == "")
            {
                MessageBox.Show("Llene todos los campos", "Accesos de cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            urlFoto = buscarFoto.FileName;
            string nuevaRuta = Path.Combine(@"Perfiles/" + auxUsuario.Text, buscarFoto.SafeFileName);

            string urlImg = "Perfiles/" + auxUsuario.Text + "/" + Path.GetFileName(urlFoto);

            if (!File.Exists(nuevaRuta))

            {
                File.Copy(urlFoto, nuevaRuta);
            }
            else
            {
                MessageBox.Show("La ruta de destino ya contiene un archivo con el mismo nombre.");
            }
            
            miXml.añadirPublicacion(urlImg, txtComentario.Text, "UsuariosInsta",auxUsuario.Text);
            listaPublicaciones = infoUsuario.instarPublicacion(txtComentario.Text, txtComentario.Text);

            miXml.añadirPublicacion(urlImg, txtComentario.Text, "UsuarioTemp", auxUsuario.Text);
            listaPublicaciones = infoUsuario.instarPublicacion(txtComentario.Text, txtComentario.Text);

            ClaseUsuario objUsuario = new ClaseUsuario(auxUsuario.Text);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();
            encontradoUsuario.insertarPublicaciones(urlImg + "," + txtComentario.Text);
            SalirFomulario();
        }

        public void SalirFomulario()
        {
            MessageBox.Show("Se ha generado correctamente", "informacion del usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            PerfilUsuario Formulario = new PerfilUsuario();
            Formulario.Show();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void txtContraPrueva_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void desbloquearComandos(bool valor) 
        {     
            txtCorreo.Enabled = valor;
            txtNombre.Enabled = valor;
            txtNuevaContra.Enabled = valor;
            txtBiografia.Enabled = valor;
            txtContraPrueva.Enabled = valor;
            btnEditarPerfil.Enabled = valor;
            btnEditarPerfil.Enabled = valor;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {           
            if (lblFecha.Visible == true)
            {
                lblFecha.Visible = false;
                dateTimePicker1.Visible = true;
                desbloquearComandos(true);
            }
            else
            {
                lblFecha.Visible = true;
                dateTimePicker1.Visible = false;
                desbloquearComandos(false);
            }
        }

        private void btnEliminacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar esta cuenta", "informacion del usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
            }
            else
            {

                miXml.eliminarUsuario(txtUsuario.Text, "UsuariosInsta");

                MessageBox.Show("Se ha elimindo correctamente", "informacion del usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Login_Inicio formulario = new Login_Inicio();
                formulario.Show();
            }
        }
    }
}
