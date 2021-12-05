using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        int numForm;
        Socket server;
        public Form2(int numForm, Socket server)
        {
            InitializeComponent();
            this.numForm = numForm;
            this.server = server;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Longitud.Checked)
                {
                    // Quiere saber la longitud
                    string mensaje = "1/" +this.numForm+"/"+ nombre.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }
                else if (Altura.Checked)
                {
                    //Quiere saber si es alto o no
                    string mensaje = "3/" + this.numForm + "/" + nombre.Text + "/" + alturaBox.Text;
                    //Enviamos al servidor el nombre de la persona y su altura
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }
                else if (Palindromo.Checked)
                {
                    //Quiere saber si el nombre es palindromo
                    string mensaje = "4/" + this.numForm.ToString() + "/" + nombre.Text;
                    //Enviamos al servidor el nombre de la persona y su altura
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }
                else if (Mayusculas.Checked)
                {
                    //Quieren obtener su nombre en mayusculas
                    string mensaje = "5/" + this.numForm.ToString() + "/" + nombre.Text;
                    //Enviamos al servidor el nombre de la persona y su altura
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }
                else
                {
                    // Quiere saber si el nombre es bonito
                    string mensaje = "2/" + this.numForm.ToString() + "/" + nombre.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }

            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("Se ha producido un error");
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            numFormLBL.Text = "Formulario: "+this.numForm.ToString();
        }

        public void TomaRespuesta1(string mensaje)
        {
            MessageBox.Show("Longitud = " + mensaje);
        }
        public void TomaRespuesta2(string mensaje)
        {
            if (mensaje == "SI")
                MessageBox.Show("Tu nombre es bonito");
            else
                MessageBox.Show("tu nombre no es bonito, lo siento");
        }
        public void TomaRespuesta3(string mensaje)
        {
            if (mensaje == "SI")
                MessageBox.Show("Eres alto");
            else
                MessageBox.Show("No eres alto");
        }
        public void TomaRespuesta4(string mensaje)
        {
            if (mensaje == "SI")
                MessageBox.Show("Tu nombre es palindromo");
            else
                MessageBox.Show("Tu nombre no es palindromo");
        }
        public void TomaRespuesta5(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
