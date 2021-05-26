using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_Instragram.Estructura_de_datos.TablaHash.ListaSimple
{
  public class Nodo
    { 
       public Object Dato;
       public Nodo Enlace;
         public Nodo(Object vDato)
         {
             Dato = vDato;
             Enlace = null;
         }
        }
    }

