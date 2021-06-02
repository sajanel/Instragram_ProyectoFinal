using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Usuario
{
    class PublicacionesUsuario
    {
        //Variables que son necesarias para el muro de la persona
        public string comentarioPublicacion { get; set; }
        public string imagPublicacion { get; set; }

        //Constructor con parametros
        public PublicacionesUsuario(string comentarioPublicacion, string imagPublicacion )
        {
            this.comentarioPublicacion = comentarioPublicacion;
            this.imagPublicacion = imagPublicacion;

        }

        //Constructor vacio
        public PublicacionesUsuario(){ }

        //Este metodo nos ayudara para tomar la informacion de la cadena
        public override string ToString()
        {
            return imagPublicacion;
            //return comentarioPublicacion+","+ imagPublicacion;
        }
    }
}
