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
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;

        delegate void DelegadoParaEscribir(string mensaje);

        List<Form2> formularios = new List<Form2>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public void PonContador (string contador)
        {
            numServicios.Text = contador;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);

                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    case 1: //respuesta a longitud
                        int numForm = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios[numForm].TomaRespuesta1(mensaje);
                        //Enviar mensaje al formulario numForm

                        break;

                    case 2: //respuesta a si mi nombre es bonito
                        numForm = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios[numForm].TomaRespuesta2(mensaje);
                        //Enviar mensaje al formulario numForm

                        break;

                    case 3: //respuesta a si soy alto
                        numForm = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios[numForm].TomaRespuesta3(mensaje);
                        //Enviar mensaje al formulario numForm

                        break;

                    case 4: //respuesta a si mi nombre es palindromo
                        numForm = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios[numForm].TomaRespuesta4(mensaje);
                        //Enviar mensaje al formulario numForm

                        break;

                    case 5: //recepcion del nombre en mayusculas
                        numForm = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios[numForm].TomaRespuesta5(mensaje);
                        //Enviar mensaje al formulario numForm

                        break;

                    case 6: //notificacion de numero de servicios
                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonContador);
                        numServicios.Invoke(delegado, new object[] {mensaje});
                        break;

                }
                        
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Longitud.Checked)
        //        {
        //            // Quiere saber la longitud
        //            string mensaje = "1/" + nombre.Text;
        //            // Enviamos al servidor el nombre tecleado
        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
        //            server.Send(msg);

        //        }
        //        else if (Altura.Checked)
        //        {
        //            //Quiere saber si es alto o no
        //            string mensaje = "3/" + nombre.Text + "/" + alturaBox.Text;
        //            //Enviamos al servidor el nombre de la persona y su altura
        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
        //            server.Send(msg);

        //        }
        //        else if (Palindromo.Checked)
        //        {
        //            //Quiere saber si el nombre es palindromo
        //            string mensaje = "4/" + nombre.Text;
        //            //Enviamos al servidor el nombre de la persona y su altura
        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
        //            server.Send(msg);

        //        }
        //        else if (Mayusculas.Checked)
        //        {
        //            //Quieren obtener su nombre en mayusculas
        //            string mensaje = "5/" + nombre.Text;
        //            //Enviamos al servidor el nombre de la persona y su altura
        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
        //            server.Send(msg);

        //        }
        //        else
        //        {
        //            // Quiere saber si el nombre es bonito
        //            string mensaje = "2/" + nombre.Text;
        //            // Enviamos al servidor el nombre tecleado
        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
        //            server.Send(msg);

        //        }

        //    }
        //    catch (SocketException)
        //    {
        //        //Si hay excepcion imprimimos error y salimos del programa con return 
        //        MessageBox.Show("Se ha producido un error");
        //        return;
        //    }


        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress iPAddress = IPAddress.Parse("192.168.56.102");
            IPAddress direc = iPAddress;
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            //Ponemos en marcha el thread que atenderá los mensajes de los clientes
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexion
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort(); //Detenemos el thread
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            MessageBox.Show("Desconectado");
        }
        private void PonerEnMarchaFormulario()
        {
            int cont = formularios.Count;
            Form2 f = new Form2(cont, server);
            formularios.Add(f);
            f.ShowDialog();
            
        }

        private void crearFormularioBtn_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario(); };
            Thread T = new Thread(ts);
            T.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mensaje de desconexion
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort(); //Detenemos el thread
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
