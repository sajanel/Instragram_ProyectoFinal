using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Usuario
{
    public class ClaseUsuario : Comparador
    {

        public string correo { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string imagenProfile { get; set; }

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
        }

        public ClaseUsuario(string correoUsuario, string contraseñaUsuario)
        {
            this.correo = correoUsuario;
            this.contraseña = contraseñaUsuario;
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
            return (info_Usuario.correo.CompareTo(correo) != 0);
        }

        public bool UsuarioIgual(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.correo.CompareTo(correo) == 0);
        }


        public bool UsuarioMayor(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.correo.CompareTo(correo) == 1);
        }
        
        public bool UsuarioMenor(object q)
        {
            ClaseUsuario info_Usuario = (ClaseUsuario)q;
            return (info_Usuario.correo.CompareTo(correo) == -1);
        }

        public string busquedaInfo()
        {
            return correo+ "," + nombre + "," + usuario + "," + imagenProfile + "," +
                contraseña;
        }
    }
}
