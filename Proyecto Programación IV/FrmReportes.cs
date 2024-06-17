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
    public partial class FrmReportes : Form
    {
        string[] rols = new string[5];
        public FrmReportes()
        {
            InitializeComponent();
            radioButtonBitacora.Enabled = false;
            radioButtonClientes.Enabled = false;
            radioButtonFacturacion.Enabled = false;
   
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
            if (radioButtonBitacora.Checked)
            {
                FrmListaBitacora frm = new FrmListaBitacora();
                frm.Show();
           
            }
            if (radioButtonClientes.Checked)
            {
                FrmReportesClientes frm = new FrmReportesClientes();
                frm.Show();
            }
            if (radioButtonFacturacion.Checked)
            {
                FrmReportesFactura frm = new FrmReportesFactura();
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

            if (!string.IsNullOrEmpty(cadena[0]))
            {
                if (cadena[0].Equals("Administrador Seguridad"))
                {
                    radioButtonBitacora.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[1]))
            {
                if (cadena[1].Equals("Administrador Sistema"))
                {
                    radioButtonBitacora.Enabled = true;
                    radioButtonClientes.Enabled = true;
                    radioButtonFacturacion.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[2]))
            {
                if (cadena[2].Equals("Administrador Restaurante"))
                {
                    radioButtonBitacora.Enabled = true;
                    radioButtonClientes.Enabled = true;
                    radioButtonFacturacion.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[4]))
            {
                if (cadena[4].Equals("Administrador Cuentas"))
                {
                    radioButtonFacturacion.Enabled = true;
                }
            }
        }

    }
}
