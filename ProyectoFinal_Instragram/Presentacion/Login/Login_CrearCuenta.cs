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

namespace ProyectoFinal_Instragram.Presentacion.Login
{
    public partial class Login_CrearCuenta : Form
    {
        ArbolAvl arbol;
        Informacion_Usuario objUsuario;
        Informacion_Usuario objUsuarioXml;
        public Login_CrearCuenta()
        {
            InitializeComponent();
        }
        XmlDocument doc;
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
        string correo;
        string nombre;
        string usuario;
        string contraseña;
        string img;
        private void leerXml()
        {
            

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
                                arbol.insertar(objUsuarioXml);
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
        }
        private void bntRegistrarUsuario_Click(object sender, EventArgs e)
        {
            //Aca deberia leer un xml e insetarlo en un arbol
            //y permitir colocar un foto de usuario y almacenarlo en el xml
            doc = new XmlDocument();
            doc.Load(@"UsuariosInsta.xml");

            XmlNode empleado = nuevoUsuario(txtUsuario.Text, txtNombre.Text, txtCorreo.Text,txtContraseña.Text);
            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);
            doc.Save(@"UsuariosInsta.xml");

            leerXml();

            objUsuario = new Informacion_Usuario(txtCorreo.Text, txtNombre.Text, txtUsuario.Text,
                txtContraseña.Text, "direccion imagen");
                        
            
            //arbol.insertar(objUsuario);
        }
        private XmlNode nuevoUsuario(string usuario, string nombre, string correo, string contraseña)
        {

            XmlNode usser = doc.CreateElement("usuario");

            XmlElement xmlUsuario = doc.CreateElement("Usuario");
            xmlUsuario.InnerText = usuario;
            usser.AppendChild(xmlUsuario);

            XmlElement xmlNombre = doc.CreateElement("Nombre");
            xmlNombre.InnerText = nombre;
            usser.AppendChild(xmlNombre);

            XmlElement xmlBiografia = doc.CreateElement("Biografia");
            xmlBiografia.InnerText = "";
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
        private void Login_CrearCuenta_Load(object sender, EventArgs e)
        {
            arbol = new ArbolAvl();
        }
    }
}
