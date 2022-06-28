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

        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt;
        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Conectados");
            ListaConectados.DataSource = dt;
           
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
                    case 1:       //repuesta al log in

                        if (mensaje == "SI")
                            MessageBox.Show("Bienvenido");
                        else if (mensaje == "NO")
                            MessageBox.Show("No estas registrado. Para registrarte rellena los campos y presiona registrar");
                        break;

                    case 2:     //respuesta a consulta 1

                        if (mensaje == "NO")
                            MessageBox.Show("No hay partidas en esa fecha");
                        else
                            MessageBox.Show("Los jugadores que jugaron ese día son:" + mensaje);
                        break;

                    case 3:     //respuesta a consulta 2

                        if (mensaje == "NO")
                            MessageBox.Show("No hay partidas de ese jugador");
                        else
                            MessageBox.Show("La duración total de partidas ganadas es: " + mensaje);
                        break;

                    case 4:     //lista conectados
                        int x = 2;
                        Invoke(new Action(() =>
                        {
                            dt.Rows.Clear();
                            int num = Convert.ToInt32(trozos[1]);
                            for (int i = 0; i < num; i++)
                            {
                                dt.Rows.Add(trozos[x]);
                                x++;
                            }
                            //MIRAR LO DE DT Y DATA GRID VIEW
                            ListaConectados.ClearSelection();

                        }));
                        break;

                    case 6:     //recibo notificacion
                        
                        this.Invoke(new Action(()=>
                        {
                        contLbl.Text = mensaje;
                         }));
                        
                        break;

                    case 7: //registrarse
                        //Falta solucionar problema id
                        break;
                }
            }

        }
        


        private void ConectarButton_Click(object sender, EventArgs e)// boton conectar
        {

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");


                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }



            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }




        }


        private void LogInButton_Click(object sender, EventArgs e)//botón entrar
        {
           
            string mensaje = "1/" + nickname.Text + "/" + password.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }




        private void button2_Click(object sender, EventArgs e) // boton enviar
        {
            
       

                if (DimeJugadores.Checked)
                {
                    // Quiere saber si el nombre es bonito
                    string mensaje = "2/" + Consulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);                           

                }


                if (SumaDuracion.Checked)
                {
                    // Quiere saber si el nombre es bonito
                    string mensaje = "3/" + Consulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
           


            }
        



        private void Desconectar_Click(object sender, EventArgs e)//boton desconectar
        {
            //Mensaje de desconexion
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


     
            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void contLbl_Click(object sender, EventArgs e)
        {

        }

        private void contLbl_Click_1(object sender, EventArgs e)
        {

        }

        

/*
        private void RegistrarButton_Click_1(object sender, EventArgs e)
        {
                           private void RegistrarButton_Click(object sender, EventArgs e)
               {
                   if ((password.Text.Length > 3) && (nickname.Text.Length > 3))
                   {
                       if (password.Text == password_conf.Text)
                       {
                           // Guarda los datos en un string con el codigo
                           string mensaje = "2/" + nickname.Text + "/" + password.Text;
                           // Enviamos al servidor el nombre tecleado
                           byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                           server.Send(msg);

                           //Recibimos la respuesta del servidor                    
                           byte[] msg2 = new byte[80];
                           server.Receive(msg2);
                           mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                           if (mensaje == "Si")
                               MessageBox.Show("Registrado con exito");
                           else
                               MessageBox.Show("El nombre que intentas utilizar ya existe");
                       }
                       else
                           MessageBox.Show("La contraseña mal escrita");
                   }
                   else
                       MessageBox.Show("El nombre y contraseña deben tener más de 3 caracteres");
        }
 */

       
      


     
     
    }
}
