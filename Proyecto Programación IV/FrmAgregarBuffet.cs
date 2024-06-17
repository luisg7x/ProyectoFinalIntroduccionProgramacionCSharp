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
    public partial class FrmAgregarBuffet : Form
    {
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarBuffet()
        {
            InitializeComponent();
            codigo();
            cargarComboUnidades();
            comboBoxTipo.SelectedIndex = 0;

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
            comboBoxMedida.SelectedIndex = 0;
            comboBoxTipo.SelectedIndex = 0;
            codigo();
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxPrecio.Text) || pictureBox2.Image == null)
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en el campo: \n   Nombre  o Precio esta vacia. \n• No ha cargado la fotografia", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        //imagen a array
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        //array a imagen :*
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        private void agregar()
        {

            if (validar() == false)
            {
                Querys cLogica_BD = new Querys();
                cLogica_BD.codigoValor = codigoValor;
                cLogica_BD.nombre = textBoxNombre.Text;
                cLogica_BD.precio = Convert.ToInt32(textBoxPrecio.Text);
                cLogica_BD.tipo = comboBoxTipo.SelectedItem.ToString();
                cLogica_BD.medida = comboBoxMedida.SelectedItem.ToString();
                cLogica_BD.foto = imageToByteArray(pictureBox2.Image);

                if (cLogica_BD.agregar_Buffed() == true)
                {

                    Bitacora("Se agrego un Buffet", "Se agrego un Buffet");
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
            string[] valores = clogiga.CodigoTabla("CodigoBuffet", "Buffet");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];
        }

        private void buttonSlectFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
