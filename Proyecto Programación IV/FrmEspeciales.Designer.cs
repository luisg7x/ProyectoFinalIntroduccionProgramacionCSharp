﻿namespace Proyecto_Programación_IV
{
    partial class FrmEspeciales
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
            this.radioButtonEspecialidades = new System.Windows.Forms.RadioButton();
            this.radioButtonBebidas = new System.Windows.Forms.RadioButton();
            this.radioButtonBuffet = new System.Windows.Forms.RadioButton();
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
            this.panel1.Size = new System.Drawing.Size(483, 228);
            this.panel1.TabIndex = 5;
            this.panel1.Click += new System.EventHandler(this.buttonLimpiar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonEspecialidades);
            this.groupBox1.Controls.Add(this.radioButtonBebidas);
            this.groupBox1.Controls.Add(this.radioButtonBuffet);
            this.groupBox1.Location = new System.Drawing.Point(198, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 147);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // radioButtonEspecialidades
            // 
            this.radioButtonEspecialidades.AutoSize = true;
            this.radioButtonEspecialidades.Location = new System.Drawing.Point(41, 97);
            this.radioButtonEspecialidades.Name = "radioButtonEspecialidades";
            this.radioButtonEspecialidades.Size = new System.Drawing.Size(96, 17);
            this.radioButtonEspecialidades.TabIndex = 2;
            this.radioButtonEspecialidades.TabStop = true;
            this.radioButtonEspecialidades.Text = "Especialidades";
            this.radioButtonEspecialidades.UseVisualStyleBackColor = true;
            // 
            // radioButtonBebidas
            // 
            this.radioButtonBebidas.AutoSize = true;
            this.radioButtonBebidas.Location = new System.Drawing.Point(161, 40);
            this.radioButtonBebidas.Name = "radioButtonBebidas";
            this.radioButtonBebidas.Size = new System.Drawing.Size(63, 17);
            this.radioButtonBebidas.TabIndex = 1;
            this.radioButtonBebidas.TabStop = true;
            this.radioButtonBebidas.Text = "Bebidas";
            this.radioButtonBebidas.UseVisualStyleBackColor = true;
            // 
            // radioButtonBuffet
            // 
            this.radioButtonBuffet.AutoSize = true;
            this.radioButtonBuffet.Checked = true;
            this.radioButtonBuffet.Location = new System.Drawing.Point(41, 40);
            this.radioButtonBuffet.Name = "radioButtonBuffet";
            this.radioButtonBuffet.Size = new System.Drawing.Size(53, 17);
            this.radioButtonBuffet.TabIndex = 0;
            this.radioButtonBuffet.TabStop = true;
            this.radioButtonBuffet.Text = "Buffet";
            this.radioButtonBuffet.UseVisualStyleBackColor = true;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.BackColor = System.Drawing.Color.White;
            this.buttonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCerrar.FlatAppearance.BorderSize = 0;
            this.buttonCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonCerrar.Location = new System.Drawing.Point(285, 175);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(91, 41);
            this.buttonCerrar.TabIndex = 3;
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
            this.ButtonEntrar.Location = new System.Drawing.Point(382, 175);
            this.ButtonEntrar.Name = "ButtonEntrar";
            this.ButtonEntrar.Size = new System.Drawing.Size(89, 41);
            this.ButtonEntrar.TabIndex = 4;
            this.ButtonEntrar.Text = "ACEPTAR";
            this.ButtonEntrar.UseVisualStyleBackColor = true;
            this.ButtonEntrar.Click += new System.EventHandler(this.ButtonAceptar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Programación_IV.Properties.Resources.Administrative_Tools_961;
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
            this.panel2.Size = new System.Drawing.Size(483, 28);
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
            this.buttonMinimizar.Location = new System.Drawing.Point(427, -3);
            this.buttonMinimizar.Name = "buttonMinimizar";
            this.buttonMinimizar.Size = new System.Drawing.Size(34, 28);
            this.buttonMinimizar.TabIndex = 5;
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
            this.buttonExit.Location = new System.Drawing.Point(452, -3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(34, 28);
            this.buttonExit.TabIndex = 6;
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
            this.panel3.Size = new System.Drawing.Size(486, 38);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Especiales";
            // 
            // FrmEspeciales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 297);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmEspeciales";
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
        private System.Windows.Forms.RadioButton radioButtonEspecialidades;
        private System.Windows.Forms.RadioButton radioButtonBebidas;
        private System.Windows.Forms.RadioButton radioButtonBuffet;
    }
}

