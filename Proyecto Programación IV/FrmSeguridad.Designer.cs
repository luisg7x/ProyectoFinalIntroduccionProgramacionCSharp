namespace Proyecto_Programación_IV
{
    partial class FrmSeguridad
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonUnidadM = new System.Windows.Forms.RadioButton();
            this.radioButtonPaises = new System.Windows.Forms.RadioButton();
            this.radioButtonRoles = new System.Windows.Forms.RadioButton();
            this.radioButtonConsecutivos = new System.Windows.Forms.RadioButton();
            this.radioButtonCajas = new System.Windows.Forms.RadioButton();
            this.radioButtonUsuarios = new System.Windows.Forms.RadioButton();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.ButtonEntrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMinimizar = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonCerrar);
            this.panel1.Controls.Add(this.ButtonEntrar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 228);
            this.panel1.TabIndex = 5;
            this.panel1.Click += new System.EventHandler(this.buttonLimpiar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUnidadM);
            this.groupBox1.Controls.Add(this.radioButtonPaises);
            this.groupBox1.Controls.Add(this.radioButtonRoles);
            this.groupBox1.Controls.Add(this.radioButtonConsecutivos);
            this.groupBox1.Controls.Add(this.radioButtonCajas);
            this.groupBox1.Controls.Add(this.radioButtonUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(198, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 147);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // radioButtonUnidadM
            // 
            this.radioButtonUnidadM.AutoSize = true;
            this.radioButtonUnidadM.Location = new System.Drawing.Point(161, 117);
            this.radioButtonUnidadM.Name = "radioButtonUnidadM";
            this.radioButtonUnidadM.Size = new System.Drawing.Size(123, 17);
            this.radioButtonUnidadM.TabIndex = 5;
            this.radioButtonUnidadM.TabStop = true;
            this.radioButtonUnidadM.Text = "Unidades de Medida";
            this.radioButtonUnidadM.UseVisualStyleBackColor = true;
            // 
            // radioButtonPaises
            // 
            this.radioButtonPaises.AutoSize = true;
            this.radioButtonPaises.Location = new System.Drawing.Point(41, 117);
            this.radioButtonPaises.Name = "radioButtonPaises";
            this.radioButtonPaises.Size = new System.Drawing.Size(56, 17);
            this.radioButtonPaises.TabIndex = 4;
            this.radioButtonPaises.TabStop = true;
            this.radioButtonPaises.Text = "Paises";
            this.radioButtonPaises.UseVisualStyleBackColor = true;
            // 
            // radioButtonRoles
            // 
            this.radioButtonRoles.AutoSize = true;
            this.radioButtonRoles.Location = new System.Drawing.Point(161, 75);
            this.radioButtonRoles.Name = "radioButtonRoles";
            this.radioButtonRoles.Size = new System.Drawing.Size(103, 17);
            this.radioButtonRoles.TabIndex = 3;
            this.radioButtonRoles.TabStop = true;
            this.radioButtonRoles.Text = "Roles o Eventos";
            this.radioButtonRoles.UseVisualStyleBackColor = true;
            // 
            // radioButtonConsecutivos
            // 
            this.radioButtonConsecutivos.AutoSize = true;
            this.radioButtonConsecutivos.Location = new System.Drawing.Point(41, 75);
            this.radioButtonConsecutivos.Name = "radioButtonConsecutivos";
            this.radioButtonConsecutivos.Size = new System.Drawing.Size(89, 17);
            this.radioButtonConsecutivos.TabIndex = 2;
            this.radioButtonConsecutivos.TabStop = true;
            this.radioButtonConsecutivos.Text = "Consecutivos";
            this.radioButtonConsecutivos.UseVisualStyleBackColor = true;
            // 
            // radioButtonCajas
            // 
            this.radioButtonCajas.AutoSize = true;
            this.radioButtonCajas.Location = new System.Drawing.Point(161, 31);
            this.radioButtonCajas.Name = "radioButtonCajas";
            this.radioButtonCajas.Size = new System.Drawing.Size(51, 17);
            this.radioButtonCajas.TabIndex = 1;
            this.radioButtonCajas.TabStop = true;
            this.radioButtonCajas.Text = "Cajas";
            this.radioButtonCajas.UseVisualStyleBackColor = true;
            // 
            // radioButtonUsuarios
            // 
            this.radioButtonUsuarios.AutoSize = true;
            this.radioButtonUsuarios.Checked = true;
            this.radioButtonUsuarios.Location = new System.Drawing.Point(41, 31);
            this.radioButtonUsuarios.Name = "radioButtonUsuarios";
            this.radioButtonUsuarios.Size = new System.Drawing.Size(66, 17);
            this.radioButtonUsuarios.TabIndex = 0;
            this.radioButtonUsuarios.TabStop = true;
            this.radioButtonUsuarios.Text = "Usuarios";
            this.radioButtonUsuarios.UseVisualStyleBackColor = true;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.BackColor = System.Drawing.Color.White;
            this.buttonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCerrar.FlatAppearance.BorderSize = 0;
            this.buttonCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonCerrar.Location = new System.Drawing.Point(312, 175);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(85, 41);
            this.buttonCerrar.TabIndex = 5;
            this.buttonCerrar.Text = "CERRAR";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click_1);
            // 
            // ButtonEntrar
            // 
            this.ButtonEntrar.BackColor = System.Drawing.Color.White;
            this.ButtonEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEntrar.FlatAppearance.BorderSize = 0;
            this.ButtonEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEntrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.ButtonEntrar.Location = new System.Drawing.Point(403, 175);
            this.ButtonEntrar.Name = "ButtonEntrar";
            this.ButtonEntrar.Size = new System.Drawing.Size(97, 41);
            this.ButtonEntrar.TabIndex = 6;
            this.ButtonEntrar.Text = "ACEPTAR";
            this.ButtonEntrar.UseVisualStyleBackColor = true;
            this.ButtonEntrar.Click += new System.EventHandler(this.ButtonAceptar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Programación_IV.Properties.Resources.Lock_96;
            this.pictureBox1.Location = new System.Drawing.Point(36, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 125);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.panel2.Controls.Add(this.buttonMinimizar);
            this.panel2.Controls.Add(this.buttonExit);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 28);
            this.panel2.TabIndex = 6;
            // 
            // buttonMinimizar
            // 
            this.buttonMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimizar.FlatAppearance.BorderSize = 0;
            this.buttonMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonMinimizar.Image = global::Proyecto_Programación_IV.Properties.Resources.Minus_Math__241;
            this.buttonMinimizar.Location = new System.Drawing.Point(455, -3);
            this.buttonMinimizar.Name = "buttonMinimizar";
            this.buttonMinimizar.Size = new System.Drawing.Size(34, 28);
            this.buttonMinimizar.TabIndex = 7;
            this.buttonMinimizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimizar.UseVisualStyleBackColor = false;
            this.buttonMinimizar.Click += new System.EventHandler(this.buttonMinimizar_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonExit.Image = global::Proyecto_Programación_IV.Properties.Resources.Delete_241;
            this.buttonExit.Location = new System.Drawing.Point(480, -3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(34, 28);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 38);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seguridad";
            // 
            // FrmSeguridad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 297);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmSeguridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonEntrar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonMinimizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonConsecutivos;
        private System.Windows.Forms.RadioButton radioButtonCajas;
        private System.Windows.Forms.RadioButton radioButtonUsuarios;
        private System.Windows.Forms.RadioButton radioButtonPaises;
        private System.Windows.Forms.RadioButton radioButtonRoles;
        private System.Windows.Forms.RadioButton radioButtonUnidadM;
    }
}

