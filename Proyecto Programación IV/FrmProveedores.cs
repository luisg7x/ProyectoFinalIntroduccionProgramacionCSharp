using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica_Proyecto;



namespace Proyecto_Programación_IV
{
    public partial class FrmProveedores : Form
    {
        string[] rols = new string[6];
        public FrmProveedores()
        {
            InitializeComponent();
   
        }


        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            comprobar();
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
        }

        private void buttonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comprobar()
        {
            if (radioButtonMarcas.Checked)
            {
                FrmListaMarcas frm = new FrmListaMarcas();
                frm.privilegios(rols);
                frm.Show();
           
            }
            if (radioButtonProductos.Checked)
            {
                FrmProductos frm = new FrmProductos();
                frm.privilegios(rols);
                frm.Show();
            }
            if (radioButtonProveedores.Checked)
            {
                FrmListaProveedores frm = new FrmListaProveedores();
                frm.privilegios(rols);
                frm.Show();
            }
        }

        public void privilegios(string[] cadena)
        {
            rols[0] = cadena[0];
            rols[1] = cadena[1];
            rols[2] = cadena[2];
            rols[3] = cadena[3];
            rols[4] = cadena[4];
            rols[5] = cadena[5];
        }

    }
}
