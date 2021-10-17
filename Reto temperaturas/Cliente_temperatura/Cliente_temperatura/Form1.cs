using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Cliente_temperatura
{
    public partial class Form1 : Form
    {
        Socket server;

        public Form1()
        {
            InitializeComponent();
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress iPAddress = IPAddress.Parse("192.168.56.102");
            IPAddress direc = iPAddress;
            IPEndPoint ipep = new IPEndPoint(direc, 9060);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                
                //Construimos la peticion
                if (CaF.Checked)
                {
                    string mensaje = "1/" + Convert.ToString(Convert.ToDouble(TemperaturaBox.Text));

                    //Enviamos el mensaje
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    //Procesamos la respuesta
                    Resultado.Text = mensaje + " ºF";
                    TemperaturaBox.Text = "";
                }
                else
                {
                    string mensaje = "2/" + Convert.ToString(Convert.ToDouble(TemperaturaBox.Text));

                    //Enviamos el mensaje
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    //Procesamos la respuesta
                    Resultado.Text = mensaje + " ºC";
                    TemperaturaBox.Text = "";
                }
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduzca un valor de temperatura correcto.");
            }
            
        }
    }
}
