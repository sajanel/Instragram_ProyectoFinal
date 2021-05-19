using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL
{
    class Logical
    {
        Boolean v;

        public Logical(Boolean f)
        {
            v = f;
        }
        public void enviarLogica(Boolean f)
        {
            v = f;
        }
        public Boolean valorLogico()
        {
            return v;
        }
    }
}
