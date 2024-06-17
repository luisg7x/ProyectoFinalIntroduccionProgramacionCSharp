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
using System.IO;
using System.Drawing.Imaging;


namespace Proyecto_Programación_IV
{
    public partial class FrmAgregarComestibles : Form
    {
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarComestibles()
        {
            InitializeComponent();
            codigo();
            cargarComboMarca();
            cargarComboRestaurante();
            cargarComboUnidades();
            comboBoxTipo.SelectedIndex = 0;
            comboBoxLinea.SelectedIndex = 0;
            comboBoxClase.SelectedIndex = 0;
            
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
            codigo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregar();
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            comboBoxTipo.SelectedIndex = 0;
            comboBoxLinea.SelectedIndex = 0;
            comboBoxClase.SelectedIndex = 0;
            comboBoxRestaurante.SelectedIndex = 0;
            comboBoxMarca.SelectedIndex = 0;
            codigo();
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxCantidad.Text) || comboBoxClase.SelectedIndex == -1 || comboBoxLinea.SelectedIndex == -1 || comboBoxMarca.SelectedIndex == -1 || comboBoxMedida.SelectedIndex == -1 || comboBoxRestaurante.SelectedIndex == -1 || comboBoxTipo.SelectedIndex == -1)
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en el campo: \n   Nombre  o Cantidad esta vacia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cLogica_BD.cantidad = textBoxCantidad.Text;
                cLogica_BD.tipo = comboBoxTipo.SelectedItem.ToString();
                cLogica_BD.restaurante = comboBoxRestaurante.SelectedItem.ToString();
                cLogica_BD.marca = comboBoxMarca.SelectedItem.ToString();
                cLogica_BD.clase = comboBoxClase.SelectedItem.ToString();
                cLogica_BD.linea = comboBoxLinea.SelectedItem.ToString();
                cLogica_BD.medida = comboBoxMedida.SelectedItem.ToString();


                if (cLogica_BD.agregar_Comestibles() == true)
                {
                    Bitacora("Se agrego un Comestible", "Se agrego un Comestible");
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
            string[] valores = clogiga.CodigoTabla("CodigoComestible", "Comestibles");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];
        }


        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void cargarComboMarca()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select NombreMarca from Marcas").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {
                
                comboBoxMarca.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
            comboBoxMarca.SelectedIndex = 0;
        }

        private void cargarComboRestaurante()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select NombreRestaurante from Restaurante").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {

                comboBoxRestaurante.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
            comboBoxRestaurante.SelectedIndex = 0;
        }

        private void cargarComboUnidades()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select UnidadMedida from UnidadesMedida").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {

                comboBoxMedida.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
            comboBoxMedida.SelectedIndex = 0;



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
