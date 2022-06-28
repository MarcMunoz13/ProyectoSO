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
                    case 1:       //repuesta al log in

                        if (trozos[1] == "SI")
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
                        else if (trozos[1] == "NO")
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
                            MessageBox.Show("Los jugadores que jugaron ese día son:" + trozos[1] + " " + trozos[2]);
                        }
                        break;

                    case 3:     //respuesta a consulta 2

                        if (trozos[1] == "NO")
                        {
                            MessageBox.Show("No hay partidas de ese jugador");
                        }
                        else
                        {
                            MessageBox.Show("La duración total de partidas ganadas es: " + trozos[1]);
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
                            Invoke(new Action(() =>
                            {
                                RegistrarButton.Visible = false;
                                password_conf.Visible = false;
                                label1.Visible = false;
                                label4.Visible = false;
                                password_conf.Clear();
                                MessageBox.Show("Registrado con exito, logeate");
                            }));
                        }
                        else
                        {
                            MessageBox.Show("El nombre que intentas utilizar ya existe");
                        }
                        break;

                    case 6:
                        Invoke(new Action(() =>
                            {
                                if (UsuarioEliminado.Text == nickname.Text)
                                {
                                    groupBox1.Visible = false;
                                    Desconectar.Visible = false;
                                    ConectarButton.Visible = true;
                                    string mensaje1 = "0/";
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                                    server.Send(msg);
                                    // Nos desconectamos
                                    atender.Abort();
                                    this.BackColor = Color.Gray;
                                    server.Shutdown(SocketShutdown.Both);
                                    server.Close();
                                    MessageBox.Show("Has eliminado tu cuenta con exito");
                                }
                                else
                                {
                                    MessageBox.Show("Has eliminado al usuario " + UsuarioEliminado.Text);
                                }
                                UsuarioEliminado.Clear();
                            }));          
                        break;

                    case 7:
                        if (trozos[1] == nickname.Text)
                        {
                            MessageBox.Show("No te puedes invitar a ti mismo");
                        }
                        else
                        {
                            if (trozos[1] == "-1")
                            {
                                MessageBox.Show("Error al invitar al jugador");
                            }
                            else
                            {
                                MessageBox.Show("La invitación ha sido enviada con exito");
                            }
                        }
                        break;
                    case 8:
                        int contador = Convert.ToInt32(trozos[1]);
                        string host = trozos[2].Split('\0')[0];
                        string nick1 = trozos[3].Split('\0')[0];
                        if (contador == 1)
                        {
                            Invoke(new Action(() =>
                                {
                                    Invitacion.Visible = true;
                                    Invitacion.BringToFront();
                                    Label_Invitacion.Text = host;
                                    Cont.Text = Convert.ToString(contador);
                                    Host.Text = host;
                                    Nick1.Text = nick1;
                                }));
                        }
                        else if (contador == 2)
                        {
                            string nick2 = trozos[4].Split('\0')[0];
                            Invoke(new Action(() =>
                            {
                                Invitacion.Visible = true;
                                Invitacion.BringToFront();
                                Label_Invitacion.Text = host;
                                Cont.Text = Convert.ToString(contador);
                                Host.Text = host;
                                Nick1.Text = nick1;
                                Nick2.Text = nick2;
                            }));
                        }
                        else if (contador == 3)
                        {
                            string nick2 = trozos[4].Split('\0')[0];
                            string nick3 = trozos[5].Split('\0')[0];
                            Invoke(new Action(() =>
                            {
                                Invitacion.Visible = true;
                                Invitacion.BringToFront();
                                Label_Invitacion.Text = host;
                                Cont.Text = Convert.ToString(contador);
                                Host.Text = host;
                                Nick1.Text = nick1;
                                Nick2.Text = nick2;
                                Nick3.Text = nick3;
                            }));
                        }
                        break;

                    case 9:
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
                    case 10:
                        Invoke(new Action(() =>
                        {

                            Recibidos.Rows.Add(trozos[2] + ": " +  trozos[1]);
                            Enviados.Rows.Add("");
                        }));
                        break;
                    case 11:
                        int cont = 0;
                        Invoke(new Action(() =>
                        {
                            Recibidos.Rows.Add(trozos[1] + "se ha desconectado del chat");
                            Enviados.Rows.Add("");
                            cont++;
                            if (Convert.ToString(cont) == Cont.Text)
                            {
                                MessageBox.Show("te has quedado solo en el chat");
                            }
                        }));
                        break;
                    case 12: //Guardar variables en el host
                        int numero = Convert.ToInt32(trozos[1]);
                        string jefe = trozos[2].Split('\0')[0];
                        string nickname1 = trozos[3].Split('\0')[0];
                        if (numero == 1)
                        {
                            Invoke(new Action(() =>
                                {
                                    Cont.Text = Convert.ToString(numero);
                                    Host.Text = jefe;
                                    Nick1.Text = nickname1;
                                }));
                        }
                        else if (numero == 2)
                        {
                            string nick2 = trozos[4].Split('\0')[0];
                            Invoke(new Action(() =>
                            {
                                Cont.Text = Convert.ToString(numero);
                                Host.Text = jefe;
                                Nick1.Text = nickname1;
                                Nick2.Text = nick2;
                            }));
                        }
                        else if (numero == 3)
                        {
                            string nick2 = trozos[4].Split('\0')[0];
                            string nick3 = trozos[5].Split('\0')[0];
                            Invoke(new Action(() =>
                            {
                                Cont.Text = Convert.ToString(numero);
                                Host.Text = jefe;
                                Nick1.Text = nickname1;
                                Nick2.Text = nick2;
                                Nick3.Text = nick3;
                            }));
                        }
                        break;
                }
            }
        }



        private void ConectarButton_Click(object sender, EventArgs e)// boton conectar
        {
            groupBox1.Visible = true;
            ConectarButton.Visible = false;
            Desconectar.Visible = true;
            nickname.Clear();
            password.Clear();
            nickname.ReadOnly = false;
            password.ReadOnly = false;
            Nick.Visible = true;
            nickname.Visible = true;
            label3.Visible = true;
            password.Visible = true;
            EnablePassword.Visible = true;
            LogInButton.Visible = true;
            UsuarioEliminado.Visible = true;
            EliminarUsuario.Visible = true;
            ListaConectados.Visible = false;
            label2.Visible = false;
            Consulta.Visible = false;
            Consultar.Visible = false;
            DimeJugadores.Visible = false;
            SumaDuracion.Visible = false;
            Bienvenido.Visible = false;
            InvitarButton.Visible = false;

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9089);


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

        private void LogInButton_Click(object sender, EventArgs e)//botón entrar
        {
            if (String.IsNullOrWhiteSpace(nickname.Text) || (nickname.Text.Length < 1))
            {
                MessageBox.Show("Rellena el nombre");
            }
            else if (String.IsNullOrWhiteSpace(password.Text) || (password.Text.Length < 1))
            {
                MessageBox.Show("Rellena la contraseña");
            }
            else
            {
                RegistrarButton.Visible = false;
                password_conf.Visible = false;
                label1.Visible = false;
                label4.Visible = false;
                InvitarButton.Visible = true;
                string mensaje = "1/" + nickname.Text + "/" + password.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }       
        }

        private void Consultar_Click(object sender, EventArgs e) // boton enviar
        {
            if (DimeJugadores.Checked)
            {
                if (String.IsNullOrWhiteSpace(Consulta.Text) || (Consulta.Text.Length < 1))
                {
                    MessageBox.Show("Rellena los huecos");
                }
                else
                {
                    string mensaje = "2/" + Consulta.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            if (SumaDuracion.Checked)
            {
                if (String.IsNullOrWhiteSpace(Consulta.Text) || (Consulta.Text.Length < 1))
                {
                    MessageBox.Show("Rellena los huecos");
                }
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

        private void EliminarUsuario_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + UsuarioEliminado.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }


        private void RegistrarButton_Click(object sender, EventArgs e)
        {
                   if ((password.Text.Length > 3) && (nickname.Text.Length > 3))
                   {
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

        private void InvitarButton_Click(object sender, EventArgs e)
        {
            string mensaje = "7/";
            string nombres = "";
            int cont = 0;
            Host.Text = nickname.Text;

            foreach (DataGridViewRow row in ListaConectados.SelectedRows)
            {
                string nombre = row.Cells[0].Value.ToString();
                
                //hacer que pare si el nombre selecionado es el tuyo
                if (nombre == nickname.Text)
                {
                    MessageBox.Show("No te invites a ti mismo");
                }
                else
                {
                    nombres = nombres + nombre + "/";
                    cont++;
                }
            }
            mensaje = mensaje + cont + "/" + nickname.Text + "/" + nombres;
            mensaje = mensaje.Remove(mensaje.Length - 1);            
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            Host.Text = nickname.Text;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
                string mensaje = "8/SI/" + Label_Invitacion.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            
            Invitacion.Visible = false;
            Chat.Visible = true;
            Desconectar.Visible = false;
            groupBox1.Visible = false;
        }

        private void Rechazar_Click(object sender, EventArgs e)
        {
                string mensaje = "8/NO/" + Label_Invitacion.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            
            Invitacion.Visible = false;
            groupBox1.Visible = true;
            Desconectar.Visible = true;
            groupBox1.Visible = false;
        }

        int i = 0;
        private void EnablePassword_Click(object sender, EventArgs e)
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

        private void EnviarMensaje_Click(object sender, EventArgs e) //Enviar mensaje a los demás
        {
            if (String.IsNullOrWhiteSpace(MensajeChat.Text) || (MensajeChat.Text.Length < 1))
            {
            }
            else
            {
                MensajeChat.Clear();
                //añadimos el mensaje al data grid view
                Enviados.Rows.Add(nickname.Text + ": " + MensajeChat.Text);
                Recibidos.Rows.Add("");
                //Dependiendo del contador hara diferentes envios
                if (Cont.Text == "1")
                {
                    if (Host.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Nick1.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Nick1.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Host.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                }
                if (Cont.Text == "2")
                {
                    if (Host.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Nick1.Text + "/" + Nick2.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Nick1.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Host.Text + "/" + Nick2.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Nick2.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Host.Text + "/" + Nick1.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    //añadir lo que falta y añadir contador para luego trabajar en el servidor
                }
                if (Cont.Text == "3")
                {
                    if (Host.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Nick1.Text + "/" + Nick2.Text + "/" + Nick3.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Nick1.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Host.Text + "/" + Nick2.Text + "/" + Nick3.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Nick2.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Host.Text + "/" + Nick1.Text + "/" + Nick3.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Nick3.Text == nickname.Text)
                    {
                        string mensaje = "10/" + Cont.Text + "/" + Host.Text + "/" + Nick1.Text + "/" + Nick2.Text + "/" + MensajeChat.Text + "/" + nickname.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                }
            }
        }

        private void ChatDescon_Click(object sender, EventArgs e) //cerrar chat
        {
            //Visibilizamos el menu
            Chat.Visible = false;
            groupBox1.Visible = true;
            Desconectar.Visible = true;
            //envia mensaje conforme se ha ido
            if (Cont.Text == "1")
            {
                if (Host.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Nick1.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (Nick1.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Host.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            if (Cont.Text == "2")
            {
                if (Host.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Nick1.Text + "/" + Nick2.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (Nick1.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Host.Text + "/" + Nick2.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (Nick2.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Host.Text + "/" + Nick1.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            if (Cont.Text == "3")
            {
                if (Host.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Nick1.Text + "/" + Nick2.Text + "/" + Nick3.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (Nick1.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Host.Text + "/" + Nick2.Text + "/" + Nick3.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (Nick2.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Host.Text + "/" + Nick1.Text + "/" + Nick3.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (Nick3.Text == nickname.Text)
                {
                    string mensaje = "11/" + Cont.Text + "/" + Host.Text + "/" + Nick1.Text + "/" + Nick2.Text + "/" + nickname.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }
    }
}
