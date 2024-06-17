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
    public partial class FrmAgregarRestaurante : Form
    {
        private Querys cLogica_BD;
        string[] rols = new string[6];
        string codigoValor = string.Empty;

        public FrmAgregarRestaurante()
        {
            InitializeComponent();
            codigo();
            
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
            maskedTextBoxTelefono.Clear();
            codigo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregar();
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            maskedTextBoxTelefono.Clear();
            codigo();
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || !Regex.IsMatch(textBoxEspecialidad.Text, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(textBoxDireccion.Text) || maskedTextBoxTelefono.Text.Equals("(000)0000-00-00") || !maskedTextBoxTelefono.MaskFull)
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en los campos: \n   Nombre y Especialidad o Direccion esta vacia. \n• Mascara incompleta o todos los datos son '0'.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void agregar()
        {

            if (validar() == false)
            {
                cLogica_BD = new Querys();
                cLogica_BD.codigoValor = codigoValor;
                cLogica_BD.nombre = textBoxNombre.Text;
                cLogica_BD.especialidad = textBoxEspecialidad.Text;
                cLogica_BD.direccion = textBoxDireccion.Text;
                cLogica_BD.telefono = maskedTextBoxTelefono.Text;
                if (checkBoxActivo.Checked)
                {
                    cLogica_BD.estado = "Activo";
                }
                else
                {
                    cLogica_BD.estado = "Inactivo";
                }
                
                if (cLogica_BD.agregar_Restaurante() == true)
                {
                    Bitacora("Se agrego un Restaurante", "Se agrego un Restaurante");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo();
                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void codigo()
        {
            Querys clogiga = new Querys();
            string[] valores = clogiga.CodigoTabla("CodigoRestaurante", "Restaurante");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];

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
