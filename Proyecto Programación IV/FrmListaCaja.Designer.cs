namespace Proyecto_Programación_IV
{
    partial class FrmListaCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxFecha = new System.Windows.Forms.CheckBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextboxNombre = new System.Windows.Forms.TextBox();
            this.TextboxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaIncial = new System.Windows.Forms.DateTimePicker();
            this.radioButtonCierre = new System.Windows.Forms.RadioButton();
            this.radioButtonAperura = new System.Windows.Forms.RadioButton();
            this.ButtonCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMinimizar = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(175, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(693, 302);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.checkBoxFecha);
            this.panel1.Controls.Add(this.buttonLimpiar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TextboxNombre);
            this.panel1.Controls.Add(this.TextboxCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePickerFechaIncial);
            this.panel1.Controls.Add(this.radioButtonCierre);
            this.panel1.Controls.Add(this.radioButtonAperura);
            this.panel1.Controls.Add(this.ButtonCerrar);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.buttonActualizar);
            this.panel1.Controls.Add(this.buttonBuscar);
            this.panel1.Location = new System.Drawing.Point(-5, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 494);
            this.panel1.TabIndex = 39;
            // 
            // checkBoxFecha
            // 
            this.checkBoxFecha.AutoSize = true;
            this.checkBoxFecha.Location = new System.Drawing.Point(575, 106);
            this.checkBoxFecha.Name = "checkBoxFecha";
            this.checkBoxFecha.Size = new System.Drawing.Size(78, 17);
            this.checkBoxFecha.TabIndex = 60;
            this.checkBoxFecha.Text = "Usar fecha";
            this.checkBoxFecha.UseVisualStyleBackColor = true;
            this.checkBoxFecha.CheckedChanged += new System.EventHandler(this.checkBoxFecha_CheckedChanged);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.BackColor = System.Drawing.Color.White;
            this.buttonLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLimpiar.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimpiar.ForeColor = System.Drawing.Color.White;
            this.buttonLimpiar.Image = global::Proyecto_Programación_IV.Properties.Resources.Broom_24;
            this.buttonLimpiar.Location = new System.Drawing.Point(767, 11);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(45, 41);
            this.buttonLimpiar.TabIndex = 59;
            this.buttonLimpiar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Nombre Retaurante:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Codigo Caja:";
            // 
            // TextboxNombre
            // 
            this.TextboxNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TextboxNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextboxNombre.Location = new System.Drawing.Point(219, 91);
            this.TextboxNombre.Name = "TextboxNombre";
            this.TextboxNombre.Size = new System.Drawing.Size(166, 20);
            this.TextboxNombre.TabIndex = 56;
            // 
            // TextboxCodigo
            // 
            this.TextboxCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TextboxCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextboxCodigo.Location = new System.Drawing.Point(219, 37);
            this.TextboxCodigo.Name = "TextboxCodigo";
            this.TextboxCodigo.Size = new System.Drawing.Size(166, 20);
            this.TextboxCodigo.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Fecha Registro:";
            // 
            // dateTimePickerFechaIncial
            // 
            this.dateTimePickerFechaIncial.Location = new System.Drawing.Point(414, 36);
            this.dateTimePickerFechaIncial.Name = "dateTimePickerFechaIncial";
            this.dateTimePickerFechaIncial.Size = new System.Drawing.Size(129, 20);
            this.dateTimePickerFechaIncial.TabIndex = 52;
            // 
            // radioButtonCierre
            // 
            this.radioButtonCierre.AutoSize = true;
            this.radioButtonCierre.Location = new System.Drawing.Point(575, 74);
            this.radioButtonCierre.Name = "radioButtonCierre";
            this.radioButtonCierre.Size = new System.Drawing.Size(76, 17);
            this.radioButtonCierre.TabIndex = 41;
            this.radioButtonCierre.Text = "Cierre Caja";
            this.radioButtonCierre.UseVisualStyleBackColor = true;
            this.radioButtonCierre.CheckedChanged += new System.EventHandler(this.radioButtonUsuario_CheckedChanged);
            // 
            // radioButtonAperura
            // 
            this.radioButtonAperura.AutoSize = true;
            this.radioButtonAperura.Location = new System.Drawing.Point(575, 39);
            this.radioButtonAperura.Name = "radioButtonAperura";
            this.radioButtonAperura.Size = new System.Drawing.Size(86, 17);
            this.radioButtonAperura.TabIndex = 40;
            this.radioButtonAperura.Text = "Aperura Caja";
            this.radioButtonAperura.UseVisualStyleBackColor = true;
            this.radioButtonAperura.CheckedChanged += new System.EventHandler(this.radioButtonGeneral_CheckedChanged);
            // 
            // ButtonCerrar
            // 
            this.ButtonCerrar.BackColor = System.Drawing.Color.White;
            this.ButtonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCerrar.FlatAppearance.BorderSize = 0;
            this.ButtonCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ButtonCerrar.Location = new System.Drawing.Point(785, 443);
            this.ButtonCerrar.Name = "ButtonCerrar";
            this.ButtonCerrar.Size = new System.Drawing.Size(83, 41);
            this.ButtonCerrar.TabIndex = 7;
            this.ButtonCerrar.Text = "CERRAR";
            this.ButtonCerrar.UseVisualStyleBackColor = true;
            this.ButtonCerrar.Click += new System.EventHandler(this.ButtonCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Proyecto_Programación_IV.Properties.Resources.Money_Bag_96;
            this.pictureBox1.Location = new System.Drawing.Point(44, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 102);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.BackColor = System.Drawing.Color.White;
            this.buttonActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonActualizar.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActualizar.ForeColor = System.Drawing.Color.White;
            this.buttonActualizar.Image = global::Proyecto_Programación_IV.Properties.Resources.Available_Updates_24;
            this.buttonActualizar.Location = new System.Drawing.Point(818, 11);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(45, 41);
            this.buttonActualizar.TabIndex = 4;
            this.buttonActualizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.BackColor = System.Drawing.Color.White;
            this.buttonBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBuscar.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscar.ForeColor = System.Drawing.Color.White;
            this.buttonBuscar.Image = global::Proyecto_Programación_IV.Properties.Resources.Search_24;
            this.buttonBuscar.Location = new System.Drawing.Point(716, 12);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(45, 41);
            this.buttonBuscar.TabIndex = 2;
            this.buttonBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(-5, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(880, 38);
            this.panel3.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lista  Caja";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel2.Controls.Add(this.buttonMinimizar);
            this.panel2.Controls.Add(this.buttonExit);
            this.panel2.Location = new System.Drawing.Point(-5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 28);
            this.panel2.TabIndex = 40;
            // 
            // buttonMinimizar
            // 
            this.buttonMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimizar.FlatAppearance.BorderSize = 0;
            this.buttonMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.buttonMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.buttonMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.buttonMinimizar.Image = global::Proyecto_Programación_IV.Properties.Resources.Minus_Math__241;
            this.buttonMinimizar.Location = new System.Drawing.Point(819, -3);
            this.buttonMinimizar.Name = "buttonMinimizar";
            this.buttonMinimizar.Size = new System.Drawing.Size(34, 28);
            this.buttonMinimizar.TabIndex = 25;
            this.buttonMinimizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimizar.UseVisualStyleBackColor = false;
            this.buttonMinimizar.Click += new System.EventHandler(this.buttonMinimizar_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.buttonExit.Image = global::Proyecto_Programación_IV.Properties.Resources.Delete_241;
            this.buttonExit.Location = new System.Drawing.Point(846, -3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(34, 28);
            this.buttonExit.TabIndex = 24;
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FrmListaCaja
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 562);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmListaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Restaurantes";
            this.Load += new System.EventHandler(this.FrmListaRestaurantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMinimizar;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button ButtonCerrar;
        private System.Windows.Forms.RadioButton radioButtonAperura;
        private System.Windows.Forms.RadioButton radioButtonCierre;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaIncial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextboxNombre;
        private System.Windows.Forms.TextBox TextboxCodigo;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.CheckBox checkBoxFecha;
    }
}