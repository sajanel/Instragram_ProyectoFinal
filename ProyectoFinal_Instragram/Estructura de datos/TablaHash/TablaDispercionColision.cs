﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal_Instragram.Estructura_de_datos.TablaHash.ListaSimple;
namespace ProyectoFinal_Instragram.Estructura_de_datos.TablaHash
{
    public class TablaDispercionColision
    {
        public static readonly int M = 124;
        public static readonly double R = 0.618034;
        int Posicion;
        public int cont { get; set; }

        Lista[] tabla = new Lista[M];


        public int DispersionMod(String Clave)
        {
            double x;
            x = Convert.ToDouble(Clave.Substring(0, 4));
            return Convert.ToInt16(x % M);
        }

        public void Insertar(Object Dato, String Clave)
        {
            Posicion = DispersionMod(Clave);
            if (tabla[Posicion] == null)
            {
                tabla[Posicion] = new Lista();
            }
            tabla[Posicion].insertarCabezaLista(Dato);
            cont++;
        }

        public void Eliminar(String Clave)
        {
            Posicion = DispersionMod(Clave);
            tabla[Posicion] = null;
        }

        public object Buscar(String Clave)
        {
            //lh = 89
            Posicion = DispersionMod(Clave);

            //49,89,100
            if (tabla[Posicion]==null)
                return null;
            else
                return tabla[Posicion].BuscarNodo(Clave);
        }

    }
}
