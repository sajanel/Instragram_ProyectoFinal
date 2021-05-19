﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
namespace ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL
{
    public class ArbolAvl : ArbolBinario
    {
        protected NodoAvl arbolRaiz;

        public ArbolAvl()
        {
            arbolRaiz = null;
        }

        public NodoAvl raizArbol()
        {
            return arbolRaiz;
        }

        private NodoAvl rotacionII(NodoAvl n, NodoAvl n1)
        {
            n.ramaIzq(n1.subarbolDch());
            n1.ramaDch(n);
            // Verifica que que el arbol este en equilibrio
            if (n1.fe == -1) // de ser asi se cumplira esta funcion
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;//De lo contrario hara una rotacion izquierda izquierda
                n1.fe = 1;
            }
            return n1;
        }


        private NodoAvl rotacionDD(NodoAvl n, NodoAvl n1)
        {
            n.ramaDch(n1.subarbolIzq());
            n1.ramaIzq(n);
            // Verifica que que el arbol este en equilibrio
            if (n1.fe == +1) // de ser asi se cumplira esta funcion
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;//De lo contrario hara una rotacion derecha,derecha
                n1.fe = -1;
            }
            return n1;
        }


        private NodoAvl rotacionID(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolDch();
            n.ramaIzq(n2.subarbolDch());
            n2.ramaDch(n);
            n1.ramaDch(n2.subarbolIzq());
            n2.ramaIzq(n1);
            // Se actualizan para la equilibracion
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
        }


        private NodoAvl rotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolIzq();
            n.ramaDch(n2.subarbolIzq());
            n2.ramaIzq(n);
            n1.ramaIzq(n2.subarbolDch());
            n2.ramaDch(n1);
            // factores de equilibrio en actualizacion
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;
            n2.fe = 0;
            return n2;
        }


        public void insertar(Object valor)
        {
            Comparador dato;
            Logical h = new Logical(false); // Aca utlizamos la clase logical y for defecto falso
            dato = (Comparador)valor;//El comprador que nos ayudara a comprar datos del arbol
            arbolRaiz = insertarAvl(arbolRaiz, dato, h);//metodo recursivo para la insercion de los datos
        }

        private NodoAvl insertarAvl(NodoAvl raiz, Comparador dt, Logical h)
        {
            NodoAvl n1;
            if (raiz == null)
            {
                raiz = new NodoAvl(dt);
                h.enviarLogica(true);
            }

            else if (dt.UsuarioMenor(raiz.valorNodo()))
            {
                NodoAvl iz;
                iz = insertarAvl((NodoAvl)raiz.subarbolIzq(), dt, h);
                raiz.ramaIzq(iz);
                //De verificar la rama izquierda en donde se insertara el nodo
                if (h.valorLogico())//obtiene un dato para verificar si hay datos
                {
                    switch (raiz.fe)
                    {
                        case 1:
                            raiz.fe = 0;
                            h.enviarLogica(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (NodoAvl)raiz.subarbolIzq();
                            if (n1.fe == -1)
                                raiz = rotacionII(raiz, n1);
                            else
                                raiz = rotacionID(raiz, n1);
                            h.enviarLogica(false);
                            break;

                    }
                }
            }
            else if (dt.UsuarioMayor(raiz.valorNodo()))
            {
                NodoAvl dr;
                dr = insertarAvl((NodoAvl)raiz.subarbolDch(), dt, h);
                raiz.ramaDch(dr);

                if (h.valorLogico())
                {

                    switch (raiz.fe)
                    {
                        case 1: // aplicar rotación a la derecha
                            n1 = (NodoAvl)raiz.subarbolDch();
                            if (n1.fe == +1)
                                raiz = rotacionDD(raiz, n1);
                            else
                                raiz = rotacionDI(raiz, n1);
                            h.enviarLogica(false);
                            break;
                        case 0:
                            raiz.fe = +1;
                            break;
                        case -1:
                            raiz.fe = 0;
                            h.enviarLogica(false);
                            break;
                    }

                }
            }
            else throw new Exception("No puede haber claves repetidas ");

            return raiz;
        }

        //El metodo buscar es llamada desde el form para su ejecucion
        public Nodo buscar(Object buscado)
        {
            Comparador dato;
            dato = (Comparador)buscado;
           

            if (arbolRaiz == null)
                return null;
            else
                return buscar(raizArbol(), dato) ;
        }

        //Metodo de buscar en el que utiliza recursividad para poder buscar en cada nodo
        protected Nodo buscar(Nodo raizSub, Comparador buscado)
        {

            if (raizSub == null)
                return null;
            else if (buscado.ContraseñaIgual(raizSub.valorNodo()) && buscado.UsuarioIgual(raizSub.valorNodo()))
                return raizSub;
            else if (buscado.ContraseñaDiferente(raizSub.valorNodo()) || buscado.UsuarioIgual(raizSub.valorNodo()))
                return buscar(raizSub.subarbolIzq(), buscado);
            else 
                return buscar(raizSub.subarbolDch(), buscado);
            return null;
        }

        //Este es el metodo implementado para buscar en todo el arbol el dato
        //Este retorna un tostring idfirstIdAlumno+"-"+secondIdAlumno+" " + nombreAlumno + ",";
        //El id lo dividi para la insercion y busqueda sean mas sencilla
        //public string buscarlo(Object buscado)
        //{
        //    Comparador dato;
        //    dato = (Comparador)buscado;
        //    if (arbolRaiz == null)
        //        return null;
        //    else

        //        return rcPreorden(raizArbol(), dato);
        //}


        //Este metodo recursivo tiene la capacidad de recorrer todo el arbol
        //Y me retorna la informacion que yo compare.
        //El tipo de busque que yo realice es de tipo Preorden
        //static public string rcPreorden(Nodo r, Comparador dato)
        //{
        //    if (r != null)
        //    {
        //        if (dato.CorreoDiferente(r.valorNodo()))
        //            return rcPreorden(r.subarbolIzq(), dato) + rcPreorden(r.subarbolDch(), dato);

        //        else if (dato.CorreoIgual(r.valorNodo()))
        //        {
        //            return r.visitarNodo();

        //        }

        //    }
        //    return "";
        //}
    }
}
