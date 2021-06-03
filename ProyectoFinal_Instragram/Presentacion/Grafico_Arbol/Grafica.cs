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
        //AuxDibujar dibujaArbol = new AuxDibujar();
        //ArbolAvl miArbol = new ArbolAvl();
        //ClaseUsuario miUsuario;
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
            //miArbol.insertar(miUsuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dibujaArbol = new AuxDibujar(picGrafica);

            //string nuevo = ArbolAvl.rcPreorden(miArbol.raizArbol());
            //string[] palabras = nuevo.Split(',');

            //foreach (string palabra in palabras)
            //{
            //    if (palabra != "")
            //    {
            //        dibujaArbol.inserta_nodo(dibujaArbol.Raiz, null, palabra, 0);
            //    }
            //}
        }
    }
}
