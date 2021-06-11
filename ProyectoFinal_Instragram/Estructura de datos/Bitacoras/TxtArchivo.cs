using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;

namespace ProyectoFinal_Instragram.Estructura_de_datos.Vitacoras
{
    class TxtArchivo
    {
        public void limiarTxt()
        {
            TextWriter escribirDato = new StreamWriter("Vitacora.txt", false);
            escribirDato.Write("");
            escribirDato.Close();
        }
        public void vitacoraArbol(int valEquilibrio, string rotacionArbol, NodoAvl miArbol)
        {
            int contado = 0;
      
            TextWriter escribirDato = new StreamWriter("Vitacora.txt", true);

            string nuevo = ArbolAvl.rcPreorden(miArbol);

            string[] palabras = nuevo.Split(',', ';');
            string variable = "";

            foreach (string palabra in palabras)
            {
                contado++;
                if (palabra != "" && contado % 2 == 0)
                {
                    variable = variable + " -- " + palabra;
                }
            }
            escribirDato.WriteLine(variable + "-> " + rotacionArbol + "-> " + valEquilibrio);
            escribirDato.Close();
        }

        //Leer en un archivo

    }
}
