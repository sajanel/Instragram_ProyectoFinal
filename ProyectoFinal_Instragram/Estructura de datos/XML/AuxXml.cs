using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProyectoFinal_Instragram.Estructura_de_datos.XML
{
    public class AuxXml
    {
        string rutaXml; 
        XmlDocument auxDoc;
        public void crearXml(string nombreXml)
        {
            rutaXml = @"" + nombreXml + ".xml";

            bool estadoArchivo = File.Exists(rutaXml);

            if (estadoArchivo == false)
            {
                auxDoc = new XmlDocument();

                XmlDeclaration xmlDeclaration = auxDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

                XmlNode root = auxDoc.DocumentElement;
                auxDoc.InsertBefore(xmlDeclaration, root);

                XmlNode elemento = auxDoc.CreateElement("Usuarios");
                auxDoc.AppendChild(elemento);
                auxDoc.Save(rutaXml);
            }
            string urlFolder = @"Perfiles";
            if (!Directory.Exists(urlFolder))
            {
                Directory.CreateDirectory(urlFolder);
            }
        }

        public void eliminarXml(string nombreXml)
        {
            rutaXml = @"" + nombreXml + ".xml";

            File.Delete(rutaXml);
        }

        public void añadirUsuario(string usuario, string nombre, string biografia, string correo, string contraseña, string img, string nombreXml)
        {
            auxDoc = new XmlDocument();

            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            XmlNode empleado = nuevoUsuario(usuario,nombre,biografia,correo,contraseña,img);

            XmlNode nodoRaiz = auxDoc.DocumentElement;
            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);

            auxDoc.Save(rutaXml);
        }
        //
        public void añadirPublicacion(string imgPublicacion,string comenUsuario, string nombreXml,string user) 
        {
            auxDoc = new XmlDocument();
            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            XmlElement empleados = auxDoc.DocumentElement;

            XmlNodeList listaEmpleados = auxDoc.SelectNodes("Usuarios/usuario");

            XmlNode nuevo_empleado = nuevaPublicacion(imgPublicacion, comenUsuario);

          //  XmlNode nodoRaiz = auxDoc.SelectSingleNode("Usuarios/usuario/Publicacion");
            foreach (XmlNode item in listaEmpleados)
            {
                if (item.FirstChild.InnerText == user)
                {
                    XmlNode nodoOld = item.SelectSingleNode("Publicacion");
                    nodoOld.InsertBefore(nuevo_empleado, nodoOld.FirstChild);
                }
                auxDoc.Save(rutaXml);
            }
        }

        public void añadirInfoAmigo(string infAmigo, string datoCambiante, string datoAmigo, string nombreXml, string user)
        {
            auxDoc = new XmlDocument();
            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

         //   XmlElement empleados = auxDoc.DocumentElement;

            XmlNodeList listaEmpleados = auxDoc.SelectNodes("Usuarios/usuario");

            XmlNode nuevo_empleado = nuevosSeguidores(infAmigo,datoAmigo);

            //XmlNode nodoRaiz = auxDoc.SelectSingleNode("Usuarios/usuario/"+datoCambiante+"/"+datoAmigo);
            foreach (XmlNode item in listaEmpleados)
            {
                if (item.FirstChild.InnerText == user)
                {
                    XmlNode nodoOld = item.SelectSingleNode(datoCambiante);
                    nodoOld.InsertBefore(nuevo_empleado, nodoOld.FirstChild);
                }
                auxDoc.Save(rutaXml);
            }
        }


        public void crearCarpeta(string usuario, string nombreXml)
        {
            if (nombreXml == "UsuariosInsta")
            {
                string urlFolder = @"Perfiles";
                if (!Directory.Exists(urlFolder))
                {
                    Directory.CreateDirectory(urlFolder);
                }
                else if (!Directory.Exists(@"Perfiles/" + usuario))
                {
                    Directory.CreateDirectory(@"Perfiles/" + usuario);
                }
            }
        }
        private XmlNode nuevoUsuario(string usuario, string nombre, string biografia, string correo, string contraseña, string img)
        {
            XmlNode nuevoUsuario = auxDoc.CreateElement("usuario");
            
            XmlElement auxUsuario = auxDoc.CreateElement("Usuario");
            auxUsuario.InnerText = usuario;
            //auxUsuario.SetAttribute("Id","08");
            nuevoUsuario.AppendChild(auxUsuario);

            XmlElement auxNombre = auxDoc.CreateElement("Nombre");
            auxNombre.InnerText = nombre;
            nuevoUsuario.AppendChild(auxNombre);

            XmlElement auxBio = auxDoc.CreateElement("Biografia");
            auxBio.InnerText = biografia;
            nuevoUsuario.AppendChild(auxBio);

            XmlElement auxCorreo = auxDoc.CreateElement("Correo");
            auxCorreo.InnerText = correo;
            nuevoUsuario.AppendChild(auxCorreo);

            XmlElement auxContraseña = auxDoc.CreateElement("Contraseña");
            auxContraseña.InnerText = contraseña;
            nuevoUsuario.AppendChild(auxContraseña);

            XmlElement auxImg = auxDoc.CreateElement("Img");
            auxImg.InnerText = img;
            nuevoUsuario.AppendChild(auxImg);

            XmlElement auxPublic = auxDoc.CreateElement("Publicacion");
            auxPublic.InnerText = "";
            nuevoUsuario.AppendChild(auxPublic);

            XmlElement auxSeguidor = auxDoc.CreateElement("Siguiendo");
            auxSeguidor.InnerText = "";
            nuevoUsuario.AppendChild(auxSeguidor);

            XmlElement auxSiguiendo= auxDoc.CreateElement("Seguidores");
            auxSiguiendo.InnerText = "";
            nuevoUsuario.AppendChild(auxSiguiendo);

            return nuevoUsuario;
        }

        //
        public XmlNode nuevaPublicacion(string publi,string comentario)
        {

            XmlElement Aux = auxDoc.CreateElement("publicacion");
            Aux.InnerText = publi+","+comentario;

            return Aux;
        }

        public XmlNode nuevosSeguidores(string infAmigo,string datoAmigo)
        {
            /*
                <Seguidores>           
                    <seguidor> 1 </seguidor>  string datoAmigo
                </seguidores>
               
                <Siguiendo>         
                    <seguir> 2 </seguir>     string datoAmigo
                </Siguiendo>
             */
            //Aca le enviamos una variable indicandole si va a ser seguidor o seguido   

            XmlElement auxAmigo = auxDoc.CreateElement(datoAmigo);
            auxAmigo.InnerText = infAmigo;
         
            return auxAmigo;
        }
        string correo,nombre,usuario,contraseña,img;
      
        public void leerXml(string nombreXml)
        {
            rutaXml = @"" + nombreXml + ".xml";
            using (XmlReader reader = XmlReader.Create(rutaXml))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
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
                                Program.objUsuarioXml2 = new Usuario.ClaseUsuario(correo, nombre, usuario, contraseña, img);
                                Program.objArbolAvl.insertar(Program.objUsuarioXml2);
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


        public void actualizarUsuario(string usuario, string nombre, string biografia, string correo, string contraseña, string img, string nombreXml)
        {
            auxDoc = new XmlDocument();

            rutaXml = @"" + nombreXml + ".xml";

            XmlElement empleados = auxDoc.DocumentElement;

            XmlNodeList listaEmpleados = auxDoc.SelectNodes("Usuarios/usuario");

            XmlNode nuevo_empleado = nuevoUsuario(usuario, nombre, biografia, correo, contraseña, img);

            foreach (XmlNode item in listaEmpleados)
            {
                if (item.FirstChild.InnerText == usuario)
                {
                    XmlNode nodoOld = item;
                    empleados.ReplaceChild(nuevo_empleado, nodoOld);

                }
            }
            auxDoc.Save(rutaXml);
        }

    }
}
