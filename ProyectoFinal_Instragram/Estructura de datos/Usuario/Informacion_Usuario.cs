using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Usuario
{
    class Informacion_Usuario : Comparador
    {

        public string nombreUsuario { get; set; }
        public string nombrePersona { get; set; }
        public string fechaNacimiento { get; set; }
        public string imagenProfile { get; set; }
        public string contraseñaUsuario { get; set; }

        public Informacion_Usuario(string nombreUsuario, string nombrePersona, string fechaNacimiento, string imagenProfile, string contraseñaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.nombrePersona = nombrePersona;
            this.fechaNacimiento = fechaNacimiento;
            this.imagenProfile = imagenProfile;
            this.contraseñaUsuario = contraseñaUsuario;
        }

        public Informacion_Usuario(string nombreUsuario, string contraseñaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.contraseñaUsuario = contraseñaUsuario;
        }

        public bool ContraseñaDiferente(object q)
        {
            Informacion_Usuario info_Usuario = (Informacion_Usuario)q;
            return (info_Usuario.contraseñaUsuario.CompareTo(contraseñaUsuario) != 0); 
        }

        public bool ContraseñaIgual(object q)
        {
            Informacion_Usuario info_Usuario = (Informacion_Usuario)q;
            return (info_Usuario.contraseñaUsuario.CompareTo(contraseñaUsuario) == 0);
        }

        public bool UsuarioDiferente(object q)
        {
            Informacion_Usuario info_Usuario = (Informacion_Usuario)q;
            return (info_Usuario.nombreUsuario.CompareTo(nombreUsuario) != 0);
        }

        public bool UsuarioIgual(object q)
        {
            Informacion_Usuario info_Usuario = (Informacion_Usuario)q;
            return (info_Usuario.nombreUsuario.CompareTo(nombreUsuario) == 0);
        }


        public bool UsuarioMayor(object q)
        {
            Informacion_Usuario info_Usuario = (Informacion_Usuario)q;
            return (info_Usuario.nombreUsuario.CompareTo(nombreUsuario) == 1);
        }
        
        public bool UsuarioMenor(object q)
        {
            Informacion_Usuario info_Usuario = (Informacion_Usuario)q;
            return (info_Usuario.nombreUsuario.CompareTo(nombreUsuario) == -1);
        }

        public string busquedaInfo()
        {
            return nombreUsuario+ "," + nombrePersona + "," + fechaNacimiento + " " + imagenProfile + "," +
                contraseñaUsuario;
        }
    }
}
