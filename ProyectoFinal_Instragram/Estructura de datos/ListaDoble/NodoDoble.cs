using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble
{
    class NodoDoble
    {
        public object dato;
        public NodoDoble siguiente;
        public NodoDoble anterior;

        public NodoDoble(object n)
        {
            dato = n;
            siguiente = null;
            anterior = null;
        }

        public NodoDoble(object n, NodoDoble a, NodoDoble b)
        {
            dato = n;
            siguiente = a;
            anterior = b;
        }

    }
}
