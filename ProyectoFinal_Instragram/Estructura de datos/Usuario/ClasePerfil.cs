using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Usuario
{
    public class ClasePerfil
    {
        public string imgPerfil { get; set; }
        public string usuario { get; set; }
        
        public ClasePerfil(string imgPerfil, string usuario)
        {
            this.imgPerfil = imgPerfil;
            this.usuario = usuario;
        }

        public override string ToString()
        {
            return imgPerfil + "," + usuario + ";";
        }
    }
}
