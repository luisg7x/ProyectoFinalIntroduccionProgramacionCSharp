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
    public partial class FrmSeguridad : Form
    {
        string[] rols = new string[6];
        public FrmSeguridad()
        {
            InitializeComponent();
            radioButtonUsuarios.Enabled = false;
            radioButtonUnidadM.Enabled = false;
            radioButtonConsecutivos.Enabled = false;
            radioButtonRoles.Enabled = false;
            radioButtonCajas.Enabled = false;
            radioButtonPaises.Enabled = false;
            
            
   
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
            if (radioButtonUsuarios.Checked)
            {
                FrmListaUsuarios frm = new FrmListaUsuarios();
                frm.privilegios(rols);
                frm.Show();
           
            }
            if (radioButtonCajas.Checked)
            {
                FrmListaCaja frm = new FrmListaCaja();
                frm.privilegios(rols);
                frm.Show();
           
            }
            if (radioButtonConsecutivos.Checked)
            {
                FrmListaConsecutivos frm = new FrmListaConsecutivos();
                frm.privilegios(rols);
                frm.Show();
            }
            if (radioButtonRoles.Checked)
            {
                FrmListaRoles frm = new FrmListaRoles();
                frm.privilegios(rols);
                frm.Show();
            }
             if (radioButtonPaises.Checked)
            {
                FrmListaPaises frm = new FrmListaPaises();
                frm.privilegios(rols);
                frm.Show();
            }
             if (radioButtonUnidadM.Checked)
             {
                 FrmListaUnidadesMedida frm = new FrmListaUnidadesMedida();
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

            if (!string.IsNullOrEmpty(cadena[0]))
            {
                if (cadena[0].Equals("Administrador Seguridad"))
                {
                    radioButtonUsuarios.Enabled = true;
                    radioButtonUnidadM.Enabled = true;
                    radioButtonConsecutivos.Enabled = true;
                    radioButtonRoles.Enabled = true;
                    radioButtonCajas.Enabled = true;
                    radioButtonPaises.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[1]))
            {
                if (cadena[1].Equals("Administrador Sistema"))
                {
                    radioButtonUsuarios.Enabled = true;
                    radioButtonUnidadM.Enabled = true;
                    radioButtonConsecutivos.Enabled = true;
                    radioButtonRoles.Enabled = true;
                    radioButtonCajas.Enabled = true;
                    radioButtonPaises.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[2]))
            {
                if (cadena[2].Equals("Administrador Restaurante"))
                {
                    
                }
            }
            if (!string.IsNullOrEmpty(cadena[4]))
            {
                if (cadena[4].Equals("Administrador Cuentas"))
                {
                    radioButtonCajas.Enabled = true;
              
                }
            }

        }

        private void Bitacora(string descripcion, string detalle)
        {
            Querys cLogica_BD = new Querys();

            cLogica_BD.fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            cLogica_BD.usuario = rols[5];
            cLogica_BD.descripcion = descripcion;
            cLogica_BD.detalle = detalle;



            if (cLogica_BD.agregar_bitacora() == true)
            {
            }
            else
            {
                CustomMessageBox.ShowMessage("Ocurrio un problema al registra en la bitacora", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
