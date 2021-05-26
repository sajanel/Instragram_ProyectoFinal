using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.TablaHash.ListaSimple
{
  public class Lista
    {
        public Nodo primero;

        public Lista()
        {
            primero = null;
        }

        public Lista insertarCabezaLista(Object vDato)
        {
            Nodo nuevo;
            nuevo = new Nodo(vDato);
            nuevo.Enlace = primero;
            primero = nuevo;
            return this;
        }

        public Object BuscarNodo(Object pValor)
        {
            Nodo temp = primero;
            int posicion = 1;

            while (temp != null && !temp.Dato.Equals(pValor))
            {
                temp = temp.Enlace;
                posicion++;
            }
            return (temp == null) ? null : temp.Dato;
        }

        public String MuestraLista()
        {
            Nodo temp = primero;
            String resultado = "";
            while (temp != null)
            {
                resultado = resultado + temp.Dato + " - ";
                temp = temp.Enlace;
            }
            return resultado;
        }

    }
}
