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
    public partial class FrmAgregarVinos : Form
    {
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarVinos()
        {
            InitializeComponent();
            codigo();
            cargarComboMarca();
            cargarComboNacionalidad();
   
            
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
            comboBoxMarca.SelectedIndex = 0;
            comboBoxNacionalidad.SelectedIndex = 0;
            textBoxRestaurante.Text = rols[3];
            codigo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregar();
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            comboBoxMarca.SelectedIndex = 0;
            comboBoxNacionalidad.SelectedIndex = 0;
            textBoxRestaurante.Text = rols[3];
            codigo();
        }

        private Boolean validar()
        {

            if (string.IsNullOrEmpty(textBoxNombre.Text) || pictureBox2.Image == null || string.IsNullOrEmpty(textBoxRestaurante.Text) || string.IsNullOrEmpty(textBoxCantidad.Text) || string.IsNullOrEmpty(textBoxDescripcion.Text) || string.IsNullOrEmpty(textBoxBotella.Text) || string.IsNullOrEmpty(textBoxUnitario.Text))
                    {
                        CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en el campo: \n   Nombre, Restaurante..  o Precio esta vacia. \n• No ha cargado la fotografia", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cLogica_BD.marca = comboBoxMarca.SelectedItem.ToString();
                    cLogica_BD.nacionalidad = comboBoxNacionalidad.SelectedItem.ToString();
                    cLogica_BD.precio = Convert.ToInt32(textBoxUnitario.Text);
                    cLogica_BD.precio2 = Convert.ToInt32(textBoxBotella.Text);
                    cLogica_BD.restaurante = textBoxRestaurante.Text;
                    cLogica_BD.cantidad = textBoxCantidad.Text;
                    cLogica_BD.descripcion = textBoxDescripcion.Text;
                    cLogica_BD.foto = imageToByteArray(pictureBox2.Image);
                    cLogica_BD.year = textBoxCosecha.Text;
               


   

               if (cLogica_BD.agregar_Vinos() == true)
                {
                    Bitacora("Se agrego un Vino", "Se agrego un Vino");
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
            string[] valores = clogiga.CodigoTabla("CodigoVino", "Vinos");
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

        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cargarComboNacionalidad()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select NombrePais from Paises").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {
                
                comboBoxNacionalidad.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
            comboBoxNacionalidad.SelectedIndex = 0;
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

        public void privilegios(string[] cadena)
        {
            rols[0] = cadena[0];
            rols[1] = cadena[1];
            rols[2] = cadena[2];
            rols[3] = cadena[3];
            rols[4] = cadena[4];
            rols[5] = cadena[5];
            textBoxRestaurante.Text = rols[3];
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
