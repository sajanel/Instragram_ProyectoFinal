using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Presentacion.InterfazUsuario;
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

        public void añadirUsuario(string usuario, string nombre, string biografia, string correo, string contraseña, string img, string fechaUser, string nombreXml)
        {
            auxDoc = new XmlDocument();

            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            XmlNode empleado = nuevoUsuario(usuario, nombre, biografia, correo, contraseña, img, fechaUser);

            XmlNode nodoRaiz = auxDoc.DocumentElement;
            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);

            auxDoc.Save(rutaXml);
        }
        //
        public void añadirPublicacion(string imgPublicacion, string comenUsuario, string nombreXml, string user)
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

        public void añadirInfoAmigo(string urlImg, string infAmigo, string datoCambiante, string datoAmigo, string nombreXml, string user)
        {
            auxDoc = new XmlDocument();
            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            //   XmlElement empleados = auxDoc.DocumentElement;

            XmlNodeList listaEmpleados = auxDoc.SelectNodes("Usuarios/usuario");

            XmlNode nuevo_empleado = nuevosSeguidores(urlImg, infAmigo, datoAmigo);

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
        private XmlNode nuevoUsuario(string usuario, string nombre, string biografia, string correo, string contraseña, string img, string fechaUser)
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

            XmlElement auxFecha = auxDoc.CreateElement("FechaNacimiento");
            auxFecha.InnerText = fechaUser;
            nuevoUsuario.AppendChild(auxFecha);

            XmlElement auxPublic = auxDoc.CreateElement("Publicacion");
            auxPublic.InnerText = "";
            nuevoUsuario.AppendChild(auxPublic);

            XmlElement auxSeguidor = auxDoc.CreateElement("Siguiendo");
            auxSeguidor.InnerText = "";
            nuevoUsuario.AppendChild(auxSeguidor);

            XmlElement auxSiguiendo = auxDoc.CreateElement("Seguidores");
            auxSiguiendo.InnerText = "";
            nuevoUsuario.AppendChild(auxSiguiendo);

            return nuevoUsuario;
        }

        //
        public XmlNode nuevaPublicacion(string publi, string comentario)
        {

            XmlElement Aux = auxDoc.CreateElement("publicacion");
            Aux.InnerText = publi + "," + comentario;

            return Aux;
        }

        public XmlNode nuevosSeguidores(string urlImg, string infAmigo, string datoAmigo)
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
            auxAmigo.InnerText = urlImg + "," + infAmigo;

            return auxAmigo;
        }
        string correo, nombre, usuario, contraseña, img, fechaUsuario;

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
                                break;
                            case "FechaNacimiento":
                                fechaUsuario = reader.ReadString();
                                Program.objUsuarioXml2 = new Usuario.ClaseUsuario(correo, nombre, usuario, contraseña, img, fechaUsuario);
                                Program.objArbolAvl.insertar(Program.objUsuarioXml2);
                                correo = "";
                                nombre = "";
                                usuario = "";
                                contraseña = "";
                                img = "";
                                fechaUsuario = "";
                                break;
                        }

                    }

                }
            }
        }

        public void leerXmlCompleto(string nombreXml)
        {
            //ClaseUsuario miUsuario = new ClaseUsuario();
            //Program.objUsuarioXml2 = new ClaseUsuario();
            auxDoc = new XmlDocument();
            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            XmlNodeList listaUsuarios = auxDoc.SelectNodes("Usuarios/usuario");
            XmlNode unUsuario;

            //USUARIO
            for (int a = 0; a < listaUsuarios.Count; a++)
            {
                unUsuario = listaUsuarios.Item(a);
                string usuario = unUsuario.SelectSingleNode("Usuario").InnerText;
                string nombre = unUsuario.SelectSingleNode("Nombre").InnerText;
                string biografia = unUsuario.SelectSingleNode("Biografia").InnerText;
                string correo = unUsuario.SelectSingleNode("Correo").InnerText;
                string contraseña = unUsuario.SelectSingleNode("Contraseña").InnerText;
                string img = unUsuario.SelectSingleNode("Img").InnerText;
                string fechaNacimiento = unUsuario.SelectSingleNode("FechaNacimiento").InnerText;

                Program.objUsuarioXml2 = new Usuario.ClaseUsuario();
                Program.objUsuarioXml2.usuario = usuario;
                Program.objUsuarioXml2.nombre = nombre;
                Program.objUsuarioXml2.correo = correo;
                Program.objUsuarioXml2.contraseña = contraseña;
                Program.objUsuarioXml2.imagenProfile = img;
                Program.objUsuarioXml2.fechaUsurio = fechaNacimiento;
                //Program.objUsuarioXml2 = new Usuario.ClaseUsuario(correo, nombre, usuario, contraseña, img);


                //PUBLICACION
                XmlNodeList listaPublicaciones = unUsuario.SelectNodes("Publicacion/publicacion");
                XmlNode unaPublicacion;
                for (int b = 0; b < listaPublicaciones.Count; b++)
                {
                    unaPublicacion = listaPublicaciones.Item(b);
                    string miPublicacion = unaPublicacion.InnerText;
                    Program.objUsuarioXml2.insertarPublicaciones(miPublicacion);
                }

                //SIGUIENDO
                XmlNodeList listaSiguiendo = unUsuario.SelectNodes("Siguiendo/siguiendo");
                XmlNode unSeguiendo;
                for (int c = 0; c < listaSiguiendo.Count; c++)
                {
                    unSeguiendo = listaSiguiendo.Item(c);
                    string siguiendo = unSeguiendo.InnerText;
                    byte[] asscInt = Encoding.ASCII.GetBytes(siguiendo);
                    string cadena = "";
                    foreach (byte item in asscInt)
                    {
                        cadena = cadena + item;
                    }

                    string nuevo = siguiendo;
                    string[] palabras = nuevo.Split(',');

                    ClasePerfil miPerfilUsuario = new ClasePerfil(palabras[0], palabras[1]);

                    Program.objUsuarioXml2.insertarSiguiendo(miPerfilUsuario, Convert.ToString(cadena));
                }
                //SEGUIDORES
                XmlNodeList listaSeguidores = unUsuario.SelectNodes("Seguidores/seguidor");
                XmlNode unSeguidor;
                for (int d = 0; d < listaSeguidores.Count; d++)
                {
                    unSeguidor = listaSeguidores.Item(d);
                    string seguidores = unSeguidor.InnerText;
                    byte[] asscInt = Encoding.ASCII.GetBytes(seguidores);
                    string cadena = "";
                    foreach (byte item in asscInt)
                    {
                        cadena = cadena + item;
                    }

                    string nuevos = seguidores;
                    string[] palabra = nuevos.Split(',');

                    ClasePerfil miPerfilUsuario2 = new ClasePerfil(palabra[0], palabra[1]);

                    Program.objUsuarioXml2.insertarSeguidores(miPerfilUsuario2, Convert.ToString(cadena));
                }


                Program.objArbolAvl.insertar(Program.objUsuarioXml2);
            }
        }

      
        public void actualizarUsuario(string usuario, string nombre, string biografia, string correo, string contraseña, string img, string nombreXml, string fechaUser)
        {
            auxDoc = new XmlDocument();

            rutaXml = @"" + nombreXml + ".xml";

            auxDoc.Load(rutaXml);

            XmlElement empleados = auxDoc.DocumentElement;

            XmlNodeList listaEmpleados = auxDoc.SelectNodes("Usuarios/usuario");

            XmlNode nuevo_empleado = nuevoUsuario(usuario, nombre, biografia, correo, contraseña, img, fechaUser);

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

        public void eliminarUsuario(string id_borrar, string nombreXml)
        {

            auxDoc = new XmlDocument();

            rutaXml = @"" + nombreXml + ".xml";

            auxDoc.Load(rutaXml);

            XmlNode empleados = auxDoc.DocumentElement;

            XmlNodeList listaEmpleados = auxDoc.SelectNodes("Usuarios/usuario");

            foreach (XmlNode item in listaEmpleados)
            {
                if (item.SelectSingleNode("Usuario").InnerText == id_borrar)
                {

                    XmlNode nodoOld = item;

                    empleados.RemoveChild(nodoOld);
                }
            }
            auxDoc.Save(rutaXml);
        }

        public void eliminarPublicacion(string id_Publicacion, string id_Usuario, string nombreXml)
        {
            auxDoc = new XmlDocument();

            rutaXml = @"" + nombreXml + ".xml";

            auxDoc.Load(rutaXml);

            XmlNodeList listaUsuarios = auxDoc.SelectNodes("Usuarios/usuario");


            foreach (XmlNode item in listaUsuarios)
            {
                if (item.SelectSingleNode("Usuario").InnerText == id_Usuario)
                {
                    XmlNodeList listaPublicaciones = item.SelectNodes("Publicacion/publicacion");
                    XmlElement el = (XmlElement)item.SelectSingleNode("Publicacion/publicacion");

                    foreach (XmlNode items in listaPublicaciones)
                    {
                        //string[] auxPublicacion2 = items.SelectSingleNode("publicacion").InnerText.Split(',');
                        string[] auxPublicacion2 = items.InnerText.Split(',');
                        if (auxPublicacion2[0] == id_Publicacion)
                        {
                            XmlNode nodoPadres = listaUsuarios.Item(0);
                            //XmlNode nodoPadre = item.SelectSingleNode("Publicacion");
                            XmlNode nodoOld = items;
                            el.ParentNode.RemoveChild(nodoOld);
                        }
                    }
                }
            }
            auxDoc.Save(rutaXml);
        }

        public void leerPublicaciones(string idUsuario, string nombreXml)
        {
            auxDoc = new XmlDocument();
            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            XmlNodeList listaUsuarios = auxDoc.SelectNodes("Usuarios/usuario");
            XmlNode unUsuario;


            string[] palabras = idUsuario.Split(',');

            //USUARIO
            for (int a = 0; a < listaUsuarios.Count; a++)
            {
                unUsuario = listaUsuarios.Item(a);
                string usuario = unUsuario.SelectSingleNode("Usuario").InnerText;

                for (int i = 0; i < palabras.Length-1; i++)
                {
                    if (usuario == palabras[i])
                    {
                        //PUBLICACION
                        XmlNodeList listaPublicaciones = unUsuario.SelectNodes("Publicacion/publicacion");
                        XmlNode unaPublicacion;
                        for (int b = 0; b < listaPublicaciones.Count; b++)
                        {
                            unaPublicacion = listaPublicaciones.Item(b);
                            string miPublicacion = unaPublicacion.InnerText;

                            //Program.objUsuarioXml2.insertarPublicaciones(miPublicacion);
                            Program.navPublicaciones.insertarAlInicio(miPublicacion);
                        }

                    }
                }
                

            }
        }


        public void listaDoblePublicaciones(string idUsuario, string nombreXml)
        {
            auxDoc = new XmlDocument();
            rutaXml = @"" + nombreXml + ".xml";
            auxDoc.Load(rutaXml);

            XmlNodeList listaUsuarios = auxDoc.SelectNodes("Usuarios/usuario");
            XmlNode unUsuario;

            //USUARIO
            for (int a = 0; a < listaUsuarios.Count; a++)
            {
                unUsuario = listaUsuarios.Item(a);
                string usuario = unUsuario.SelectSingleNode("Usuario").InnerText;

                if (usuario == idUsuario)
                {
                    //PUBLICACION
                    XmlNodeList listaPublicaciones = unUsuario.SelectNodes("Publicacion/publicacion");
                    XmlNode unaPublicacion;
                    for (int b = 0; b < listaPublicaciones.Count; b++)
                    {
                        unaPublicacion = listaPublicaciones.Item(b);
                        string miPublicacion = unaPublicacion.InnerText;


                        ClaseUsuario objUsuario = new ClaseUsuario(idUsuario);
                        ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();
                        encontradoUsuario.insertarPublicaciones(miPublicacion);


                    }

                }


            }
        }
    }
}
