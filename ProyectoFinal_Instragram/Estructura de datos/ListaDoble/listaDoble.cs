using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.ListaDoble
{
  public class listaDoble
    {

        public NodoDoble inicio, fin;

        public listaDoble()
        {
            inicio = fin = null;
        }

        /*Metodo para ver si la lista esta vacia*/

        public Boolean Listavacia()
        {
            return inicio == null;
        }

        /*Metodo para agregar nodos al final*/

        public void insertarAlFinal(object n)
        {
            if (!Listavacia())
            {
                fin = new NodoDoble(n, null, fin);
                fin.anterior.siguiente = fin;
            }
            /*Esta vacia*/

            else
            {
                inicio = fin = new NodoDoble(n);
            }

        }

        /*Insertar al inicio de la lista*/
        public void insertarAlInicio(object n)
        {
            if (!Listavacia())
            {
                inicio = new NodoDoble(n, inicio, null);
                inicio.siguiente.anterior = inicio;
            }
            /*Esta vacia*/

            else
            {
                inicio = fin = new NodoDoble(n);
            }

        }

        /*Quita el dato del inicio de la lista doblemente enlazada*/
        public object QuitarDatoInicio()
        {
            object dato = inicio.dato;

            if (inicio == fin)
            {
                inicio = fin = null;
            }

            else
            {
                inicio = inicio.siguiente;
                inicio.anterior = null;

            }

            return dato;

        }

        /*Quita el dato del final de la lista doblemente enlazada*/
        public object QuitarDatoFinal()
        {
            object dato = fin.dato;

            if (inicio == fin)
            {
                inicio = fin = null;
            }

            else
            {
                fin = fin.anterior;
                fin.siguiente = null;
            }

            return dato;
        }
    }
}

