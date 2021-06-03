using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinal_Instragram.Presentacion.Grafico_Arbol
{
    class AuxDibujar
    {
        private AxArbol raiz = null;  ///Raiz del arbol
        public int contador { get; set; }
        PictureBox ptb;  ///Mostrar el arbol
        Bitmap b;
        Graphics g;
        Pen lapiz;

        Pen borde = new Pen(Color.FromArgb(89, 132, 174), 3);
        //Pen linea1 = new Pen(Color.FromArgb(61, 33, 163), 3);

        // int despX1=150;
       // int despX2 = 150;
        int despY = 40;
        int raizX;
        int raizY;
       // int contador = 0;


        public AxArbol Raiz
        {
            get
            {
                return raiz;
            }
        }

        public AuxDibujar() //Contructor vacio
        {

        }

        public AuxDibujar(PictureBox ptb)
        {
            this.ptb = ptb;
            lapiz = new Pen(Color.BlanchedAlmond, 0);
            b = new Bitmap(ptb.Width, ptb.Height);
            raizX = ptb.Width / 2;
            raizY = 20;
        }



        public void inserta_nodo(AxArbol A, AxArbol padre, string valor, int rama)
        {
            ptb.Image = (Image)b;
            g = Graphics.FromImage(b);
            contador = 0;
            if (A == null)
            {
                A = new AxArbol();
                A.dato = valor;
                A.izq = null;
                A.der = null;

                if (raiz == null)
                {
                    raiz = A;

                    A.posx = raizX;
                    A.posy = raizY;

                    g.DrawString(A.dato.ToString(), new Font("Cambria", 10, FontStyle.Regular), Brushes.Black, A.posx, A.posy);

                    g.DrawEllipse(borde, raizX, raizY - 15, 50, 50);
                  
                }
                else
                {
                    if (rama == 1)
                    {
                        //Aca pocisiona el nodo en un lugar terminado

                        A.posy = padre.posy + despY;

                        //Asigna un posiccion a un variable
                        padre.izq = A;

                        //Verifica el nivel del arbol
                        recorrer(Raiz, null, valor);

                        //Nivel del arbol
                        contador++;
                       
                        //Coloca la linea segun sea su nivel
                        if (contador == 2)
                        {
                            A.nivel = contador;
                            A.posx = padre.posx - 180;
                            g.DrawLine(borde, padre.posx + 2, padre.posy, A.posx + 30, A.posy + 30);


                        }
                        else if (contador == 3)
                        {
                          
                            A.posx = padre.posx - 80;
                            g.DrawLine(borde, padre.posx + 5, padre.posy + 50, A.posx + 30, A.posy + 30);
                        }
                        else if (contador == 4)
                        {
                         
                            A.posx = padre.posx - 50;
                            g.DrawLine(borde, padre.posx + 5, padre.posy + 50, A.posx + 30, A.posy + 30);
                        }
                        else if (contador > 4)
                        {
                         
                            A.posx = padre.posx - 40;
                            g.DrawLine(borde, padre.posx + 5, padre.posy + 50, A.posx + 30, A.posy + 30);
                        }
                        //Aca dibuja los nodos del arbol
                        g.DrawString(A.dato.ToString(), new Font("Cambria", 10, FontStyle.Regular), Brushes.Black, A.posx + 5, A.posy + 45);
                        g.DrawEllipse(borde, A.posx + 5, A.posy + 30, 50, 50);


                    }
                    //Aca insertar el nodo en la rama derecha
                    else if (rama == 2)
                    {

                        //Asigna un posiccion a un variable
                        padre.der = A;

                        //Verifica el nivel del arbol
                        recorrer(Raiz, null, valor);

                        //Nivel del arbol
                        contador++;


                        //Aca pocisiona el nodo en un lugar terminado

                        A.posy = padre.posy + despY;

                        //Coloca la linea segun sea su nivel
                        if (contador == 2)
                        {
                            A.posx = padre.posx + 180;
                            g.DrawLine(borde, padre.posx + 45, padre.posy - 2, A.posx + 30, A.posy + 30);
                            //  g.DrawLine(borde, 535, 18, 670, 90);

                        }
                        else if (contador == 3)
                        {
                            A.posx = padre.posx + 80;
                            g.DrawLine(borde, padre.posx + 55, padre.posy + 50, A.posx + 30, A.posy + 30);
                        }
                        else if (contador == 4)
                        {
                            A.posx = padre.posx + 50;
                            g.DrawLine(borde, padre.posx + 55, padre.posy + 50, A.posx + 30, A.posy + 30);
                        }
                        else if (contador > 4)
                        {
                            A.posx = padre.posx + 40;
                            g.DrawLine(borde, padre.posx + 55, padre.posy + 50, A.posx + 30, A.posy + 30);
                        }

                        //Aca dibuja los nodos del arbol
                        g.DrawString(A.dato.ToString(), new Font("Cambria", 10, FontStyle.Regular), Brushes.Black, A.posx + 5, A.posy + 45);
                        g.DrawEllipse(borde, A.posx + 5, A.posy + 30, 50, 50);

                    }
                }
            }
            else
            {
                if (valor.CompareTo(A.dato) == -1)
                {
                    inserta_nodo(A.izq, A, valor, 1);
                }
                else if (valor.CompareTo(A.dato) == 1)
                {

                    inserta_nodo(A.der, A, valor, 2);
                }
                else
                {
                    MessageBox.Show("Dato duplicado ");
                }
            }
        }


        public void recorrer(AxArbol A, AxArbol padre, string valor)
        {

            if (valor.CompareTo(A.dato) == -1)
            {
                contador = contador + 1;
                recorrer(A.izq, A, valor);
            }
            else if (valor.CompareTo(A.dato) == 1)
            {
                contador = contador + 1;
                recorrer(A.der, A, valor);
            }

        }
    }
    //CLASE DE UN ARBOL SEGUNDARIO
    public class AxArbol
    {
        public string dato;
        public AxArbol izq;
        public AxArbol der;
        public int posx;
        public int posy;
        public int nivel;
        //public int nivelArbol;
    }
}

