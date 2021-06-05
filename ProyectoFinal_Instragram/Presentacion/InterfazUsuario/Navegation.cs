using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_Instragram.Presentacion.Login;
using ProyectoFinal_Instragram.Presentacion.Grafico_Arbol;
using System.Xml;
using ProyectoFinal_Instragram.Estructura_de_datos.XML;
using ProyectoFinal_Instragram.Estructura_de_datos.ArbolAVL;
using ProyectoFinal_Instragram.Estructura_de_datos.Usuario;

namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    public partial class Navegation : Form
    {
        AuxXml miXmlTemp;
        AuxXml miXml;
        ArbolAvl miArbol = Program.objArbolAvl;
        public Navegation()
        {
            InitializeComponent();
            panel8.Visible = false;
        }

        private void PerfilUsuario_Load(object sender, EventArgs e)
        {
            miXml = new AuxXml();
            miXmlTemp = new AuxXml();
            PanelOpciones.Visible = false;
            //miXmlTemp.leerXml("UsuarioTemp");
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
                                //  lbDescripcion.Text = reader.ReadString();
                                break;
                            case "Correo":
                                break;
                            case "Img":
                                ProfileUser.WaitOnLoad = false;
                                ProfileUser.LoadAsync(@"" + reader.ReadString());
                                break;
                            case "Publicaciones":
                                break;
                        }
                    }
                }
            }

            
            //string phrase = ArbolAvl.rcInorden(Program.objArbolAvl.raizArbol());
            //string[] arrayUsuarios = phrase.Split(';');

            string[] arrayUsuarios = ArbolAvl.rcInorden(Program.objArbolAvl.raizArbol()).Split(';');

            Random r = new Random();
            int cont = 1;
            for (int i = 0; i < 4; i++)
            {
                //Genera un numero entre 10 y 100 (101 no se incluye)
                Console.WriteLine(r.Next(0, 3));
                if (cont == 1)
                {
                    string[] arrUsuario = arrayUsuarios[r.Next(0, 3)].Split(',');
                    pictureBox4.WaitOnLoad = false;
                    pictureBox4.LoadAsync(@"" + arrUsuario[0]);
                    label2.Text = arrUsuario[1];

                    //ClaseUsuario objUsuario = new ClaseUsuario(lbUsuario.Text);
                    //ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();
                    //MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());

                    //miXml.eliminarXml("UsuarioAmigo");
                    //miXml.crearXml("UsuarioAmigo");
                    //miXml.añadirUsuario(encontradoUsuario.usuario, encontradoUsuario.nombre, "", encontradoUsuario.correo,
                    //    encontradoUsuario.contraseña, encontradoUsuario.imagenProfile, "UsuarioAmigo");

                    cont++;
                }
                if (cont == 2)
                {
                    string[] arrUsuario = arrayUsuarios[r.Next(0, 3)].Split(',');
                    pictureBox5.WaitOnLoad = false;
                    pictureBox5.LoadAsync(@"" + arrUsuario[0]);
                    label3.Text = arrUsuario[1];
                    cont++;
                }
                if (cont == 3)
                {
                    string[] arrUsuario = arrayUsuarios[r.Next(0, 3)].Split(',');
                    pictureBox6.WaitOnLoad = false;
                    pictureBox6.LoadAsync(@"" + arrUsuario[0]);
                    label4.Text = arrUsuario[1];
                    cont++;
                }
                if (cont == 4)
                {
                    string[] arrUsuario = arrayUsuarios[r.Next(0, 3)].Split(',');
                    pictureBox7.WaitOnLoad = false;
                    pictureBox7.LoadAsync(@"" + arrUsuario[0]);
                    label5.Text = arrUsuario[1];
                    cont++;
                }
            }

        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
      
        }

        private void ProfileUser_Click(object sender, EventArgs e)
        {
            // verifica que el panel este visible
            if (PanelOpciones.Visible == false)
            {
                PanelOpciones.Visible=true;
            }

            //  De lo contrario volvera a esconder
            else
            {
                PanelOpciones.Visible = false;
            }
        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario Formulario = new PerfilUsuario();
            Formulario.Show();
            this.Hide();

        }

        private void lblConfiguracion_Click(object sender, EventArgs e)
        {
            EditarPerfil Formulario = new EditarPerfil();
            Formulario.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            miXmlTemp.eliminarXml("UsuarioTemp");

            Login_Inicio Formulario = new Login_Inicio();
            Formulario.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void lblGuardado_Click(object sender, EventArgs e)
        {
            Grafica Formulario = new Grafica();
            Formulario.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ClaseUsuario objUsuario = new ClaseUsuario(label2.Text);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();
            MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());
            Program.usuario = encontradoUsuario.usuario;
            Program.contraseña = encontradoUsuario.contraseña;

            FriendProfile Formulario = new FriendProfile();
            Formulario.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ClaseUsuario objUsuario = new ClaseUsuario(label3.Text);
            ClaseUsuario encontradoUsuario = (ClaseUsuario)Program.objArbolAvl.buscarUsuario(objUsuario).valorNodo();
            MessageBox.Show("Dato encontrado   " + encontradoUsuario.busquedaInfo());
            Program.usuario = encontradoUsuario.usuario;
            Program.contraseña = encontradoUsuario.contraseña;

            FriendProfile Formulario = new FriendProfile();
            Formulario.Show();
            this.Hide();
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarUsuario.Text == " " || txtBuscarUsuario.Text == "")
            {
                panel8.Visible = false;
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
            }
            else
            {
                panel8.Visible = true;
                int contador = 0;
                int aux=0;
                
                string nuevo = ArbolAvl.rcPreorden(miArbol.raizArbol());
                string[] palabras = nuevo.Split(',', ';');

                foreach (string palabra in palabras)
                {
                    contador++;
                    if (palabra != "" && contador % 2 == 0)
                    {
                        if (palabra.StartsWith(txtBuscarUsuario.Text))
                        {
                            aux++;
                            if (aux ==1) { label6.Text = palabra; panel8.Visible = true; }
                            else if (aux == 2) { label7.Text = palabra; }
                            else if (aux == 3) { label8.Text = palabra; }

                        }
                    }
                }
            }
        }
    }
}
