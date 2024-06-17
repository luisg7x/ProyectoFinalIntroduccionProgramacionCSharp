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
using System.Globalization;


namespace Proyecto_Programación_IV
{
    
    public partial class FrmAgregarClientes : Form
    {
       
        string[] rols = new string[6];
        int horas = 00;
        int minutos = 00;
        int segundos = 00;
        int milesimas = 00;
        public int edicionValor = 0;
        string detalles = string.Empty;
        string codigoValor = string.Empty;
        public FrmAgregarClientes()
        {
            InitializeComponent();
            dateTimePickerFechaReservacion.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaReservacion.CustomFormat = "dd-MM-yyyy";
            comboBoxNombreMesa.SelectedIndex = 0;
            buttonImprimir.Enabled = false;
            
            comboBoxSilla1.Enabled = false;
            comboBoxSilla2.Enabled = false;
            comboBoxSilla3.Enabled = false;
            comboBoxSilla4.Enabled = false;

            checkBoxBuffet1.Enabled = false;
            checkBoxBuffet2.Enabled = false;
            checkBoxBuffet3.Enabled = false;
            checkBoxBuffet4.Enabled = false;

            listBoxSilla1.Enabled = false;
            listBoxSilla2.Enabled = false;
            listBoxSilla3.Enabled = false;
            listBoxSilla4.Enabled = false;

            buttonActualizar.Enabled = false;
            edicion(edicionValor);
           
        }

       private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            comboBoxSilla1.SelectedIndex = -1;
            comboBoxSilla2.SelectedIndex = -1;
            comboBoxSilla3.SelectedIndex = -1;
            comboBoxSilla4.SelectedIndex = -1;
            listBoxSilla1.Items.Clear();
            listBoxSilla2.Items.Clear();
            listBoxSilla3.Items.Clear();
            listBoxSilla4.Items.Clear();
            checkBoxBuffet1.Checked = false;
            checkBoxBuffet2.Checked = false;
            checkBoxBuffet3.Checked = false;
            checkBoxBuffet4.Checked = false;
            checkBox1.Checked = false;
            precio();
            
            
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            FrmPiccolaStella frm = new FrmPiccolaStella();
            Agregar();
            frm.iniciarMesasOcupada();
            codigo();
        }

        private Boolean validar()
        {
           if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en el campo: \n   Nombre, Ingredientes..  o Precio esta vacia. \n• No ha cargado la fotografia", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
          
        }


        private void codigo()
        {
            Querys clogiga = new Querys();
            string[] valores = clogiga.CodigoTabla("CodigoCliente", "Clientes");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];
        }



        private void marcarHora()
        {
            maskedTextBoxHoraEntrada.Text = DateTime.Now.ToString("HH:mm");
       
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;


            int milesima, segundo, minuto, hora;

            milesima = Convert.ToInt32(milesimas);

            milesima += 1;

            milesimas = milesima;

            if (milesima == 60)
            {

                segundo = Convert.ToInt32(segundos);

                segundo += 1;

                segundos = segundo;

             //   maskedTextBoxDuracionMesa.Text = horas.ToString("{0:00}") + ":" + minutos.ToString("{0:00}") + ":" + segundos.ToString("{0:00}");
                maskedTextBoxDuracionMesa.Text = String.Format("{0:00}", horas) + ":" + String.Format("{0:00}", minutos) + ":" + String.Format("{0:00}", segundo);
              
                milesimas = 00;
                
                if (segundo == 60)
                {

                    minuto = Convert.ToInt32(minutos);

                    minuto += 1;

                    minutos = minuto;
                   // maskedTextBoxDuracionMesa.Text = (hora + minuto + segundo).ToString("##:##:##");
                    
                    segundos = 00;

                    if (minuto == 60)
                    {

                        hora = Convert.ToInt32(horas);

                        hora += 1;
              
                        horas = hora;
                    
                        minutos = 00;

                    }
                }
               

            }           
        }

        public void numMesa(int mesa)
        {
            textBoxnumeroMesa.Text = mesa.ToString();
        }

        DataTable dt = new DataTable();
        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            maskedTextBoxHoraSalida.Text = DateTime.Now.ToString("HH:mm");
            timer1.Stop();


            if (factura() == false)
            {
                CustomMessageBox.ShowMessage("No se han podido crear la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxestadoCuenta.Text = "PAGADO";

            Querys cLogica_BD = new Querys();

            string[] valores = cLogica_BD.CodigoTabla("CodigoFactura", "Facturas");

            string codigo = valores[2];
            string codigoSolo = (int.Parse(valores[0]) - 1).ToString();

            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            BaseDeDatos bd = new BaseDeDatos();
            bd.executecommand("update Clientes set EstadoPago='" + cLogica_BD.encriptacion(textBoxestadoCuenta.Text) + "'WHERE CodigoCliente='" + cLogica_BD.encriptacion(codigoSolo) + "'");
            
            DataSet ds = new DataSet();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Numero_Factura", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("FechaFactura", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Restaurante", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("NombreCliente", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Detalles", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("DuracionMesa", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("HoraEntrada_HoraSalida", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("MontoFactura", Type.GetType("System.String")));
            fillRows(codigo, fecha, textBoxRestaurante.Text, textBoxNombre.Text, detalles, maskedTextBoxDuracionMesa.Text, maskedTextBoxHoraEntrada.Text + " a " + maskedTextBoxHoraSalida.Text, textBoxMontoPago.Text);
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "Factura";
            ds.WriteXml("Factura.xml");

            buttonImprimir.Enabled = false;
            buttonImprimir.FlatAppearance.BorderColor = Color.Red;
            Bitacora("Facturo a Cliente al Restaurante Piccola Stella (Mesa)", "Facturo a Cliente al Restaurante Piccola Stella");
            MessageBox.Show("Done");
        }

        private void fillRows(string pID, string fecha, string pRestaurant, string nombre, string detalles, string duracion, string entradaSalida, string monto)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["Numero_Factura"] = pID;
            dr["FechaFactura"] = fecha;
            dr["Restaurante"] = pRestaurant;
            dr["NombreCliente"] = nombre;
            dr["Detalles"] = detalles;
            dr["DuracionMesa"] = duracion;
            dr["HoraEntrada_HoraSalida"] = entradaSalida;
            dr["MontoFactura"] = monto;
            dt.Rows.Add(dr);
        }

        private Boolean factura()
        {

            BaseDeDatos bd = new BaseDeDatos();
            Querys cLogica_BD = new Querys();

            cLogica_BD.nombre = textBoxNombre.Text;
            cLogica_BD.fecha = DateTime.Now.ToString("dd-MM-yyyy");
            cLogica_BD.restaurante = textBoxRestaurante.Text;
            cLogica_BD.entrada = maskedTextBoxHoraEntrada.Text;
            cLogica_BD.salida = maskedTextBoxHoraSalida.Text;
            cLogica_BD.monto = textBoxMontoPago.Text;
            cLogica_BD.detalle = detalles;
            cLogica_BD.tiempo = maskedTextBoxDuracionMesa.Text;

            if (cLogica_BD.agregar_Factura() == true)
            {
                CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            textBoxRestaurante.Text = rols[3];
        }

        public void sillas(int silla)
        {
            if (silla == 2)
            {
                comboBoxSilla1.Enabled = true;
                comboBoxSilla2.Enabled = true;
                checkBoxBuffet1.Enabled = true;
                checkBoxBuffet2.Enabled = true;

            }
            else if (silla == 4)
            {
                comboBoxSilla1.Enabled = true;
                comboBoxSilla2.Enabled = true;
                comboBoxSilla3.Enabled = true;
                comboBoxSilla4.Enabled = true;

                checkBoxBuffet1.Enabled = true;
                checkBoxBuffet2.Enabled = true;
                checkBoxBuffet3.Enabled = true;
                checkBoxBuffet4.Enabled = true;
            }
        }

        private void cargarComboEspecial()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select NombrePlatilloEspecial from Especiales ").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {
                
                comboBoxSilla1.Items.Add(clogiga.desencriptacion(row[0].ToString()));
                comboBoxSilla2.Items.Add(clogiga.desencriptacion(row[0].ToString()));
                comboBoxSilla3.Items.Add(clogiga.desencriptacion(row[0].ToString()));
                comboBoxSilla4.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
          /*  comboBoxSilla1.SelectedIndex = 0;
            comboBoxSilla2.SelectedIndex = 0;
            comboBoxSilla3.SelectedIndex = 0;
            comboBoxSilla4.SelectedIndex = 0;*/
        }

        private void precio()
        {
            Querys clogiga = new Querys();
            BaseDeDatos bd = new BaseDeDatos();
            

            if (comboBoxSilla1.SelectedIndex != -1)
            {
                string silla1 = comboBoxSilla1.SelectedItem.ToString();

                string precio = bd.selectstring("select PrecioEspecial from Especiales where NombrePlatilloEspecial = '" + clogiga.encriptacion(silla1) + "'");
                textBoxPrecioSilla1.Text = clogiga.desencriptacion(precio);
      

            }
            else
            {
                textBoxPrecioSilla1.Text = "0";
            }
            if (comboBoxSilla2.SelectedIndex != -1)
            {
                string silla2 = comboBoxSilla2.SelectedItem.ToString();

                string precio = bd.selectstring("select PrecioEspecial from Especiales where NombrePlatilloEspecial = '" + clogiga.encriptacion(silla2) + "'");
                textBoxPrecioSilla2.Text = clogiga.desencriptacion(precio);
               

            }
            else
            {
                textBoxPrecioSilla2.Text = "0";
            }
            if (comboBoxSilla3.SelectedIndex != -1)
            {
                string silla3 = comboBoxSilla3.SelectedItem.ToString();

                string precio = bd.selectstring("select PrecioEspecial from Especiales where NombrePlatilloEspecial = '" + clogiga.encriptacion(silla3) + "'");
                textBoxPrecioSilla3.Text = clogiga.desencriptacion(precio);
           

            }
            else
            {
                textBoxPrecioSilla3.Text = "0";
            }
            if (comboBoxSilla4.SelectedIndex != -1)
            {
                string silla4 = comboBoxSilla1.SelectedItem.ToString();

                string precio = bd.selectstring("select PrecioEspecial from Especiales where NombrePlatilloEspecial = '" + clogiga.encriptacion(silla4) + "'");
                textBoxPrecioSilla4.Text = clogiga.desencriptacion(precio);
  

            }
            else
            {
                textBoxPrecioSilla4.Text = "0";
            }
            MontoPago();
        }

        private void comboBoxSilla1_SelectedIndexChanged(object sender, EventArgs e)
        {
            precio();
        }

        private void checkBoxBuffet1_CheckedChanged(object sender, EventArgs e)
        {

            BaseDeDatos bd = new BaseDeDatos();
            DataTable buffet = new DataTable();
            Querys clogiga = new Querys();
            //LENA LA TABLA DT CON LOS DATOS
            buffet = bd.SelectDataTable("select NombreBuffet,PrecioBuffet from Buffet").Copy();

            if (checkBoxBuffet1.Checked)
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla1.Enabled = true;
                foreach (DataRow row in buffet.Rows)
                {

                    listBoxSilla1.Items.Add(clogiga.desencriptacion(row[0].ToString()));

                }

            }
            if (!checkBoxBuffet1.Checked)
            {
                listBoxSilla1.Enabled = false;
                listBoxSilla1.Items.Clear();
                textBoxTotalBuffetSilla1.Clear();
            }
            if (!checkBoxBuffet1.Checked && !checkBoxBuffet2.Checked && !checkBoxBuffet3.Checked && !checkBoxBuffet4.Checked)
            {
                this.Height = 600;
                ButtonCerrar.Location = new Point(1075, 547);
                panel1.Height = 487;
                listBoxSilla1.Enabled = false;
                listBoxSilla2.Enabled = false;
                listBoxSilla3.Enabled = false;
                listBoxSilla4.Enabled = false;

                textBoxTotalBuffetSilla1.Text = "0";
                textBoxTotalBuffetSilla2.Text = "0";
                textBoxTotalBuffetSilla3.Text = "0";
                textBoxTotalBuffetSilla4.Text = "0";

            }
                 
        }

        private void checkBoxBuffet2_CheckedChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable buffet = new DataTable();
            Querys clogiga = new Querys();
            //LENA LA TABLA DT CON LOS DATOS
            buffet = bd.SelectDataTable("select  NombreBuffet,PrecioBuffet from Buffet").Copy();

            if (checkBoxBuffet2.Checked)
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla2.Enabled = true;
                foreach (DataRow row in buffet.Rows)
                {

                    listBoxSilla2.Items.Add(clogiga.desencriptacion(row[0].ToString()));

                }
            }
            if (!checkBoxBuffet2.Checked)
            {
                listBoxSilla2.Enabled = false;
                listBoxSilla2.Items.Clear();
                textBoxTotalBuffetSilla2.Clear();
            }
            if (!checkBoxBuffet1.Checked && !checkBoxBuffet2.Checked && !checkBoxBuffet3.Checked && !checkBoxBuffet4.Checked)
            {
                this.Height = 600;
                ButtonCerrar.Location = new Point(1075, 547);
                panel1.Height = 487;
                listBoxSilla1.Enabled = false;
                listBoxSilla2.Enabled = false;
                listBoxSilla3.Enabled = false;
                listBoxSilla4.Enabled = false;

                textBoxTotalBuffetSilla1.Text = "0";
                textBoxTotalBuffetSilla2.Text = "0";
                textBoxTotalBuffetSilla3.Text = "0";
                textBoxTotalBuffetSilla4.Text = "0";
            }

         }

        private void checkBoxBuffet3_CheckedChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable buffet = new DataTable();
            Querys clogiga = new Querys();
            //LENA LA TABLA DT CON LOS DATOS
            buffet = bd.SelectDataTable("select  NombreBuffet,PrecioBuffet from Buffet").Copy();

            if (checkBoxBuffet3.Checked)
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla3.Enabled = true;
                foreach (DataRow row in buffet.Rows)
                {

                    listBoxSilla3.Items.Add(clogiga.desencriptacion(row[0].ToString()));

                }
            }
            if (!checkBoxBuffet3.Checked)
            {
                listBoxSilla3.Enabled = false;
                listBoxSilla3.Items.Clear();
                textBoxTotalBuffetSilla3.Clear();
            }
            if (!checkBoxBuffet1.Checked && !checkBoxBuffet2.Checked && !checkBoxBuffet3.Checked && !checkBoxBuffet4.Checked)
            {
                this.Height = 600;
                ButtonCerrar.Location = new Point(1075, 547);
                panel1.Height = 487;
                listBoxSilla1.Enabled = false;
                listBoxSilla2.Enabled = false;
                listBoxSilla3.Enabled = false;
                listBoxSilla4.Enabled = false;

                textBoxTotalBuffetSilla1.Text = "0";
                textBoxTotalBuffetSilla2.Text = "0";
                textBoxTotalBuffetSilla3.Text = "0";
                textBoxTotalBuffetSilla4.Text = "0";

            }
        }

        private void checkBoxBuffet4_CheckedChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable buffet = new DataTable();
            Querys clogiga = new Querys();
            //LENA LA TABLA DT CON LOS DATOS
            buffet = bd.SelectDataTable("select  NombreBuffet,PrecioBuffet from Buffet").Copy();

            if (checkBoxBuffet4.Checked)
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla4.Enabled = true;
                foreach (DataRow row in buffet.Rows)
                {

                    listBoxSilla4.Items.Add(clogiga.desencriptacion(row[0].ToString()));

                }
            }
            if (!checkBoxBuffet4.Checked)
            {
                listBoxSilla4.Enabled = false;
                listBoxSilla4.Items.Clear();
                textBoxTotalBuffetSilla4.Clear();
            }
            if (!checkBoxBuffet1.Checked && !checkBoxBuffet2.Checked && !checkBoxBuffet3.Checked && !checkBoxBuffet4.Checked)
            {
                this.Height = 600;
                ButtonCerrar.Location = new Point(1075, 547);
                panel1.Height = 487;
                listBoxSilla1.Enabled = false;
                listBoxSilla2.Enabled = false;
                listBoxSilla3.Enabled = false;
                listBoxSilla4.Enabled = false;

                textBoxTotalBuffetSilla1.Text = "0";
                textBoxTotalBuffetSilla2.Text = "0";
                textBoxTotalBuffetSilla3.Text = "0";
                textBoxTotalBuffetSilla4.Text = "0";

            }
        }

        private void listBoxSilla1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            int precio = 0;
            textBoxTotalBuffetSilla1.Text = "0";
            foreach (string blah in listBoxSilla1.SelectedItems)
            {
                string precioEncriptado = bd.selectstring("select PrecioBuffet from Buffet where NombreBuffet = '" + clogiga.encriptacion(blah) + "'");
                string prec = clogiga.desencriptacion(precioEncriptado);
                precio = precio + int.Parse(prec);
                textBoxTotalBuffetSilla1.Text = precio.ToString();
              
            }
            MontoPago();
        }

        private void listBoxSilla2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            int precio = 0;
            textBoxTotalBuffetSilla2.Text = "0";
            foreach (string blah in listBoxSilla2.SelectedItems)
            {
                string precioEncriptado = bd.selectstring("select PrecioBuffet from Buffet where NombreBuffet = '" + clogiga.encriptacion(blah) + "'");
                string prec = clogiga.desencriptacion(precioEncriptado);
                precio = precio + int.Parse(prec);
                textBoxTotalBuffetSilla2.Text = precio.ToString();

            }
            MontoPago();
        }

        private void listBoxSilla3_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            int precio = 0;
            textBoxTotalBuffetSilla3.Text = "0";
            foreach (string blah in listBoxSilla3.SelectedItems)
            {
                string precioEncriptado = bd.selectstring("select PrecioBuffet from Buffet where NombreBuffet = '" + clogiga.encriptacion(blah) + "'");
                string prec = clogiga.desencriptacion(precioEncriptado);
                precio = precio + int.Parse(prec);
                textBoxTotalBuffetSilla3.Text = precio.ToString();

            }
            MontoPago();
        }

        private void listBoxSilla4_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            int precio = 0;
            textBoxTotalBuffetSilla4.Text = "0";
            foreach (string blah in listBoxSilla4.SelectedItems)
            {
                string precioEncriptado = bd.selectstring("select PrecioBuffet from Buffet where NombreBuffet = '" + clogiga.encriptacion(blah) + "'");
                string prec = clogiga.desencriptacion(precioEncriptado);
                precio = precio + int.Parse(prec);
                textBoxTotalBuffetSilla4.Text = precio.ToString();

            }
            MontoPago();
        }

        private void MontoPago()
        {
            int total = int.Parse(textBoxPrecioSilla1.Text) + int.Parse(textBoxPrecioSilla2.Text) + int.Parse(textBoxPrecioSilla3.Text) + int.Parse(textBoxPrecioSilla4.Text) + int.Parse(textBoxTotalBuffetSilla1.Text) + int.Parse(textBoxTotalBuffetSilla2.Text) + int.Parse(textBoxTotalBuffetSilla3.Text) + int.Parse(textBoxTotalBuffetSilla4.Text);
            textBoxMontoPago.Text = total.ToString();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxnumeroMesa.ForeColor = Color.Red;
            }
            else
            {
                textBoxnumeroMesa.ForeColor = Color.Black;
            }
        }

        private void Agregar()
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
          
            ArrayList lista = new ArrayList();

            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();

            if (validar() == false)
            {
                clogiga.nombre = textBoxNombre.Text;
                clogiga.monto = textBoxMontoPago.Text;


                if (comboBoxSilla1.SelectedIndex != -1)
                {
                    string silla1 = comboBoxSilla1.SelectedItem.ToString();
                    lista.Add(silla1);
                    clogiga.silla1 = silla1;
                }
                if (comboBoxSilla2.SelectedIndex != -1)
                {
                    string silla2 = comboBoxSilla2.SelectedItem.ToString();
                    lista.Add(silla2);
                    clogiga.silla2 = silla2;
                }
                if (comboBoxSilla3.SelectedIndex != -1)
                {
                    string silla3 = comboBoxSilla3.SelectedItem.ToString();
                    lista.Add(silla3);
                    clogiga.silla3 = silla3;

                }
                if (comboBoxSilla4.SelectedIndex != -1)
                {
                    string silla4 = comboBoxSilla1.SelectedItem.ToString();
                    lista.Add(silla4);
                    clogiga.silla4 = silla4;
                }
                foreach (string blah in listBoxSilla1.SelectedItems)
                {
                    lista.Add(blah);
                    list1.Add(blah);
                }
                foreach (string blah in listBoxSilla2.SelectedItems)
                {
                    lista.Add(blah);
                    list2.Add(blah);
                }
                foreach (string blah in listBoxSilla3.SelectedItems)
                {
                    lista.Add(blah);
                    list3.Add(blah);
                }
                foreach (string blah in listBoxSilla4.SelectedItems)
                {
                    lista.Add(blah);
                    list4.Add(blah);
                }

                clogiga.fecha = DateTime.Now.ToShortDateString();

                if (checkBox1.Checked)
                {
                    clogiga.reservacion = "SI";
                    if (maskedTextBoxFechaLlegada.MaskCompleted)
                    {
                        clogiga.fechaReservacion = maskedTextBoxFechaLlegada.Text;
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("Debe agregar una fecha de Reservacion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    clogiga.reservacion = "NO";
                }
                clogiga.codigoValor = codigoValor;
                clogiga.fecha = DateTime.Now.ToString("dd-MM-yyyy");
                clogiga.restaurante = textBoxRestaurante.Text;
                clogiga.numMesa = textBoxnumeroMesa.Text;
                clogiga.tiempo = maskedTextBoxDuracionMesa.Text;
                clogiga.entrada = maskedTextBoxHoraEntrada.Text;
                clogiga.salida = maskedTextBoxHoraSalida.Text;
                clogiga.estado = textBoxestadoCuenta.Text;
                clogiga.numSilla = string.Empty;
                //string result = string.Join(" | ", lista.ToArray());
                // MessageBox.Show(fecha);
                if (clogiga.agregar_clientes(lista, list1, list2, list3, list4) == true)
                {
                    Bitacora("Agrego Cliente al Restaurante Piccola Stella (Mesa)", "Agrego Cliente al Restaurante Piccola Stella");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo();
                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        public void cargarCliente(string lista, string lista1, string lista2, string lista3, string lista4, string nombre, string monto, string fecha, string reservacion, string tiempoMesa, string numMesa, string pedidoSilla1, string pedidoSilla2, string pedidoSilla3, string pedidoSilla4, string id, string entrada,string estado, string fechareservacion)
        {
            Querys clogiga = new Querys();
            if (clogiga.desencriptacion(estado).Equals("SIN PAGAR")) {
                textBoxestadoCuenta.Text = "SIN PAGAR";
                buttonImprimir.Enabled = true;
                buttonImprimir.FlatAppearance.BorderColor = Color.Green;
                //tiempo
                string tiempo = clogiga.desencriptacion(fecha) +" "+ clogiga.desencriptacion(entrada);
                string format = "dd-MM-yyyy HH:mm";
                DateTime d1 = DateTime.ParseExact(tiempo, format, CultureInfo.InvariantCulture);
                string TIEMPO2 = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                DateTime d2 = DateTime.ParseExact(TIEMPO2, format, CultureInfo.InvariantCulture);

                string HORAS = (d2 - d1).Hours.ToString();
                string MINUTOS = (d2 - d1).Minutes.ToString();
                horas = int.Parse(HORAS);
                minutos = int.Parse(MINUTOS);
                buttonAgregar.Enabled = false;
                buttonActualizar.Enabled = true;
            }
            else
            {
                maskedTextBoxDuracionMesa.Text = clogiga.desencriptacion(tiempoMesa);
                textBoxestadoCuenta.Text = "PAGADO";
                //tiempo en mesa
                string hora = maskedTextBoxDuracionMesa.Text.Substring(0, 2);
                string mins = maskedTextBoxDuracionMesa.Text.Substring(3, 2);
                string seg = maskedTextBoxDuracionMesa.Text.Substring(6, 2);

                horas = int.Parse(hora);
                segundos = int.Parse(seg);
                minutos = int.Parse(mins);
                timer1.Stop();
                buttonImprimir.Enabled = false;
                buttonActualizar.Enabled = false;
            }

            detalles = clogiga.desencriptacion(lista);
            int mesa = int.Parse(clogiga.desencriptacion(numMesa));
            if (mesa == 1 || mesa == 2 || mesa == 3 || mesa == 4 || mesa == 10 || mesa == 22 || mesa == 23)
            {
                comboBoxSilla1.Enabled = true;
                comboBoxSilla2.Enabled = true;
                checkBoxBuffet1.Enabled = true;
                checkBoxBuffet2.Enabled = true;
            }
            else
            {
                comboBoxSilla1.Enabled = true;
                comboBoxSilla2.Enabled = true;
                comboBoxSilla3.Enabled = true;
                comboBoxSilla4.Enabled = true;
                checkBoxBuffet1.Enabled = true;
                checkBoxBuffet2.Enabled = true;
                checkBoxBuffet3.Enabled = true;
                checkBoxBuffet4.Enabled = true;
            }
            textBoxCodigo.Text = id;
            textBoxNombre.Text = clogiga.desencriptacion(nombre);
            textBoxMontoPago.Text = clogiga.desencriptacion(monto);
            maskedTextBoxHoraEntrada.Text = clogiga.desencriptacion(entrada);
            
            //
            textBoxnumeroMesa.Text = clogiga.desencriptacion(numMesa);
            precio();
            //pedidos sillas
            if (!string.IsNullOrEmpty(pedidoSilla1))
            {
                comboBoxSilla1.Enabled = true;
                comboBoxSilla1.SelectedIndex = comboBoxSilla1.Items.IndexOf(clogiga.desencriptacion(pedidoSilla1));
            }
            if (!string.IsNullOrEmpty(pedidoSilla2))
            {
                comboBoxSilla2.Enabled = true;
                comboBoxSilla2.SelectedIndex = comboBoxSilla2.Items.IndexOf(clogiga.desencriptacion(pedidoSilla2));
            }
            if (!string.IsNullOrEmpty(pedidoSilla3))
            {
                comboBoxSilla3.Enabled = true;
                comboBoxSilla3.SelectedIndex = comboBoxSilla3.Items.IndexOf(clogiga.desencriptacion(pedidoSilla3));
            }
            if (!string.IsNullOrEmpty(pedidoSilla4))
            {
                comboBoxSilla4.Enabled = true;
                comboBoxSilla4.SelectedIndex = comboBoxSilla4.Items.IndexOf(clogiga.desencriptacion(pedidoSilla4));
            }
            //pedidos listas
            //lista 1
            if (!string.IsNullOrEmpty(lista1))
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla1.Enabled = true;
                checkBoxBuffet1.Checked = true;
                string[] lines1 = Regex.Split(clogiga.desencriptacion(lista1), ",");
                foreach (string line in lines1)
                {
                    int index = listBoxSilla1.FindString(line);
                    // Determine if a valid index is returned. Select the item if it is valid.
                    if (index != -1)
                    {
       
                        listBoxSilla1.SetSelected(index, true);
                        checkBoxBuffet1.Enabled = true;
                    }
                }
          
            }
            //lista 2
            if (!string.IsNullOrEmpty(lista2))
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla2.Enabled = true;
                checkBoxBuffet2.Checked = true;
                string[] lines2 = Regex.Split(clogiga.desencriptacion(lista2), ",");
                foreach (string line in lines2)
                {
                    int index = listBoxSilla2.FindString(line);
                    // Determine if a valid index is returned. Select the item if it is valid.
                    if (index != -1)
                    {
                        
                        listBoxSilla2.SetSelected(index, true);
                        checkBoxBuffet2.Enabled = true;
                    }
                }
               
            }
            //lista 3
            if (!string.IsNullOrEmpty(lista3))
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla3.Enabled = true;
                checkBoxBuffet3.Checked = true;
                string[] lines3 = Regex.Split(clogiga.desencriptacion(lista3), ",");
                foreach (string line in lines3)
                {
                    int index = listBoxSilla3.FindString(line);
                    // Determine if a valid index is returned. Select the item if it is valid.
                    if (index != -1)
                    {
                        listBoxSilla3.SetSelected(index, true);
                        checkBoxBuffet3.Enabled = true;
                    }
                }
               
            }
            //lista 4
            if (!string.IsNullOrEmpty(lista4))
            {
                this.Height = 837;
                panel1.Height = 725;
                ButtonCerrar.Location = new Point(1075, 784);
                listBoxSilla4.Enabled = true;
                checkBoxBuffet4.Checked = true;
                string[] lines4 = Regex.Split(clogiga.desencriptacion(lista4), ",");
                foreach (string line in lines4)
                {
                    int index = listBoxSilla4.FindString(line);
                    // Determine if a valid index is returned. Select the item if it is valid.
                    if (index != -1)
                    {
                        listBoxSilla4.SetSelected(index, true);
                        checkBoxBuffet4.Enabled = true;
                    }
                }
                
            }
            //
            if (clogiga.desencriptacion(reservacion).Equals("SI"))
            {
                checkBox1.Checked = true;
                maskedTextBoxFechaLlegada.Text = clogiga.desencriptacion(fechareservacion);
            }



        }

        public void edicion(int i)
        {
            if (i == 0)
            {
                codigo();
                marcarHora();
                timer1.Start();
                cargarComboEspecial();
                this.Height = 600;
                ButtonCerrar.Location = new Point(1075, 547);
                panel1.Height = 487;
                textBoxestadoCuenta.Text = "SIN PAGAR";
            }
        }


        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            

            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();

            ArrayList lista = new ArrayList();

            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();

            if (validar() == false)
            {
                clogiga.nombre = textBoxNombre.Text;
                clogiga.monto = textBoxMontoPago.Text;
           

                if (comboBoxSilla1.SelectedIndex != -1)
                {
                    string silla1 = comboBoxSilla1.SelectedItem.ToString();
                    lista.Add(silla1);
                    clogiga.silla1 = silla1;
                }
                if (comboBoxSilla2.SelectedIndex != -1)
                {
                    string silla2 = comboBoxSilla2.SelectedItem.ToString();
                    lista.Add(silla2);
                    clogiga.silla2 = silla2;
                }
                if (comboBoxSilla3.SelectedIndex != -1)
                {
                    string silla3 = comboBoxSilla3.SelectedItem.ToString();
                    lista.Add(silla3);
                    clogiga.silla3 = silla3;

                }
                if (comboBoxSilla4.SelectedIndex != -1)
                {
                    string silla4 = comboBoxSilla1.SelectedItem.ToString();
                    lista.Add(silla4);
                    clogiga.silla4 = silla4;
                }
                foreach (string blah in listBoxSilla1.SelectedItems)
                {
                    lista.Add(blah);
                    list1.Add(blah);
                }
                foreach (string blah in listBoxSilla2.SelectedItems)
                {
                    lista.Add(blah);
                    list2.Add(blah);
                }
                foreach (string blah in listBoxSilla3.SelectedItems)
                {
                    lista.Add(blah);
                    list3.Add(blah);
                }
                foreach (string blah in listBoxSilla4.SelectedItems)
                {
                    lista.Add(blah);
                    list4.Add(blah);
                }

                clogiga.fecha = DateTime.Now.ToShortDateString();

                if (checkBox1.Checked)
                {
                    clogiga.reservacion = "SI";
                    if (maskedTextBoxFechaLlegada.MaskCompleted)
                    {
                        clogiga.fechaReservacion = maskedTextBoxFechaLlegada.Text;
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("Debe agregar una fecha de Reservacion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    clogiga.reservacion = "NO";
                  
                }

               // clogiga.fecha = DateTime.Now.ToString("dd-MM-yyyy");
                clogiga.restaurante = textBoxRestaurante.Text;
                clogiga.numMesa = textBoxnumeroMesa.Text;
                clogiga.tiempo = maskedTextBoxDuracionMesa.Text;
                clogiga.entrada = maskedTextBoxHoraEntrada.Text;
                clogiga.salida = maskedTextBoxHoraSalida.Text;
                clogiga.estado = textBoxestadoCuenta.Text;
                clogiga.numSilla = string.Empty;
                //string result = string.Join(" | ", lista.ToArray());
                // MessageBox.Show(fecha);
                if (clogiga.actualizar_clientes(lista, list1, list2, list3, list4, textBoxCodigo.Text) == true)
                {
                    Bitacora("Actualizar Cliente al Restaurante Piccola Stella (Mesa)", "Actualizo Cliente al Restaurante Piccola Stella");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo();
                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
