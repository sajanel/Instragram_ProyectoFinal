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
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Presentacion.InterfazUsuario;

namespace ProyectoFinal_Instragram.Presentacion.Login
{
    public partial class Login_Inicio : Form
    {
        ArbolAvl arbolUsuarios = new ArbolAvl();
        Informacion_Usuario objUsuarioXml;
        public Login_Inicio()
        {
            InitializeComponent();
        }

        XmlDocument doc;
        private void label3_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
                this.Hide();
                Login_CrearCuenta formularioAdmin = new Login_CrearCuenta();
                formularioAdmin.Show();   
        }
        string correo;
        string nombre;
        string usuario;
        string contraseña;
        string img;
        private void bntIniciarSesion_Click(object sender, EventArgs e)
        {

            //En esta parte deberia de leer el archivo xml 
            //Y a su vez deberia insertarlo en otro arbol 
            //Para hacer un busqueda y comprobar si existe ese usuario para loggearse.

            using (XmlReader reader = XmlReader.Create(@"UsuariosInsta.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "Usuario":
                                usuario = reader.ReadString();
                                break;
                            case "Nombre":
                                nombre = reader.ReadString();
                                break;
                            case "Biografia":
                                break;
                            case "Correo":
                                correo = reader.ReadString();
                                break;
                            case "Contraseña":
                                contraseña = reader.ReadString();
                                break;
                            case "Img":
                                img = reader.ReadString();
                                objUsuarioXml = new Informacion_Usuario(correo, nombre, usuario, contraseña, img);
                                arbolUsuarios.insertar(objUsuarioXml);
                                correo = "";
                                nombre = "";
                                usuario = "";
                                contraseña = "";
                                img = "";
                                break;
                        }

                    }

                }
            }
            Informacion_Usuario infoUsuario = new Informacion_Usuario(txtUsuario.Text, txtContraseña.Text);
            if (arbolUsuarios.buscar(infoUsuario) == null)
            {
                MessageBox.Show("Usuario no encontrado");
            }
            else
            {
                // Convierte la informacion a tipo cadena
                Informacion_Usuario encontradoAlum = (Informacion_Usuario)arbolUsuarios.buscar(infoUsuario).valorNodo();
                MessageBox.Show("Dato encontrado   " + encontradoAlum.busquedaInfo());

                //EDITAR XML TEMPORAL
                doc = new XmlDocument();

                doc.Load(@"UsuarioTemp.xml");


                XmlElement usuarios = doc.DocumentElement;

                XmlNodeList listaEmpleados = doc.SelectNodes("Usuarios/usuario");

                XmlNode editarUsuario = editarXml(encontradoAlum.usuario, encontradoAlum.nombre, "", encontradoAlum.correo,encontradoAlum.contraseña);

                foreach (XmlNode item in listaEmpleados)
                {

                    //if (item.FirstChild.InnerText == txtUsuario.Text)
                    //{
                        XmlNode nodoOld = item;
                        usuarios.ReplaceChild(editarUsuario, nodoOld);

                    //}
                }

                doc.Save(@"UsuarioTemp.xml");

                Navegation Formulario = new Navegation();
                Formulario.Show();
                this.Hide();
            }
        }

        private XmlNode editarXml(string usuario, string nombre, string biografia, string correo, string contraseña)
        {

            XmlNode usser = doc.CreateElement("usuario");

            XmlElement xmlUsuario = doc.CreateElement("Usuario");
            xmlUsuario.InnerText = usuario;
            usser.AppendChild(xmlUsuario);

            XmlElement xmlNombre = doc.CreateElement("Nombre");
            xmlNombre.InnerText = nombre;
            usser.AppendChild(xmlNombre);

            XmlElement xmlBiografia = doc.CreateElement("Biografia");
            xmlBiografia.InnerText = null;
            usser.AppendChild(xmlBiografia);

            XmlElement xmlCorreo = doc.CreateElement("Correo");
            xmlCorreo.InnerText = correo;
            usser.AppendChild(xmlCorreo);

            XmlElement xmlContraseña = doc.CreateElement("Contraseña");
            xmlContraseña.InnerText = contraseña;
            usser.AppendChild(xmlContraseña);

            XmlElement xmlImg = doc.CreateElement("Img");
            xmlImg.InnerText = "";
            usser.AppendChild(xmlImg);


            return usser;
        }

        private void Login_Inicio_Load(object sender, EventArgs e)
        {
            //arbolUsuarios = new ArbolAvl();
        }
    }
    }

