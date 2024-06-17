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
    public partial class FrmAdministracion : Form
    {
        string[] rols = new string[6];
        public FrmAdministracion()
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
            if (radioButtonEspecial.Checked)
            {
                FrmEspeciales frm = new FrmEspeciales();
                frm.privilegios(rols);
                frm.Show();
            }
            if (radioButtonMesas.Checked)
            {
                FrmListaMesas frm = new FrmListaMesas();
                frm.privilegios(rols);
                frm.Show();
            }
            if (radioButtonEmpleados.Checked)
            {
                FrmListaEmpleados frm = new FrmListaEmpleados();
                frm.privilegios(rols);
                frm.Show();
            }
            if (radioButtonPuesto.Checked)
            {
                FrmListaPuestos frm = new FrmListaPuestos();;
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
