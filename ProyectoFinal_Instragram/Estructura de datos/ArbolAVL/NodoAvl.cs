using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL
{
    public class NodoAvl : Nodo
    {
        public int fe;

        public NodoAvl(object valorDato) : base(valorDato)
        {
            fe = 0;
        }

        public NodoAvl(object valorDato, NodoAvl ramaIzdo, NodoAvl ramaDcho) : base(ramaIzdo, valorDato, ramaDcho)
        {
            fe = 0;
        }


    }


}
