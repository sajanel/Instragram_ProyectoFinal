using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Usuario
{
    public interface Comparador
    {
        public bool UsuarioIgual(object q);
        public bool UsuarioDiferente(object q);
        public bool ContraseñaIgual(object q);
        public bool ContraseñaDiferente(object q);
        public bool UsuarioMayor(object q);
        public bool UsuarioMenor(object q);
        public bool BusquedaAvanzada(object q);

    }
}
