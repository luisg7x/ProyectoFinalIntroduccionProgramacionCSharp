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
using System.Text.RegularExpressions;


namespace Proyecto_Programación_IV
{
    public partial class FrmAgregarConsecutivos : Form
    {
        string[] rols = new string[6];
        public FrmAgregarConsecutivos()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndex = 0;
            textBoxPrefijo.Enabled = false;
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
  
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregar();
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);

        }

        private Boolean validar()
        {
            if (checkBoxPrefijo.Checked)
            {
                if ( string.IsNullOrEmpty(textBoxPrefijo.Text) || string.IsNullOrEmpty(textBoxDescripcion.Text) || string.IsNullOrEmpty(textBoxValorConsecutivo.Text)) 
                {
                    CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en los campos: \n   Prefijo y Descripcion esta vacia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                return false;
            }
           
            if (string.IsNullOrEmpty(textBoxDescripcion.Text) || string.IsNullOrEmpty(textBoxValorConsecutivo.Text))
                {
                    CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en los campos: \n   Prefijo y Descripcion esta vacia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                    return false;
            
     
        }

        private void agregar()
        {

            if (validar() == false)
            {
                Querys cLogica_BD = new Querys();
                cLogica_BD.tipo = comboBoxTipo.SelectedItem.ToString();
                cLogica_BD.descripcion = textBoxDescripcion.Text; 
                cLogica_BD.numero = textBoxValorConsecutivo.Text;
                if (checkBoxPrefijo.Checked)
                {
                    cLogica_BD.prefijo = textBoxPrefijo.Text;
                    cLogica_BD.estado = "Si";
                }
                if (!checkBoxPrefijo.Checked)
                {
                    cLogica_BD.estado = "No";
                }

                if (cLogica_BD.agregar_Consecutivo() == true)
                {
                    Bitacora("Agrego un Consecutivo", "Agrego Consecutivo");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos, Probablemente ya \nel Tipo Consecutivo ya Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBoxPrefijo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPrefijo.Checked)
            {
                textBoxPrefijo.Enabled = true;
            }
            else {
                textBoxPrefijo.Enabled = false;
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
