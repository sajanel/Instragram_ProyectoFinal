using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Presentacion.InterfazUsuario;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;

namespace ProyectoFinal_Instragram.Presentacion.Grafico_Arbol
{
    public partial class Grafica : Form
    {
        AuxDibujar dibujaArbol = new AuxDibujar();
        ArbolAvl miArbol = new ArbolAvl();
        ClaseUsuario miUsuario;

        int nivelArbol = 0;
        public Grafica()
        {
            InitializeComponent();
        }

        private void Grafica_Load(object sender, EventArgs e)
        {
           

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //miUsuario = new ClaseUsuario(textBox1.Text);
            miUsuario = new ClaseUsuario("sergio");
            ClaseUsuario miUsuario1 = new ClaseUsuario("sergio1");
            ClaseUsuario miUsuario2 = new ClaseUsuario("sergio2");
            ClaseUsuario miUsuario3 = new ClaseUsuario("sergio3");
            ClaseUsuario miUsuario4 = new ClaseUsuario("sergio4");
            ClaseUsuario miUsuario5 = new ClaseUsuario("sergio5");
            ClaseUsuario miUsuario6 = new ClaseUsuario("sergio6");
            ClaseUsuario miUsuario7 = new ClaseUsuario("sergio7");
            ClaseUsuario miUsuario8 = new ClaseUsuario("sergio8");
            ClaseUsuario miUsuario9 = new ClaseUsuario("sergio9");
       
            miArbol.insertar(miUsuario);
            miArbol.insertar(miUsuario1);
            miArbol.insertar(miUsuario2);
            miArbol.insertar(miUsuario3);
            miArbol.insertar(miUsuario4);
            miArbol.insertar(miUsuario5);
            miArbol.insertar(miUsuario6);
            miArbol.insertar(miUsuario7);
            miArbol.insertar(miUsuario8);
            miArbol.insertar(miUsuario9);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dibujaArbol = new AuxDibujar(picGrafica);
            string nuevo = ArbolAvl.rcPreorden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',');

            foreach (string palabra in palabras)
            {
                if (palabra != "")
                {
                    dibujaArbol.inserta_nodo(dibujaArbol.Raiz, null, palabra, 0);
                    nivelArbolGrafica();
                }
            }

            listBox2.Items.Add(nivelArbolGrafica());
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    recorridoPreorden(0);
                    break;

                case 1:
                    recorridoInorden(0);
                    break;

                case 2:
                    recorridoPostorden(0);
                    break;

                default:
                    MessageBox.Show("Elija una opcion");
                    break;
            }
        }

        public void recorridoPreorden(int cont)
        {
            listRecorrido.Items.Clear();
            string nuevo = ArbolAvl.rcPreorden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',');

            foreach (string palabra in palabras)
            {
                if (palabra != "")
                {
                    cont++;
                    listRecorrido.Items.Add("Usuarios registrados" + " --->  " + palabra);
                    listBox1.Items.Add("* " + cont);
                }
                
            }
        }

        public void recorridoInorden(int cont)
        {
            listRecorrido.Items.Clear();
            string nuevo = ArbolAvl.rcInorden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',');

            foreach (string palabra in palabras)
            {
                if (palabra != "")
                {
                    cont++;
                    listRecorrido.Items.Add("Usuarios registrados" + " --->  " + palabra);
                    listBox1.Items.Add("* " + cont);
                }
          
            }
        }

        public void recorridoPostorden(int cont)
        {
            listRecorrido.Items.Clear();
            string nuevo = ArbolAvl.rcpostOrden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',');

            foreach (string palabra in palabras)
            {
                if (palabra != "")
                {
                    cont++;
                    listRecorrido.Items.Add("Usuarios registrados" + " --->  " + palabra);
                    listBox1.Items.Add("* " + cont);
                }
            }
            
        }

        public int nivelArbolGrafica() 
        {
            if (nivelArbol < dibujaArbol.contador)
            {
                nivelArbol = dibujaArbol.contador;
            }
            return nivelArbol;
        }



    }
}
