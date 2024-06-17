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
    public partial class FrmAgregarPuestos : Form
    {
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarPuestos()
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
            comboBoxRol.Items.Clear();
            comboBoxRol.SelectedIndex = -1;
            codigo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregar();
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            comboBoxRol.Items.Clear();
            comboBoxRol.SelectedIndex = -1;
            codigo();
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || comboBoxRol.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxRol.SelectedItem.ToString())) 
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en los campos: \n   Nombre.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void agregar()
        {

            if (validar() == false)
            {
                Querys cLogica_BD = new Querys();

                cLogica_BD.codigoValor = codigoValor;
                cLogica_BD.nombre = textBoxNombre.Text;
                cLogica_BD.rol = comboBoxRol.SelectedItem.ToString();
                if (radioButtonInterno.Checked)
                {
                    cLogica_BD.estado = "Si";
                    cLogica_BD.estado2 = "No";
                }
                if (radioButtonExterno.Checked)
                {
                    cLogica_BD.estado = "No";
                    cLogica_BD.estado2 = "Si";
                }

               

                if (cLogica_BD.agregar_Puesto() == true)
                {
                    Bitacora("Se agrego un Puesto", "Se agrego un Puesto");
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
            string[] valores = clogiga.CodigoTabla("CodigoPuesto", "Puestos");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radioButtonInterno_Click(object sender, EventArgs e)
        {
            if (radioButtonInterno.Checked)
            {
                comboBoxRol.Items.Clear();
                cargarRol();
            }
        }

        private void radioButtonExterno_Click(object sender, EventArgs e)
        {
            if(radioButtonExterno.Checked)
            {
                comboBoxRol.Items.Clear();
                cargarRol();
            }
        }

        private void cargarRol()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select NombreRol from Roles").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            { 
                comboBoxRol.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
            comboBoxRol.SelectedIndex = 0;
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
