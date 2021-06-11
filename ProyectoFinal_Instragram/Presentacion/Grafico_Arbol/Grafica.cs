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
using System.IO;
using ProyectoFinal_Instragram.Presentacion.Login;

namespace ProyectoFinal_Instragram.Presentacion.Grafico_Arbol
{
    public partial class Grafica : Form
    {
        AuxDibujar dibujaArbol = new AuxDibujar();
        ArbolAvl miArbol = Program.objArbolAvl;

        int nivelArbol = 0;
        int contadorGenerico = 0;
        public Grafica()
        {
            InitializeComponent();
        }
        private void Grafica_Load(object sender, EventArgs e)
        {
            cargarGrafica();
            vitacoras();
            comboBox1.SelectedIndex = 0;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }
        public void vitacoras()
        {
            string dato;
            TextReader leer = new StreamReader("Vitacora.txt");
            while ((dato = leer.ReadLine()) != null)
            {
                listBox3.Items.Add(dato);
            }
        }
        public void cargarGrafica()
        {
            dibujaArbol = new AuxDibujar(picGrafica);

            string nuevo = ArbolAvl.rcPreorden(miArbol.raizArbol());

            string[] palabras = nuevo.Split(',', ';');

            foreach (string palabra in palabras)
            {
                contadorGenerico++;
                if (palabra != "" && contadorGenerico % 2 == 0)
                {
                    dibujaArbol.inserta_nodo(dibujaArbol.Raiz, null, palabra, 0);
                    nivelArbolGrafica();
                }

            }

            listBox2.Items.Add(nivelArbolGrafica());
        }
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Inicio Formulario = new Login_Inicio();
            Formulario.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    
                    recorridoPreorden(0,0);
                    break;

                case 1:
                    recorridoInorden(0,0);
                    break;

                case 2:
                    recorridoPostorden(0,0);
                    break;

                default:
                    MessageBox.Show("Elija una opcion");
                    break;
            }
        }
        public void recorridoPreorden(int cont, int auxCont)
        {
            listRecorrido.Items.Clear();
            string nuevo = ArbolAvl.rcPreorden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',', ';');

            foreach (string palabra in palabras)
            {
                auxCont++;

                if (palabra != "" && auxCont % 2 == 0)
                {
                    cont++;
                    listRecorrido.Items.Add("Usuarios registrados" + " --->  " + palabra);
                }
            }
            listBox1.Items.Add(cont);
        }

        public void recorridoInorden(int cont, int auxCont)
        {
            listRecorrido.Items.Clear();
            string nuevo = ArbolAvl.rcInorden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',', ';');

            foreach (string palabra in palabras)
            {
                auxCont++;

                if (palabra != "" && auxCont % 2 == 0)
                {
                    cont++;
                    listRecorrido.Items.Add("Usuarios registrados" + " --->  " + palabra);
                }
            }
            listBox1.Items.Add(cont);
        }

        public void recorridoPostorden(int cont, int auxCont)
        {
            listRecorrido.Items.Clear();
            string nuevo = ArbolAvl.rcpostOrden(miArbol.raizArbol());
            string[] palabras = nuevo.Split(',', ';');


            foreach (string palabra in palabras)
            {
                auxCont++;

                if (palabra != "" && auxCont % 2 == 0)
                {
                    cont++;
                    listRecorrido.Items.Add("Usuarios registrados" + " --->  " + palabra);
                }
            }
            listBox1.Items.Add(cont);
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
