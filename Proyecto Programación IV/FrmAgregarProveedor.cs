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
using System.Collections;


namespace Proyecto_Programación_IV
{
    public partial class FrmAgregarProveedor : Form
    {
     
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarProveedor()
        {
            InitializeComponent();
            dateTimePickerFechaIngreso.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaIngreso.CustomFormat = "dd-MM-yyyy";
            codigo();
            cargarListBox();
            
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
            codigo();
        }

        private Boolean validar()
        {
            if (!maskedTextBoxCedula.MaskFull || !Regex.IsMatch(textBoxNombreProveedor.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(textBoxPrimerApellido.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(textBoxSegundoApellido.Text, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(textBoxCorreo.Text) || string.IsNullOrEmpty(textBoxDireccion.Text) || !maskedTextBoxOficina.MaskFull || !maskedTextBoxTelFAX.MaskFull || !maskedTextBoxCelular.MaskFull || pictureBox2.Image == null || string.IsNullOrEmpty(textBoxNombreContacto.Text) || !maskedTextBoxTelefonoInformacionContacto.MaskFull || string.IsNullOrEmpty(textBoxDireccionInformacionContacto.Text)) 
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
                cLogica_BD.cedula = maskedTextBoxCedula.Text;
                cLogica_BD.fecha = dateTimePickerFechaIngreso.Text;
                cLogica_BD.nombre = textBoxNombreProveedor.Text;
                cLogica_BD.apellido1 = textBoxPrimerApellido.Text;
                cLogica_BD.apellido2 = textBoxSegundoApellido.Text;
                cLogica_BD.correo = textBoxCorreo.Text;
                cLogica_BD.direccion = textBoxDireccion.Text;
                cLogica_BD.celular = maskedTextBoxCelular.Text;
                cLogica_BD.fax = maskedTextBoxTelFAX.Text;
                cLogica_BD.telOficina = maskedTextBoxOficina.Text;
                cLogica_BD.foto = imageToByteArray(pictureBox2.Image);

                cLogica_BD.nombreContacto = textBoxNombreContacto.Text;
                cLogica_BD.telefono = maskedTextBoxTelefonoInformacionContacto.Text;
                cLogica_BD.direccion2 = textBoxDireccionInformacionContacto.Text;

                if (cLogica_BD.agregar_Proveedor() == true)
                {
                    Bitacora("Se agrego un Proveedor", "Se agrego un Proveedor");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo();
                    if (listBoxProveedor.Items.Count > 0)
                    {
                        //this
                        asignarProductosProveedor();
                    }
                
                    
             
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
            string[] valores = clogiga.CodigoTabla("CodigoProveedor", "Proveedores");
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

        private void cargarListBox()
        {
            int i = 0;
            string nombre = "NombreComestible";
            string tabla = "Comestibles";
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            while (i <= 4)
            {
                dt = bd.SelectDataTable("select " + nombre + " from " + tabla + " ").Copy();

                foreach (DataRow row in dt.Rows)
                {

                    listBoxRestaurante.Items.Add(clogiga.desencriptacion(row[0].ToString()));

                }
                i++;
                if (i == 1) 
                { 
                    nombre = "NombreTecnologia";
                    tabla = "Tecnologias"; 
                }
                if (i == 2) 
                { nombre = "NombreDesechable"; 
                    tabla = "Desechables";
                }
                if (i == 3)
                { nombre = "NombreUtencilios"; 
                    tabla = "Utencilios";
                }
                if (i == 4) 
                { nombre = "NombreLimpieza"; 
                    tabla = "Limpieza"; 
                }
                
            }
            
        }

        private void buttonProveedor_Click(object sender, EventArgs e)
        {
            moverAProveedor();
        }

        private void moverAProveedor()
        {
            try
            {
                ArrayList list = new ArrayList();
                string itemSelect = listBoxRestaurante.SelectedItem.ToString();

                foreach (var item in listBoxRestaurante.Items)
                {
                    string text = item.ToString();
                    if (itemSelect.Equals(text))
                    {
                        list.Add(text);
                    }


                }
                for (int x = 0; x < list.Count; x++)
                {
                    listBoxProveedor.Items.Add(list[x]);
                    listBoxRestaurante.Items.Remove(list[x]);
                }

            }
            catch (Exception)
            {
                CustomMessageBox.ShowMessage("Debe Seleccionar un item de la lista", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void buttonRestaurante_Click(object sender, EventArgs e)
        {
            moverARestaurante(); 
        }

        private void moverARestaurante()
        {
            try
            {
                ArrayList list = new ArrayList();
                string itemSelect = listBoxProveedor.SelectedItem.ToString();

                foreach (var item in listBoxProveedor.Items)
                {
                    string text = item.ToString();
                    if (itemSelect.Equals(text))
                    {
                        list.Add(text);
                    }

                }
                for (int x = 0; x < list.Count; x++)
                {
                    listBoxRestaurante.Items.Add(list[x]);
                    listBoxProveedor.Items.Remove(list[x]);
                }
            }
            catch (Exception)
            {
                CustomMessageBox.ShowMessage("Debe Seleccionar un item de la lista", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void asignarProductosProveedor()
        {

            Querys clogiga = new Querys();
                ArrayList list = new ArrayList();
    

                foreach (var item in listBoxProveedor.Items)
                {
                    string text = item.ToString();
                    if (clogiga.ProductosProveedor(text, codigoValor) == true)
                    {
                        //CustomMessageBox.ShowMessage("Producto asignados al Proveedor correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("No se ha podido asignar los productos al Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
