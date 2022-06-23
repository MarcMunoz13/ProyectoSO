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
            this.label2 = new System.Windows.Forms.Label();
            this.Consulta = new System.Windows.Forms.TextBox();
            this.Consultar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ListaCon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.password_conf = new System.Windows.Forms.TextBox();
            this.RegistrarButton = new System.Windows.Forms.Button();
            this.SumaDuracion = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Nick = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.DimeJugadores = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha (DD-MM-AAAA):";
            // 
            // Consulta
            // 
            this.Consulta.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Consulta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Consulta.Location = new System.Drawing.Point(284, 266);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(164, 20);
            this.Consulta.TabIndex = 3;
            this.Consulta.TextChanged += new System.EventHandler(this.Fecha_TextChanged);
            // 
            // Consultar
            // 
            this.Consultar.Location = new System.Drawing.Point(284, 379);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(75, 23);
            this.Consultar.TabIndex = 5;
            this.Consultar.Text = "Consultar";
            this.Consultar.UseVisualStyleBackColor = true;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.ListaConectados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ListaCon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.password_conf);
            this.groupBox1.Controls.Add(this.RegistrarButton);
            this.groupBox1.Controls.Add(this.SumaDuracion);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Nick);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.nickname);
            this.groupBox1.Controls.Add(this.DimeJugadores);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Consultar);
            this.groupBox1.Controls.Add(this.Consulta);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1124, 541);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ListaConectados
            // 
            this.ListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.Location = new System.Drawing.Point(601, 64);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.RowHeadersVisible = false;
            this.ListaConectados.Size = new System.Drawing.Size(246, 142);
            this.ListaConectados.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "(solo para registrarse)";
            // 
            // ListaCon
            // 
            this.ListaCon.Location = new System.Drawing.Point(601, 223);
            this.ListaCon.Name = "ListaCon";
            this.ListaCon.Size = new System.Drawing.Size(93, 41);
            this.ListaCon.TabIndex = 19;
            this.ListaCon.Text = "Lista Conectados";
            this.ListaCon.UseVisualStyleBackColor = true;
            this.ListaCon.Click += new System.EventHandler(this.ListaCon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Password Confirmation:";
            // 
            // password_conf
            // 
            this.password_conf.Location = new System.Drawing.Point(193, 129);
            this.password_conf.Name = "password_conf";
            this.password_conf.Size = new System.Drawing.Size(127, 20);
            this.password_conf.TabIndex = 24;
            // 
            // RegistrarButton
            // 
            this.RegistrarButton.Location = new System.Drawing.Point(363, 125);
            this.RegistrarButton.Name = "RegistrarButton";
            this.RegistrarButton.Size = new System.Drawing.Size(96, 34);
            this.RegistrarButton.TabIndex = 19;
            this.RegistrarButton.Text = "Registrarse";
            this.RegistrarButton.UseVisualStyleBackColor = true;
            this.RegistrarButton.Click += new System.EventHandler(this.RegistrarButton_Click);
            // 
            // SumaDuracion
            // 
            this.SumaDuracion.AutoSize = true;
            this.SumaDuracion.Location = new System.Drawing.Point(284, 315);
            this.SumaDuracion.Name = "SumaDuracion";
            this.SumaDuracion.Size = new System.Drawing.Size(175, 17);
            this.SumaDuracion.TabIndex = 18;
            this.SumaDuracion.TabStop = true;
            this.SumaDuracion.Text = "Duración total partidas ganadas";
            this.SumaDuracion.UseVisualStyleBackColor = true;
            this.SumaDuracion.CheckedChanged += new System.EventHandler(this.SumaDuracion_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(363, 77);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 34);
            this.button4.TabIndex = 17;
            this.button4.Text = "Log in";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Password:";
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(146, 64);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(32, 13);
            this.Nick.TabIndex = 15;
            this.Nick.Text = "Nick:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(194, 91);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(126, 20);
            this.password.TabIndex = 14;
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(194, 57);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(127, 20);
            this.nickname.TabIndex = 13;
            this.nickname.TextChanged += new System.EventHandler(this.nickcname_TextChanged);
            // 
            // DimeJugadores
            // 
            this.DimeJugadores.AutoSize = true;
            this.DimeJugadores.Location = new System.Drawing.Point(284, 292);
            this.DimeJugadores.Name = "DimeJugadores";
            this.DimeJugadores.Size = new System.Drawing.Size(199, 17);
            this.DimeJugadores.TabIndex = 8;
            this.DimeJugadores.TabStop = true;
            this.DimeJugadores.Text = "Dime que jugadores jugaron este día";
            this.DimeJugadores.UseVisualStyleBackColor = true;
            this.DimeJugadores.CheckedChanged += new System.EventHandler(this.DimeJugadores_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 632);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 36);
            this.button3.TabIndex = 10;
            this.button3.Text = "Desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 688);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Consulta;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DimeJugadores;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Nick;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Button ListaCon;
        private System.Windows.Forms.RadioButton SumaDuracion;
        private System.Windows.Forms.Button RegistrarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_conf;
        private System.Windows.Forms.DataGridView ListaConectados;
    }
}

