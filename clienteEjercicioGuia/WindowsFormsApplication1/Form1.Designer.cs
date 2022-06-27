namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.Consulta = new System.Windows.Forms.TextBox();
            this.Consultar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EnablePassword = new System.Windows.Forms.Button();
            this.InvitarButton = new System.Windows.Forms.Button();
            this.UsuarioEliminado = new System.Windows.Forms.TextBox();
            this.EliminarUsuario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password_conf = new System.Windows.Forms.TextBox();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.RegistrarButton = new System.Windows.Forms.Button();
            this.SumaDuracion = new System.Windows.Forms.RadioButton();
            this.LogInButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Nick = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.DimeJugadores = new System.Windows.Forms.RadioButton();
            this.Invitacion = new System.Windows.Forms.GroupBox();
            this.Label_Invitacion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Rechazar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.ConectarButton = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.GroupBox();
            this.ChatDescon = new System.Windows.Forms.Button();
            this.Enviados = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnviarMensaje = new System.Windows.Forms.Button();
            this.MensajeChat = new System.Windows.Forms.TextBox();
            this.ChatLbl = new System.Windows.Forms.Label();
            this.Host = new System.Windows.Forms.Label();
            this.Invitado = new System.Windows.Forms.Label();
            this.Recibidos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bienvenido = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.Invitacion.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Enviados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Recibidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(19, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha (DD-MM-AAAA):";
            this.label2.Visible = false;
            // 
            // Consulta
            // 
            this.Consulta.ForeColor = System.Drawing.Color.Black;
            this.Consulta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Consulta.Location = new System.Drawing.Point(408, 153);
            this.Consulta.Margin = new System.Windows.Forms.Padding(4);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(217, 22);
            this.Consulta.TabIndex = 3;
            this.Consulta.Visible = false;
            this.Consulta.WordWrap = false;
            // 
            // Consultar
            // 
            this.Consultar.Location = new System.Drawing.Point(408, 241);
            this.Consultar.Margin = new System.Windows.Forms.Padding(4);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(100, 28);
            this.Consultar.TabIndex = 5;
            this.Consultar.Text = "Consultar";
            this.Consultar.UseVisualStyleBackColor = true;
            this.Consultar.Visible = false;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.Bienvenido);
            this.groupBox1.Controls.Add(this.EnablePassword);
            this.groupBox1.Controls.Add(this.InvitarButton);
            this.groupBox1.Controls.Add(this.UsuarioEliminado);
            this.groupBox1.Controls.Add(this.EliminarUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.password_conf);
            this.groupBox1.Controls.Add(this.ListaConectados);
            this.groupBox1.Controls.Add(this.RegistrarButton);
            this.groupBox1.Controls.Add(this.SumaDuracion);
            this.groupBox1.Controls.Add(this.LogInButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Nick);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.nickname);
            this.groupBox1.Controls.Add(this.DimeJugadores);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Consultar);
            this.groupBox1.Controls.Add(this.Consulta);
            this.groupBox1.Location = new System.Drawing.Point(16, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(956, 388);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // EnablePassword
            // 
            this.EnablePassword.Location = new System.Drawing.Point(654, 72);
            this.EnablePassword.Margin = new System.Windows.Forms.Padding(4);
            this.EnablePassword.Name = "EnablePassword";
            this.EnablePassword.Size = new System.Drawing.Size(50, 26);
            this.EnablePassword.TabIndex = 31;
            this.EnablePassword.Text = "Pswrd";
            this.EnablePassword.UseVisualStyleBackColor = true;
            this.EnablePassword.Click += new System.EventHandler(this.EnablePassword_Click);
            // 
            // InvitarButton
            // 
            this.InvitarButton.Location = new System.Drawing.Point(242, 358);
            this.InvitarButton.Margin = new System.Windows.Forms.Padding(4);
            this.InvitarButton.Name = "InvitarButton";
            this.InvitarButton.Size = new System.Drawing.Size(84, 22);
            this.InvitarButton.TabIndex = 20;
            this.InvitarButton.Text = "Invitar";
            this.InvitarButton.UseVisualStyleBackColor = true;
            this.InvitarButton.Click += new System.EventHandler(this.InvitarButton_Click);
            // 
            // UsuarioEliminado
            // 
            this.UsuarioEliminado.Location = new System.Drawing.Point(641, 342);
            this.UsuarioEliminado.Margin = new System.Windows.Forms.Padding(4);
            this.UsuarioEliminado.Name = "UsuarioEliminado";
            this.UsuarioEliminado.Size = new System.Drawing.Size(168, 22);
            this.UsuarioEliminado.TabIndex = 27;
            // 
            // EliminarUsuario
            // 
            this.EliminarUsuario.Location = new System.Drawing.Point(817, 336);
            this.EliminarUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.EliminarUsuario.Name = "EliminarUsuario";
            this.EliminarUsuario.Size = new System.Drawing.Size(131, 34);
            this.EliminarUsuario.TabIndex = 26;
            this.EliminarUsuario.Text = "Eliminar Usuario";
            this.EliminarUsuario.UseVisualStyleBackColor = true;
            this.EliminarUsuario.Click += new System.EventHandler(this.EliminarUsuario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "(solo para registrarse)";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Password Confirmation:";
            this.label1.Visible = false;
            // 
            // password_conf
            // 
            this.password_conf.Location = new System.Drawing.Point(458, 89);
            this.password_conf.Margin = new System.Windows.Forms.Padding(4);
            this.password_conf.Name = "password_conf";
            this.password_conf.PasswordChar = '*';
            this.password_conf.Size = new System.Drawing.Size(168, 22);
            this.password_conf.TabIndex = 23;
            this.password_conf.Visible = false;
            // 
            // ListaConectados
            // 
            this.ListaConectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ListaConectados.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaConectados.DefaultCellStyle = dataGridViewCellStyle7;
            this.ListaConectados.Location = new System.Drawing.Point(25, 183);
            this.ListaConectados.Margin = new System.Windows.Forms.Padding(4);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaConectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ListaConectados.RowHeadersVisible = false;
            this.ListaConectados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ListaConectados.Size = new System.Drawing.Size(301, 175);
            this.ListaConectados.TabIndex = 22;
            this.ListaConectados.Visible = false;
            // 
            // RegistrarButton
            // 
            this.RegistrarButton.Location = new System.Drawing.Point(654, 106);
            this.RegistrarButton.Margin = new System.Windows.Forms.Padding(4);
            this.RegistrarButton.Name = "RegistrarButton";
            this.RegistrarButton.Size = new System.Drawing.Size(131, 34);
            this.RegistrarButton.TabIndex = 19;
            this.RegistrarButton.Text = "Registrarse";
            this.RegistrarButton.UseVisualStyleBackColor = true;
            this.RegistrarButton.Visible = false;
            this.RegistrarButton.Click += new System.EventHandler(this.RegistrarButton_Click);
            // 
            // SumaDuracion
            // 
            this.SumaDuracion.AutoSize = true;
            this.SumaDuracion.Location = new System.Drawing.Point(408, 212);
            this.SumaDuracion.Margin = new System.Windows.Forms.Padding(4);
            this.SumaDuracion.Name = "SumaDuracion";
            this.SumaDuracion.Size = new System.Drawing.Size(231, 21);
            this.SumaDuracion.TabIndex = 18;
            this.SumaDuracion.TabStop = true;
            this.SumaDuracion.Text = "Duración total partidas ganadas";
            this.SumaDuracion.UseVisualStyleBackColor = true;
            this.SumaDuracion.Visible = false;
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(654, 23);
            this.LogInButton.Margin = new System.Windows.Forms.Padding(4);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(128, 42);
            this.LogInButton.TabIndex = 17;
            this.LogInButton.Text = "Entrar";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Password:";
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(411, 33);
            this.Nick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(39, 17);
            this.Nick.TabIndex = 15;
            this.Nick.Text = "Nick:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(458, 60);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(167, 22);
            this.password.TabIndex = 14;
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(458, 30);
            this.nickname.Margin = new System.Windows.Forms.Padding(4);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(168, 22);
            this.nickname.TabIndex = 13;
            // 
            // DimeJugadores
            // 
            this.DimeJugadores.AutoSize = true;
            this.DimeJugadores.Location = new System.Drawing.Point(408, 183);
            this.DimeJugadores.Margin = new System.Windows.Forms.Padding(4);
            this.DimeJugadores.Name = "DimeJugadores";
            this.DimeJugadores.Size = new System.Drawing.Size(262, 21);
            this.DimeJugadores.TabIndex = 8;
            this.DimeJugadores.TabStop = true;
            this.DimeJugadores.Text = "Dime que jugadores jugaron este día";
            this.DimeJugadores.UseVisualStyleBackColor = true;
            this.DimeJugadores.Visible = false;
            // 
            // Invitacion
            // 
            this.Invitacion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Invitacion.Controls.Add(this.Label_Invitacion);
            this.Invitacion.Controls.Add(this.label5);
            this.Invitacion.Controls.Add(this.Rechazar);
            this.Invitacion.Controls.Add(this.Aceptar);
            this.Invitacion.Controls.Add(this.button1);
            this.Invitacion.Controls.Add(this.textBox1);
            this.Invitacion.Controls.Add(this.button2);
            this.Invitacion.Location = new System.Drawing.Point(180, 42);
            this.Invitacion.Margin = new System.Windows.Forms.Padding(4);
            this.Invitacion.Name = "Invitacion";
            this.Invitacion.Padding = new System.Windows.Forms.Padding(4);
            this.Invitacion.Size = new System.Drawing.Size(595, 280);
            this.Invitacion.TabIndex = 30;
            this.Invitacion.TabStop = false;
            this.Invitacion.Visible = false;
            // 
            // Label_Invitacion
            // 
            this.Label_Invitacion.AutoSize = true;
            this.Label_Invitacion.Location = new System.Drawing.Point(387, 92);
            this.Label_Invitacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Invitacion.Name = "Label_Invitacion";
            this.Label_Invitacion.Size = new System.Drawing.Size(37, 17);
            this.Label_Invitacion.TabIndex = 28;
            this.Label_Invitacion.Text = "Hola";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Has sido invitado a chatear por ";
            // 
            // Rechazar
            // 
            this.Rechazar.Location = new System.Drawing.Point(318, 130);
            this.Rechazar.Margin = new System.Windows.Forms.Padding(4);
            this.Rechazar.Name = "Rechazar";
            this.Rechazar.Size = new System.Drawing.Size(180, 57);
            this.Rechazar.TabIndex = 30;
            this.Rechazar.Text = "RECHAZAR";
            this.Rechazar.UseVisualStyleBackColor = true;
            this.Rechazar.Click += new System.EventHandler(this.Rechazar_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(113, 130);
            this.Aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(180, 57);
            this.Aceptar.TabIndex = 29;
            this.Aceptar.Text = "ACEPTAR";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 358);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 20;
            this.button1.Text = "Invitar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(614, 342);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 22);
            this.textBox1.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(817, 336);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 34);
            this.button2.TabIndex = 26;
            this.button2.Text = "Eliminar Usuario";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(380, 497);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(4);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(213, 44);
            this.Desconectar.TabIndex = 10;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Visible = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // ConectarButton
            // 
            this.ConectarButton.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ConectarButton.Image = global::WindowsFormsApplication1.Properties.Resources.messenger_logo_icon_png_31773;
            this.ConectarButton.Location = new System.Drawing.Point(16, 15);
            this.ConectarButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConectarButton.Name = "ConectarButton";
            this.ConectarButton.Size = new System.Drawing.Size(956, 488);
            this.ConectarButton.TabIndex = 9;
            this.ConectarButton.Text = "Conectarse";
            this.ConectarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ConectarButton.UseVisualStyleBackColor = true;
            this.ConectarButton.Click += new System.EventHandler(this.ConectarButton_Click);
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Chat.Controls.Add(this.Recibidos);
            this.Chat.Controls.Add(this.ChatDescon);
            this.Chat.Controls.Add(this.Enviados);
            this.Chat.Controls.Add(this.EnviarMensaje);
            this.Chat.Controls.Add(this.MensajeChat);
            this.Chat.Controls.Add(this.ChatLbl);
            this.Chat.Location = new System.Drawing.Point(23, 29);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(732, 329);
            this.Chat.TabIndex = 32;
            this.Chat.TabStop = false;
            this.Chat.Visible = false;
            // 
            // ChatDescon
            // 
            this.ChatDescon.Location = new System.Drawing.Point(609, 7);
            this.ChatDescon.Margin = new System.Windows.Forms.Padding(4);
            this.ChatDescon.Name = "ChatDescon";
            this.ChatDescon.Size = new System.Drawing.Size(116, 45);
            this.ChatDescon.TabIndex = 37;
            this.ChatDescon.Text = "Desconectar Chat";
            this.ChatDescon.UseVisualStyleBackColor = true;
            this.ChatDescon.Click += new System.EventHandler(this.ChatDescon_Click);
            // 
            // Enviados
            // 
            this.Enviados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Enviados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Enviados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Enviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Enviados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Enviados.Enabled = false;
            this.Enviados.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Enviados.Location = new System.Drawing.Point(314, 44);
            this.Enviados.Name = "Enviados";
            this.Enviados.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Enviados.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Enviados.RowHeadersVisible = false;
            this.Enviados.RowTemplate.Height = 24;
            this.Enviados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Enviados.Size = new System.Drawing.Size(287, 238);
            this.Enviados.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Enviado";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // EnviarMensaje
            // 
            this.EnviarMensaje.Location = new System.Drawing.Point(609, 283);
            this.EnviarMensaje.Margin = new System.Windows.Forms.Padding(4);
            this.EnviarMensaje.Name = "EnviarMensaje";
            this.EnviarMensaje.Size = new System.Drawing.Size(116, 34);
            this.EnviarMensaje.TabIndex = 34;
            this.EnviarMensaje.Text = "Enviar";
            this.EnviarMensaje.UseVisualStyleBackColor = true;
            this.EnviarMensaje.Click += new System.EventHandler(this.EnviarMensaje_Click);
            // 
            // MensajeChat
            // 
            this.MensajeChat.Location = new System.Drawing.Point(21, 289);
            this.MensajeChat.Margin = new System.Windows.Forms.Padding(4);
            this.MensajeChat.Name = "MensajeChat";
            this.MensajeChat.Size = new System.Drawing.Size(580, 22);
            this.MensajeChat.TabIndex = 33;
            // 
            // ChatLbl
            // 
            this.ChatLbl.AutoSize = true;
            this.ChatLbl.Location = new System.Drawing.Point(18, 24);
            this.ChatLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChatLbl.Name = "ChatLbl";
            this.ChatLbl.Size = new System.Drawing.Size(145, 17);
            this.ChatLbl.TabIndex = 32;
            this.ChatLbl.Text = "Estas chateando con:";
            // 
            // Host
            // 
            this.Host.AutoSize = true;
            this.Host.Location = new System.Drawing.Point(868, 507);
            this.Host.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(0, 17);
            this.Host.TabIndex = 33;
            this.Host.Visible = false;
            // 
            // Invitado
            // 
            this.Invitado.AutoSize = true;
            this.Invitado.Location = new System.Drawing.Point(868, 524);
            this.Invitado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Invitado.Name = "Invitado";
            this.Invitado.Size = new System.Drawing.Size(0, 17);
            this.Invitado.TabIndex = 34;
            this.Invitado.Visible = false;
            // 
            // Recibidos
            // 
            this.Recibidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Recibidos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Recibidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Recibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Recibidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.Recibidos.Enabled = false;
            this.Recibidos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Recibidos.Location = new System.Drawing.Point(32, 44);
            this.Recibidos.Name = "Recibidos";
            this.Recibidos.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Recibidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Recibidos.RowHeadersVisible = false;
            this.Recibidos.RowTemplate.Height = 24;
            this.Recibidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Recibidos.Size = new System.Drawing.Size(287, 238);
            this.Recibidos.TabIndex = 38;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Recibido";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Bienvenido
            // 
            this.Bienvenido.AutoSize = true;
            this.Bienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bienvenido.Location = new System.Drawing.Point(285, 42);
            this.Bienvenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bienvenido.Name = "Bienvenido";
            this.Bienvenido.Size = new System.Drawing.Size(404, 69);
            this.Bienvenido.TabIndex = 32;
            this.Bienvenido.Text = "Bienvenido titi";
            this.Bienvenido.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Conectados";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(985, 547);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Invitado);
            this.Controls.Add(this.Host);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.Invitacion);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.ConectarButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.Invitacion.ResumeLayout(false);
            this.Invitacion.PerformLayout();
            this.Chat.ResumeLayout(false);
            this.Chat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Enviados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Recibidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Consulta;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DimeJugadores;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button ConectarButton;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Nick;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.RadioButton SumaDuracion;
        private System.Windows.Forms.Button RegistrarButton;
        private System.Windows.Forms.DataGridView ListaConectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_conf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EliminarUsuario;
        private System.Windows.Forms.TextBox UsuarioEliminado;
        private System.Windows.Forms.Button InvitarButton;
        private System.Windows.Forms.GroupBox Invitacion;
        private System.Windows.Forms.Button Rechazar;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Label Label_Invitacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EnablePassword;
        private System.Windows.Forms.GroupBox Chat;
        private System.Windows.Forms.Button EnviarMensaje;
        private System.Windows.Forms.TextBox MensajeChat;
        private System.Windows.Forms.Label ChatLbl;
        private System.Windows.Forms.Label Host;
        private System.Windows.Forms.Label Invitado;
        private System.Windows.Forms.DataGridView Enviados;
        private System.Windows.Forms.Button ChatDescon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView Recibidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label Bienvenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

