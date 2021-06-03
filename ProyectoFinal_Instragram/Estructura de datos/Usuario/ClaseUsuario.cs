using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble;
using ProyectoFinal_Instragram.Estructura_de_datos.TablaHash;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Usuario
{
    public class ClaseUsuario : Comparador
    {
        public string correo { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string imagenProfile { get; set; }

        public listaDoble miLista;
        public string comentarioUsuario { get; set; }
        public string imgPublicacion { get; set; }

        public TablaDispercionColision tablaHashSeguidores;

        public TablaDispercionColision tablaHashSeguidos;

        public ClaseUsuario(string correo, string nombre, string usuario, string contraseña, string imagenProfile)
        {
            this.correo = correo;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.imagenProfile = imagenProfile;
        }

        public ClaseUsuario()
        {
            miLista = new listaDoble();
            tablaHashSeguidores = new TablaDispercionColision();
            tablaHashSeguidos = new TablaDispercionColision();
        }

        //Insercion de los datos a una lista doble
        public listaDoble instarPublicacion(string comenUsuario,string imgPublica)
        {
            comentarioUsuario = comenUsuario;
            imgPublicacion = imgPublica;

            PublicacionesUsuario inforPublic = new PublicacionesUsuario(comenUsuario, imgPublica);
            miLista.insertarAlInicio(inforPublic);
            return miLista;

        }
        public void insertarPublicaciones(string publicacion)
        {
            string[] auxPublicacion = publicacion.Split(',');

            comentarioUsuario = auxPublicacion[1];
            imgPublicacion = auxPublicacion[0];

            PublicacionesUsuario misPublicaciones = new PublicacionesUsuario(comentarioUsuario, imgPublicacion);
            miLista.insertarAlInicio(misPublicaciones);
        }
        public void insertarSeguidores(string oj, string user)
        {
            tablaHashSeguidores.Insertar(oj, user);
        }
        public void insertarSiguiendo(string oj, string user)
        {
            tablaHashSeguidos.Insertar(oj, user);
        }
        public ClaseUsuario(string userUsuario, string contraseñaUsuario)
        {
            this.usuario = userUsuario;
            this.contraseña = contraseñaUsuario;
        }
        //PARA BUSCAR USUARIO
        public ClaseUsuario(string user)
        {
            this.usuario = user;
        }
        public bool ContraseñaDiferente(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.contraseña.CompareTo(contraseña) != 0); 
        }

        public bool ContraseñaIgual(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.contraseña.CompareTo(contraseña) == 0);
        }

        public bool UsuarioDiferente(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.usuario.CompareTo(usuario) != 0);
        }

        public bool UsuarioIgual(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.usuario.CompareTo(usuario) == 0);
        }


        public bool UsuarioMayor(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.usuario.CompareTo(usuario) == 1);
        }
        
        public bool UsuarioMenor(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.usuario.CompareTo(usuario) == -1);
        }

        public string busquedaInfo()
        {
            return correo + ", " + nombre + ", " + usuario + ", " + imagenProfile + ", " + contraseña;
        }

        public override string ToString()
        {
            return usuario + ",";
        }
    }
}
