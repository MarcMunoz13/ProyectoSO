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

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos la respuesta del servidor                    
                byte[] msg2 = new byte[200];
                server.Receive(msg2);
                string a = Encoding.ASCII.GetString(msg2);

                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                

                switch (codigo)
                {
                    case 1://repuesta al log in

                        if (trozos[1] == "SI") //Si se conecta correctamente hace visible el menu
                        {
                        Invoke(new Action(() =>
                        {
                            Consultar.Visible = true;
                            DimeJugadores.Visible = true;
                            SumaDuracion.Visible = true;
                            ListaConectados.Visible = true;
                            Consulta.Visible = true;
                            label2.Visible = true;
                            RegistrarButton.Visible = false;
                            password_conf.Visible = false;
                            label1.Visible = false;
                            label4.Visible = false;
                            LogInButton.Visible = false;
                            nickname.ReadOnly = true;
                            password.ReadOnly = true;
                            Bienvenido.Visible = true;
                            Bienvenido.Text = "Bienvenido " + nickname.Text;
                            nickname.Visible = false;
                            password.Visible = false;
                            Nick.Visible = false;
                            label3.Visible = false;
                            EnablePassword.Visible = false;
                            ListaConectados.Rows[0].Cells[0].Selected = false;
                        }));
                        }
                        else if (trozos[1] == "NO") //No existe tu nombre en la BD
                        {
                            MessageBox.Show("No estas registrado o contraseña/nombre incorrectos. Para registrarte rellena los campos y presiona registrar");
                            Invoke(new Action(() =>
                            {
                                RegistrarButton.Visible = true;
                                password_conf.Visible = true;
                                label1.Visible = true;
                                label4.Visible = true;
                            }));
                        }
                        break;


                    case 2:     //respuesta a consulta 1

                        if (trozos[1] == "NO")
                        {
                            MessageBox.Show("No hay partidas en esa fecha");
                        }
                        else
                        {
                            MessageBox.Show("Los jugadores que jugaron ese día son:" + mensaje);
                        }
                        break;

                    case 3:     //respuesta a consulta 2

                        if (trozos[1] == "NO")
                        {
                            MessageBox.Show("No hay partidas de ese jugador");
                        }
                        else
                        {
                            MessageBox.Show("La duración total de partidas ganadas es: " + mensaje);
                        }
                        break;

                    case 4:     //lista conectados
                        int x = 2;
                        Invoke(new Action(() =>
                        {
                            ListaConectados.Rows.Clear();
                            int num = Convert.ToInt32(trozos[1]);
                            for (int i = 0; i < num; i++)
                            {
                                ListaConectados.Rows.Add(trozos[x]);
                                x++;
                            }
                         }));
                        break;

                    case 5: //registrarse
                        if (trozos [1] == "0")
                        {
                            MessageBox.Show("Registrado con exito");
                            Invoke(new Action(() =>
                            {
                                RegistrarButton.Visible = false;
                                password_conf.Visible = false;
                                label1.Visible = false;
                                label4.Visible = false;
                                LogInButton.Visible = false;
                                nickname.Visible = false;
                                password.Visible = false;
                                Nick.Visible = false;
                                label3.Visible = false;
                                EnablePassword.Visible = false;
                            }));
                        }
                        else
                        {
                            MessageBox.Show("El nombre que intentas utilizar ya existe");
                        }
                        break;

                    case 6:  //eliminar usuario de BD
                        MessageBox.Show("Has eliminado al usuario"+ UsuarioEliminado.Text);
                        break;

                    case 7: //Invitacion
                        if (trozos[1] == nickname.Text) //No te invites a ti mismo
                        {
                            MessageBox.Show("No te puedes invitar a ti mismo");
                        }
                        else
                        {
                            if (trozos[1] == "-1") //Error invitar
                            {
                                MessageBox.Show("Error al invitar al jugador");
                            }
                            else   //Invitado exitosamente
                            {
                                MessageBox.Show("La invitación ha sido enviada con exito");
                            }
                        }
                        break;
                    case 8:    //Respuesta que abre el menu de invitacion a las personas indicadas
                        string host = trozos[1].Split('\0')[0];
                        Invoke(new Action(() =>
                            {
                                Host.Text = trozos[1];
                                Invitado.Text = trozos[2];
                                Invitacion.Visible = true;
                                groupBox1.Visible = false;
                                Label_Invitacion.Text = host;
                            }));
                        break;

                    case 9:  //Aceptar/Rechazar Invitacion
                        if (trozos[1] == "-1")
                        {
                            Invoke(new Action(() =>
                            {
                            Desconectar.Visible = true;
                            }));
                            MessageBox.Show("El jugador no ha aceptado la invitacion :(");
                        }
                        else 
                        {
                            Invoke(new Action(() =>
                            {
                                groupBox1.Visible = false;
                                Chat.Visible = true;
                                Recibidos.Rows.Clear();
                                Enviados.Rows.Clear();
                                Desconectar.Visible = false;
                            }));
                            MessageBox.Show("El jugador ha aceptado la invitacion A CHATEAR :D");
                        }
                        break;
                    case 10:   //Texto recibido chat
                        Invoke(new Action(() =>
                        {
                            Recibidos.Rows.Add(trozos[1]);
                            Enviados.Rows.Add("");
                        }));
                        break;
                    case 11:   //El compañero ha abandonado el chat (se cierra tu chat)
                        Invoke(new Action(() =>
                        {
                            Chat.Visible = false;
                            groupBox1.Visible = true;
                            Desconectar.Visible = true;
                        }));
                        MessageBox.Show("Se ha desconectado del chat");
                        break;
                }
            }
        }



        private void ConectarButton_Click(object sender, EventArgs e)  //boton conectar
        {
            groupBox1.Visible = true;
            ConectarButton.Visible = false;
            Desconectar.Visible = true;
            nickname.Clear();
            password.Clear();

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9087);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Aqua;
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
                ConectarButton.Visible = true;
                Desconectar.Visible = false;
                groupBox1.Visible = false;
                return;
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)  //botón entrar
        {
            if (String.IsNullOrWhiteSpace(nickname.Text) || (nickname.Text.Length < 1))
            {
                //si no has rellenado los parametros
                MessageBox.Show("Rellena los huecos");
            }
            else
            {
                RegistrarButton.Visible = false;
                password_conf.Visible = false;
                label1.Visible = false;
                label4.Visible = false;
                string mensaje = "1/" + nickname.Text + "/" + password.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            
        }

        private void Consultar_Click(object sender, EventArgs e) // boton consultas
        {
            //Si esta pulsada la consulta de Dime Jugadores Que Jugaron Ese Dia
            if (DimeJugadores.Checked)
            {
                //No has escrito en el TextBox
                if (String.IsNullOrWhiteSpace(Consulta.Text) || (Consulta.Text.Length < 1))
                {
                    MessageBox.Show("Rellena los huecos");
                }
                //Envia consulta al servidor
                else
                {
                    string mensaje = "2/" + Consulta.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            //Si esta pulsada la consulta de Duracion total
            if (SumaDuracion.Checked)
            {
                //No has escrito en el TextBox
                if (String.IsNullOrWhiteSpace(Consulta.Text) || (Consulta.Text.Length < 1))
                {
                    MessageBox.Show("Rellena los huecos");
                }
                //Envia consulta al servidor
                else
                {
                    string mensaje = "3/" + Consulta.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }

        private void Desconectar_Click(object sender, EventArgs e)//boton desconectar
        {
            //Vuelve a dejar el menu como al inicio
            ConectarButton.Visible = true;
            Desconectar.Visible = false;
            groupBox1.Visible = false;
            Consultar.Visible = false;
            DimeJugadores.Visible = false;
            SumaDuracion.Visible = false;
            ListaConectados.Visible = false;
            Consulta.Visible = false;
            label2.Visible = false;
            RegistrarButton.Visible = false;
            password_conf.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            LogInButton.Visible = true;
            Label_Invitacion.Visible = false;
            Chat.Visible = false;
            Invitacion.Visible = false;
            nickname.Visible = true;
            password.Visible = true;
            Nick.Visible = true;
            label3.Visible = true;
            EnablePassword.Visible = true;
            Bienvenido.Visible = false;
            nickname.ReadOnly = false;
            password.ReadOnly = false;
            MensajeChat.Clear();
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

        private void EliminarUsuario_Click(object sender, EventArgs e)  // Boton Eliminar usuario de la base de datos
        {
            string mensaje = "6/" + UsuarioEliminado.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }


        private void RegistrarButton_Click(object sender, EventArgs e)  // Boton Registrar usuario en la base de datos
        {
            //Comprueba que la contraseña sea mas larga de 3 caracteres
                   if ((password.Text.Length > 3) && (nickname.Text.Length > 3))
                   {
                       //Comprueba que la contraseña sea igual a la de confirmación
                       if (password.Text == password_conf.Text)
                       {
                           // Guarda los datos en un string con el codigo
                           string mensaje = "5/" + nickname.Text + "/" + password.Text;
                           // Enviamos al servidor el nombre tecleado
                           byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                           server.Send(msg);
                       }
                       else
                       {
                           MessageBox.Show("La contraseña de confirmacion esta mal escrita");
                       }
                   }
                   else
                   {
                       MessageBox.Show("El nombre y contraseña deben tener más de 3 caracteres");
                   }
        }

        private void InvitarButton_Click(object sender, EventArgs e)  // Boton Invitar personas de la lista conectados
        {
            string nombre = ListaConectados.CurrentCell.Value.ToString();
            //No permite invitarte a ti mismo
            if (nombre == nickname.Text)
            {
                MessageBox.Show("No te invites a ti mismo");
            }
                //Envia un mensaje al servidor con el nombre de las personas a la que quieres invitar
            else
            {
                string mensaje = "7/" + nombre + "/" + nickname.Text;
                Host.Text = nickname.Text;
                Invitado.Text = nombre;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void Aceptar_Click(object sender, EventArgs e) // Boton Aceptar Invitación
        {
            string mensaje = "8/SI/" + Label_Invitacion.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            Invitacion.Visible = false;
            Chat.Visible = true;
            Desconectar.Visible = false;
        }

        private void Rechazar_Click(object sender, EventArgs e)  // Boton Rechazar Invitación
        {
            string mensaje = "8/NO/" + Label_Invitacion.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            Invitacion.Visible = false;
            groupBox1.Visible = true;
            Desconectar.Visible = true;
        }

        int i = 0;
        private void EnablePassword_Click(object sender, EventArgs e)  //Boton cambiar contraseña de texto a '*'
        {
            if (i == 0)
            {
                password.PasswordChar = '\0';
                password_conf.PasswordChar = '\0';
                i = 1;
            }
            else if (i == 1)
            {
                password.PasswordChar = '*';
                password_conf.PasswordChar = '*';
                i = 0;
            }
        }

        private void EnviarMensaje_Click(object sender, EventArgs e) // Boton Enviar mensaje a los demas del chat
        {
            Enviados.Rows.Add(MensajeChat.Text);
            Recibidos.Rows.Add("");
            if (Host.Text == nickname.Text)
            { 
                string mensaje = "10/" + Invitado.Text + "/" + MensajeChat.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                string mensaje = "10/" + Host.Text + "/" + MensajeChat.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void ChatDescon_Click(object sender, EventArgs e)  // Boton Desconectar chat
        {
            Chat.Visible = false;
            groupBox1.Visible = true;
            Desconectar.Visible = true;
            //Enviamos un mensaje al servidor para que se desconecte el chat de todos
            if (Host.Text == nickname.Text)
            {
                string desconexion = "11/" + Invitado.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(desconexion);
                server.Send(msg);
            }
            else
            {
                string desconexion = "11/" + Host.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(desconexion);
                server.Send(msg);
            }
        }
    }
}
