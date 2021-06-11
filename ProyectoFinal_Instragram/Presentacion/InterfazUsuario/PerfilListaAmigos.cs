using ProyectoFinal_Instragram.Estructura_de_datos.TablaHash;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class PerfilListaAmigos : Form
    {
        public PerfilListaAmigos()
        {
            InitializeComponent();
        }
        private int y = 400;
        private int y2 = 425;
        private int conteo = 0;

        private void PerfilListaAmigos_Load(object sender, EventArgs e)
        {
            
            // aux.leerXml("UsuarioTemp");
            using (XmlReader reader = XmlReader.Create(@"UsuarioTemp.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "Nombre":
                                lbNombre.Text = reader.ReadString();
                                break;
                            case "Usuario":
                                lbUsuario.Text = reader.ReadString();
                                break;
                            case "Biografia":
                                lbDescripcion.Text = reader.ReadString();
                                break;
                            case "Correo":
                                break;
                            case "Img":
                                pictureBox2.WaitOnLoad = false;
                                pictureBox2.LoadAsync(@"" + reader.ReadString());
                                break;
                        }
                    }
                }
            }

            
            ClaseUsuario objUsuario = new ClaseUsuario(Program.miUsuario);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();

            //Aca leer la cantidad de seguidores y seguidos 
            lbSeguidos.Text = encontradoUsuario.tablaHashSeguidos.cont.ToString();
            lbSeguidores.Text = encontradoUsuario.tablaHashSeguidores.cont.ToString();
            lbPosts.Text = encontradoUsuario.miLista.cont.ToString();


            if (Program.tipo == "Seguidores")
            {
                TablaDispercionColision.miCola.Clear();
                Eliminar();
                encontradoUsuario.tablaHashSeguidores.Mostar();

                foreach (var item in TablaDispercionColision.miCola)
                {//direccion,usarios
                    Pintar(item.ToString());
                }
            }
            else if (Program.tipo == "Seguidos")
            {
                TablaDispercionColision.miCola.Clear();
                Eliminar();
                encontradoUsuario.tablaHashSeguidos.Mostar();

                foreach (var item in TablaDispercionColision.miCola)
                {
                    Pintar(item.ToString());
                    obtener();
                }
            }           
        }

        int conta = 0;
        

        public void obtener()
        {
            
            PictureBox pic = this.Controls.OfType<PictureBox>().First(x => x.Name == "picturebox" + conta.ToString());

            Program.pictureBoxes[conta] = pic;
            
            conta++;
        }
        public void Eliminar()
        {
            for (int i = 0; i < Program.pictureBoxes.Length; i++)
            {
                if (Program.pictureBoxes[i]!= null )
                {
                    
                    this.Controls.Remove(Program.pictureBoxes[i]);
                    Program.pictureBoxes[i].Dispose();
                    Program.pictureBoxes[i].Image = null;
                }

            }
        }
        public void Pintar(string texto)
        {
            PictureBox temp = new PictureBox();
            Label temp2 = new Label();

            string nuevo = texto;
            string[] palabras = nuevo.Split(',');

            
            temp.Height = 100;
            temp.Width = 100;
            temp.Location = new Point(500, y);
            y += 100;
            temp.Name = "picturebox" + conteo.ToString();

            temp.ImageLocation = @"" + palabras[0];
            temp.SizeMode = PictureBoxSizeMode.Zoom;
            //conteo++;


            temp2.Height = 20;
            temp2.Width = 150;
            temp2.Location = new Point(620, y2);
            y2 += 100;
            temp2.Name = "label" + conteo.ToString();

            temp2.Text = palabras[1];
            conteo++;
            Program.cont++;
            Controls.Add(temp);
            Controls.Add(temp2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Navegation Formulario = new Navegation();
            Formulario.Show();
            this.Hide();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            EditarPerfil Formulario = new EditarPerfil();
            Formulario.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Program.tipo = "";
            Program.tipo = "Seguidores";
            PerfilListaAmigos Formulario = new PerfilListaAmigos();
            Formulario.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Program.tipo = "";
            Program.tipo = "Seguidos";
            PerfilListaAmigos Formulario = new PerfilListaAmigos();
            Formulario.Show();
            this.Hide();
        }
    }
}
