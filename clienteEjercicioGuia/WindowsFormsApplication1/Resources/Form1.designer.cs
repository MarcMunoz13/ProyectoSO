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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Host = new System.Windows.Forms.Label();
            this.Nick1 = new System.Windows.Forms.Label();
            this.Nick2 = new System.Windows.Forms.Label();
            this.Nick3 = new System.Windows.Forms.Label();
            this.Cont = new System.Windows.Forms.Label();
            this.Desconectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EnablePassword = new System.Windows.Forms.Button();
            this.InvitarButton = new System.Windows.Forms.Button();
            this.UsuarioEliminado = new System.Windows.Forms.TextBox();
            this.EliminarUsuario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password_conf = new System.Windows.Forms.TextBox();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistrarButton = new System.Windows.Forms.Button();
            this.SumaDuracion = new System.Windows.Forms.RadioButton();
            this.LogInButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Nick = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.DimeJugadores = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Consultar = new System.Windows.Forms.Button();
            this.Consulta = new System.Windows.Forms.TextBox();
            this.Invitacion = new System.Windows.Forms.GroupBox();
            this.Label_Invitacion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Rechazar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Bienvenido = new System.Windows.Forms.Label();
            this.ConectarButton = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.GroupBox();
            this.ChatLbl = new System.Windows.Forms.Label();
            this.Recibidos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChatDescon = new System.Windows.Forms.Button();
            this.Enviados = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnviarMensaje = new System.Windows.Forms.Button();
            this.MensajeChat = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.Invitacion.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recibidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enviados)).BeginInit();
            this.SuspendLayout();
            // 
            // Host
            // 
            this.Host.AutoSize = true;
            this.Host.Location = new System.Drawing.Point(651, 412);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(0, 13);
            this.Host.TabIndex = 33;
            this.Host.Visible = false;
            // 
            // Nick1
            // 
            this.Nick1.AutoSize = true;
            this.Nick1.Location = new System.Drawing.Point(651, 426);
            this.Nick1.Name = "Nick1";
            this.Nick1.Size = new System.Drawing.Size(0, 13);
            this.Nick1.TabIndex = 34;
            this.Nick1.Visible = false;
            // 
            // Nick2
            // 
            this.Nick2.AutoSize = true;
            this.Nick2.Location = new System.Drawing.Point(369, 215);
            this.Nick2.Name = "Nick2";
            this.Nick2.Size = new System.Drawing.Size(0, 13);
            this.Nick2.TabIndex = 35;
            this.Nick2.Visible = false;
            // 
            // Nick3
            // 
            this.Nick3.AutoSize = true;
            this.Nick3.Location = new System.Drawing.Point(375, 222);
            this.Nick3.Name = "Nick3";
            this.Nick3.Size = new System.Drawing.Size(0, 13);
            this.Nick3.TabIndex = 36;
            this.Nick3.Visible = false;
            // 
            // Cont
            // 
            this.Cont.AutoSize = true;
            this.Cont.Location = new System.Drawing.Point(381, 228);
            this.Cont.Name = "Cont";
            this.Cont.Size = new System.Drawing.Size(0, 13);
            this.Cont.TabIndex = 37;
            this.Cont.Visible = false;
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.Transparent;
            this.Desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Desconectar.ForeColor = System.Drawing.Color.Transparent;
            this.Desconectar.Image = global::WindowsFormsApplication1.Properties.Resources.desconectarse;
            this.Desconectar.Location = new System.Drawing.Point(310, 403);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(146, 36);
            this.Desconectar.TabIndex = 10;
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Visible = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(243)))), ((int)(((byte)(207)))));
            this.groupBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.degradado1;
            this.groupBox1.Controls.Add(this.EnablePassword);
            this.groupBox1.Controls.Add(this.InvitarButton);
            this.groupBox1.Controls.Add(this.UsuarioEliminado);
            this.groupBox1.Controls.Add(this.Desconectar);
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
            this.groupBox1.Controls.Add(this.Invitacion);
            this.groupBox1.Controls.Add(this.Bienvenido);
            this.groupBox1.Location = new System.Drawing.Point(-1, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 450);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // EnablePassword
            // 
            this.EnablePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EnablePassword.Image = global::WindowsFormsApplication1.Properties.Resources.see;
            this.EnablePassword.Location = new System.Drawing.Point(490, 58);
            this.EnablePassword.Name = "EnablePassword";
            this.EnablePassword.Size = new System.Drawing.Size(38, 21);
            this.EnablePassword.TabIndex = 31;
            this.EnablePassword.UseVisualStyleBackColor = true;
            this.EnablePassword.Click += new System.EventHandler(this.EnablePassword_Click);
            // 
            // InvitarButton
            // 
            this.InvitarButton.BackColor = System.Drawing.Color.Transparent;
            this.InvitarButton.Image = global::WindowsFormsApplication1.Properties.Resources.invitar;
            this.InvitarButton.Location = new System.Drawing.Point(188, 358);
            this.InvitarButton.Name = "InvitarButton";
            this.InvitarButton.Size = new System.Drawing.Size(50, 43);
            this.InvitarButton.TabIndex = 20;
            this.InvitarButton.UseVisualStyleBackColor = false;
            this.InvitarButton.Click += new System.EventHandler(this.InvitarButton_Click);
            // 
            // UsuarioEliminado
            // 
            this.UsuarioEliminado.Location = new System.Drawing.Point(542, 373);
            this.UsuarioEliminado.Name = "UsuarioEliminado";
            this.UsuarioEliminado.Size = new System.Drawing.Size(127, 20);
            this.UsuarioEliminado.TabIndex = 27;
            // 
            // EliminarUsuario
            // 
            this.EliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EliminarUsuario.Image = global::WindowsFormsApplication1.Properties.Resources.eliminar_usuario;
            this.EliminarUsuario.Location = new System.Drawing.Point(674, 362);
            this.EliminarUsuario.Name = "EliminarUsuario";
            this.EliminarUsuario.Size = new System.Drawing.Size(44, 46);
            this.EliminarUsuario.TabIndex = 26;
            this.EliminarUsuario.UseVisualStyleBackColor = true;
            this.EliminarUsuario.Click += new System.EventHandler(this.EliminarUsuario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(225, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "(solo para registrarse)";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(220, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Password Confirmation:";
            this.label1.Visible = false;
            // 
            // password_conf
            // 
            this.password_conf.Location = new System.Drawing.Point(344, 72);
            this.password_conf.Name = "password_conf";
            this.password_conf.PasswordChar = '*';
            this.password_conf.Size = new System.Drawing.Size(127, 20);
            this.password_conf.TabIndex = 23;
            this.password_conf.Visible = false;
            // 
            // ListaConectados
            // 
            this.ListaConectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaConectados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(24)))));
            this.ListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaConectados.DefaultCellStyle = dataGridViewCellStyle2;
            this.ListaConectados.Location = new System.Drawing.Point(11, 210);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaConectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ListaConectados.RowHeadersVisible = false;
            this.ListaConectados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ListaConectados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaConectados.Size = new System.Drawing.Size(226, 142);
            this.ListaConectados.TabIndex = 22;
            this.ListaConectados.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Conectados";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // RegistrarButton
            // 
            this.RegistrarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegistrarButton.Image = global::WindowsFormsApplication1.Properties.Resources.registrarse;
            this.RegistrarButton.Location = new System.Drawing.Point(490, 86);
            this.RegistrarButton.Name = "RegistrarButton";
            this.RegistrarButton.Size = new System.Drawing.Size(98, 28);
            this.RegistrarButton.TabIndex = 19;
            this.RegistrarButton.UseVisualStyleBackColor = true;
            this.RegistrarButton.Visible = false;
            this.RegistrarButton.Click += new System.EventHandler(this.RegistrarButton_Click);
            // 
            // SumaDuracion
            // 
            this.SumaDuracion.AutoSize = true;
            this.SumaDuracion.Location = new System.Drawing.Point(306, 172);
            this.SumaDuracion.Name = "SumaDuracion";
            this.SumaDuracion.Size = new System.Drawing.Size(175, 17);
            this.SumaDuracion.TabIndex = 18;
            this.SumaDuracion.TabStop = true;
            this.SumaDuracion.Text = "Duración total partidas ganadas";
            this.SumaDuracion.UseVisualStyleBackColor = true;
            this.SumaDuracion.Visible = false;
            // 
            // LogInButton
            // 
            this.LogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogInButton.Image = global::WindowsFormsApplication1.Properties.Resources.login;
            this.LogInButton.Location = new System.Drawing.Point(490, 19);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(96, 34);
            this.LogInButton.TabIndex = 17;
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(284, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Password:";
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.BackColor = System.Drawing.Color.Transparent;
            this.Nick.Location = new System.Drawing.Point(308, 27);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(32, 13);
            this.Nick.TabIndex = 15;
            this.Nick.Text = "Nick:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(344, 49);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(126, 20);
            this.password.TabIndex = 14;
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(344, 24);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(127, 20);
            this.nickname.TabIndex = 13;
            // 
            // DimeJugadores
            // 
            this.DimeJugadores.AutoSize = true;
            this.DimeJugadores.Location = new System.Drawing.Point(306, 149);
            this.DimeJugadores.Name = "DimeJugadores";
            this.DimeJugadores.Size = new System.Drawing.Size(199, 17);
            this.DimeJugadores.TabIndex = 8;
            this.DimeJugadores.TabStop = true;
            this.DimeJugadores.Text = "Dime que jugadores jugaron este día";
            this.DimeJugadores.UseVisualStyleBackColor = true;
            this.DimeJugadores.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(14, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha (DD-MM-AAAA):";
            this.label2.Visible = false;
            // 
            // Consultar
            // 
            this.Consultar.BackColor = System.Drawing.Color.Transparent;
            this.Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Consultar.Image = global::WindowsFormsApplication1.Properties.Resources.consultar;
            this.Consultar.Location = new System.Drawing.Point(306, 196);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(87, 23);
            this.Consultar.TabIndex = 5;
            this.Consultar.UseVisualStyleBackColor = false;
            this.Consultar.Visible = false;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // Consulta
            // 
            this.Consulta.ForeColor = System.Drawing.Color.Black;
            this.Consulta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Consulta.Location = new System.Drawing.Point(306, 124);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(164, 20);
            this.Consulta.TabIndex = 3;
            this.Consulta.Visible = false;
            this.Consulta.WordWrap = false;
            // 
            // Invitacion
            // 
            this.Invitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(240)))), ((int)(((byte)(79)))));
            this.Invitacion.Controls.Add(this.Label_Invitacion);
            this.Invitacion.Controls.Add(this.label5);
            this.Invitacion.Controls.Add(this.Rechazar);
            this.Invitacion.Controls.Add(this.Aceptar);
            this.Invitacion.Controls.Add(this.button1);
            this.Invitacion.Controls.Add(this.textBox1);
            this.Invitacion.Controls.Add(this.button2);
            this.Invitacion.Location = new System.Drawing.Point(160, 57);
            this.Invitacion.Name = "Invitacion";
            this.Invitacion.Size = new System.Drawing.Size(446, 228);
            this.Invitacion.TabIndex = 30;
            this.Invitacion.TabStop = false;
            this.Invitacion.Visible = false;
            // 
            // Label_Invitacion
            // 
            this.Label_Invitacion.AutoSize = true;
            this.Label_Invitacion.Location = new System.Drawing.Point(290, 75);
            this.Label_Invitacion.Name = "Label_Invitacion";
            this.Label_Invitacion.Size = new System.Drawing.Size(13, 13);
            this.Label_Invitacion.TabIndex = 28;
            this.Label_Invitacion.Text = "a";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Has sido invitado a chatear por ";
            // 
            // Rechazar
            // 
            this.Rechazar.BackColor = System.Drawing.Color.Transparent;
            this.Rechazar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Rechazar.Image = global::WindowsFormsApplication1.Properties.Resources.Rechazar;
            this.Rechazar.Location = new System.Drawing.Point(238, 106);
            this.Rechazar.Name = "Rechazar";
            this.Rechazar.Size = new System.Drawing.Size(135, 46);
            this.Rechazar.TabIndex = 30;
            this.Rechazar.UseVisualStyleBackColor = false;
            this.Rechazar.Click += new System.EventHandler(this.Rechazar_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.BackColor = System.Drawing.Color.Transparent;
            this.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Aceptar.ForeColor = System.Drawing.Color.Transparent;
            this.Aceptar.Image = global::WindowsFormsApplication1.Properties.Resources.Aceptar;
            this.Aceptar.Location = new System.Drawing.Point(85, 106);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(136, 46);
            this.Aceptar.TabIndex = 29;
            this.Aceptar.UseVisualStyleBackColor = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 18);
            this.button1.TabIndex = 20;
            this.button1.Text = "Invitar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(460, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 20);
            this.textBox1.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(613, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 28);
            this.button2.TabIndex = 26;
            this.button2.Text = "Eliminar Usuario";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Bienvenido
            // 
            this.Bienvenido.AutoSize = true;
            this.Bienvenido.BackColor = System.Drawing.Color.Transparent;
            this.Bienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bienvenido.Location = new System.Drawing.Point(236, 37);
            this.Bienvenido.Name = "Bienvenido";
            this.Bienvenido.Size = new System.Drawing.Size(321, 55);
            this.Bienvenido.TabIndex = 32;
            this.Bienvenido.Text = "Bienvenido titi";
            this.Bienvenido.Visible = false;
            // 
            // ConectarButton
            // 
            this.ConectarButton.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ConectarButton.Image = global::WindowsFormsApplication1.Properties.Resources.INICIO;
            this.ConectarButton.Location = new System.Drawing.Point(-1, -2);
            this.ConectarButton.Name = "ConectarButton";
            this.ConectarButton.Size = new System.Drawing.Size(742, 450);
            this.ConectarButton.TabIndex = 9;
            this.ConectarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ConectarButton.UseVisualStyleBackColor = true;
            this.ConectarButton.Click += new System.EventHandler(this.ConectarButton_Click);
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(243)))), ((int)(((byte)(207)))));
            this.Chat.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.degradado;
            this.Chat.Controls.Add(this.ChatLbl);
            this.Chat.Controls.Add(this.Recibidos);
            this.Chat.Controls.Add(this.ChatDescon);
            this.Chat.Controls.Add(this.Enviados);
            this.Chat.Controls.Add(this.EnviarMensaje);
            this.Chat.Controls.Add(this.MensajeChat);
            this.Chat.Location = new System.Drawing.Point(-1, -2);
            this.Chat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Chat.Size = new System.Drawing.Size(730, 437);
            this.Chat.TabIndex = 32;
            this.Chat.TabStop = false;
            this.Chat.Visible = false;
            // 
            // ChatLbl
            // 
            this.ChatLbl.AutoSize = true;
            this.ChatLbl.Location = new System.Drawing.Point(14, 20);
            this.ChatLbl.Name = "ChatLbl";
            this.ChatLbl.Size = new System.Drawing.Size(111, 13);
            this.ChatLbl.TabIndex = 32;
            this.ChatLbl.Text = "Estas chateando con:";
            // 
            // Recibidos
            // 
            this.Recibidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Recibidos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Recibidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(24)))));
            this.Recibidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Recibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Recibidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.Recibidos.Enabled = false;
            this.Recibidos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Recibidos.Location = new System.Drawing.Point(16, 36);
            this.Recibidos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Recibidos.Name = "Recibidos";
            this.Recibidos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Recibidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Recibidos.RowHeadersVisible = false;
            this.Recibidos.RowTemplate.Height = 24;
            this.Recibidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Recibidos.Size = new System.Drawing.Size(296, 334);
            this.Recibidos.TabIndex = 38;
            this.Recibidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Recibidos_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Recibido";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // ChatDescon
            // 
            this.ChatDescon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChatDescon.Image = global::WindowsFormsApplication1.Properties.Resources.desconectarse1;
            this.ChatDescon.Location = new System.Drawing.Point(592, 18);
            this.ChatDescon.Name = "ChatDescon";
            this.ChatDescon.Size = new System.Drawing.Size(143, 37);
            this.ChatDescon.TabIndex = 37;
            this.ChatDescon.UseVisualStyleBackColor = true;
            this.ChatDescon.Click += new System.EventHandler(this.ChatDescon_Click);
            // 
            // Enviados
            // 
            this.Enviados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Enviados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Enviados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(24)))));
            this.Enviados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Enviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Enviados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Enviados.Enabled = false;
            this.Enviados.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Enviados.Location = new System.Drawing.Point(310, 36);
            this.Enviados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Enviados.Name = "Enviados";
            this.Enviados.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Enviados.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Enviados.RowHeadersVisible = false;
            this.Enviados.RowTemplate.Height = 24;
            this.Enviados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Enviados.Size = new System.Drawing.Size(287, 334);
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
            this.EnviarMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EnviarMensaje.Image = global::WindowsFormsApplication1.Properties.Resources.enviar;
            this.EnviarMensaje.Location = new System.Drawing.Point(613, 363);
            this.EnviarMensaje.Name = "EnviarMensaje";
            this.EnviarMensaje.Size = new System.Drawing.Size(87, 28);
            this.EnviarMensaje.TabIndex = 34;
            this.EnviarMensaje.UseVisualStyleBackColor = true;
            this.EnviarMensaje.Click += new System.EventHandler(this.EnviarMensaje_Click);
            // 
            // MensajeChat
            // 
            this.MensajeChat.Location = new System.Drawing.Point(16, 367);
            this.MensajeChat.Name = "MensajeChat";
            this.MensajeChat.Size = new System.Drawing.Size(583, 20);
            this.MensajeChat.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(739, 444);
            this.Controls.Add(this.Cont);
            this.Controls.Add(this.Nick3);
            this.Controls.Add(this.Nick2);
            this.Controls.Add(this.Nick1);
            this.Controls.Add(this.Host);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConectarButton);
            this.Controls.Add(this.Chat);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
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
            ((System.ComponentModel.ISupportInitialize)(this.Recibidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enviados)).EndInit();
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
        private System.Windows.Forms.Label Nick1;
        private System.Windows.Forms.DataGridView Enviados;
        private System.Windows.Forms.Button ChatDescon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView Recibidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label Bienvenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label Nick2;
        private System.Windows.Forms.Label Nick3;
        private System.Windows.Forms.Label Cont;
    }
}

