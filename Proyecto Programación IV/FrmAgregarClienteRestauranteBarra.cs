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
    public partial class FrmAgregarClienteRestauranteBarra : Form
    {
        string[] rols = new string[6];
        int horas = 00;
        int minutos = 00;
        int segundos = 00;
        int milesimas = 00;
        public int edicionValor = 0;
        string detalles = string.Empty;
        string codigoValor = string.Empty;
        public FrmAgregarClienteRestauranteBarra()
        {
            InitializeComponent();
            codigo();
            comboBoxNombreMesa.SelectedIndex = 0;

            buttonImprimir.Enabled = false;
            buttonActualizar.Enabled = false;
            edicion(edicionValor);
            cargarComboBuffe();
 
            
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

            limpiar();
        }

        private void limpiar()
        {
            textBoxNombre.Clear();
            textBoxNumeroSilla.Clear();
            comboBoxPedido.SelectedIndex = -1;
            listBoxPedidos.Items.Clear();
            textBoxMontoPago.Clear();
            textBoxPrecio.Clear();
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(comboBoxPedido.Text) || string.IsNullOrEmpty(textBoxNumeroSilla.Text) || int.Parse(textBoxNumeroSilla.Text) > 16 )
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en el campo: \n   Nombre, ..  o Precio esta vacia. \n• La silla es mayor al limite", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        

        private void textBoxNumeroSilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        //este
        public void numMesa(int mesa)
        {
            textBoxNumeroSilla.Text = mesa.ToString();
        }

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
            Bitacora("Facturo a Cliente al Restaurante Piccola Stella (Barra)", "Facturo a Cliente al Restaurante Piccola Stella");
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


        DataTable dt = new DataTable();
        private void cargarComboBuffe()
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select NombreBuffet from Buffet").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {

                comboBoxPedido.Items.Add(clogiga.desencriptacion(row[0].ToString()));
            }
            MontoPago();

        }

        private void MontoPago()
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            int total = 0;
            foreach (var item in listBoxPedidos.Items)
            {
                if (!string.IsNullOrEmpty(item.ToString()))
                {
                    string precio = clogiga.desencriptacion(bd.selectstring("select PrecioBuffet from Buffet where NombreBuffet = '"+clogiga.encriptacion(item.ToString())+"'"));
                    total += int.Parse(precio);
                }
            } 
            textBoxMontoPago.Text = total.ToString();
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
                listBoxPedidos.Items.Add(comboBoxPedido.SelectedItem.ToString());
                MontoPago();

                clogiga.nombre = textBoxNombre.Text;
                clogiga.monto = textBoxMontoPago.Text;

                foreach (var item in listBoxPedidos.Items)
                {
                    if (!string.IsNullOrEmpty(item.ToString()))
                    {
                        lista.Add(item.ToString());
                    }
                }

                if (int.Parse(textBoxNumeroSilla.Text) > 8)
                {
                    clogiga.barraCliente = "Bar Arriba";
                }
                else
                {
                    clogiga.barraCliente = "Bar Abajo";
                }
                clogiga.codigoValor = codigoValor;
                clogiga.fecha = DateTime.Now.ToShortDateString();
                clogiga.fecha = DateTime.Now.ToString("dd-MM-yyyy");
                clogiga.restaurante = textBoxRestaurante.Text;
                //clogiga.numMesa = textBoxnumeroMesa.Text;
                clogiga.tiempo = maskedTextBoxDuracionMesa.Text;
                clogiga.entrada = maskedTextBoxHoraEntrada.Text;
                clogiga.salida = maskedTextBoxHoraSalida.Text;
                clogiga.estado = textBoxestadoCuenta.Text;
                clogiga.numSilla = textBoxNumeroSilla.Text;
                //string result = string.Join(" | ", lista.ToArray());
                // MessageBox.Show(fecha);
                if (clogiga.agregar_clientes(lista, list1, list2, list3, list4) == true)
                {
                    Bitacora("Agrego Cliente al Restaurante Piccola Stella (Barra)", "Agrego Cliente al Restaurante Piccola Stella");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo();
                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        public void cargarCliente(string lista, string nombre, string monto, string fecha , string tiempoMesa, string numSilla,  string id, string entrada, string estado)
        {
            Querys clogiga = new Querys();
            if (clogiga.desencriptacion(estado).Equals("SIN PAGAR"))
            {
                textBoxestadoCuenta.Text = "SIN PAGAR";
                buttonImprimir.Enabled = true;
                buttonImprimir.FlatAppearance.BorderColor = Color.Green;
                //tiempo
                string tiempo = clogiga.desencriptacion(fecha) + " " + clogiga.desencriptacion(entrada);
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

            textBoxCodigo.Text = id;
            textBoxNombre.Text = clogiga.desencriptacion(nombre);
            textBoxMontoPago.Text = clogiga.desencriptacion(monto);
            maskedTextBoxHoraEntrada.Text = clogiga.desencriptacion(entrada);
            
            //
            textBoxNumeroSilla.Text = clogiga.desencriptacion(numSilla);
        
            //pedidos sillas
            detalles = clogiga.desencriptacion(lista);
            if (!string.IsNullOrEmpty(lista))
            {
                string[] lines1 = Regex.Split(clogiga.desencriptacion(lista), ",");
                foreach (string line in lines1)
                {
                    listBoxPedidos.Items.Add(line);
                }
            }
            MontoPago();
            



        }

        private void buttonAgregar_Click_1(object sender, EventArgs e)
        {
           
                
                Agregar();
                limpiar();
        
        }

        public void edicion(int i)
        {
            if (i == 0)
            {
                codigo();
                marcarHora();
                timer1.Start();
                textBoxestadoCuenta.Text = "SIN PAGAR";
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void actualizar()
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
                listBoxPedidos.Items.Add(comboBoxPedido.SelectedItem.ToString());
                MontoPago();
                clogiga.nombre = textBoxNombre.Text;
                clogiga.monto = textBoxMontoPago.Text;

                foreach (var item in listBoxPedidos.Items)
                {
                    if (!string.IsNullOrEmpty(item.ToString()))
                    {
                        lista.Add(item.ToString());
                    }
                }

                if (int.Parse(textBoxNumeroSilla.Text) > 8)
                {
                    clogiga.barraCliente = "Bar Arriba";
                }
                else
                {
                    clogiga.barraCliente = "Bar Abajo";
                }
                clogiga.fecha = DateTime.Now.ToShortDateString();
                clogiga.fecha = DateTime.Now.ToString("dd-MM-yyyy");
                clogiga.restaurante = textBoxRestaurante.Text;
                //clogiga.numMesa = textBoxnumeroMesa.Text;
                clogiga.tiempo = maskedTextBoxDuracionMesa.Text;
                clogiga.entrada = maskedTextBoxHoraEntrada.Text;
                clogiga.salida = maskedTextBoxHoraSalida.Text;
                clogiga.estado = textBoxestadoCuenta.Text;
                clogiga.numSilla = textBoxNumeroSilla.Text;
                //string result = string.Join(" | ", lista.ToArray());
                // MessageBox.Show(fecha);
                if (clogiga.actualizar_clientes(lista, list1, list2, list3, list4, textBoxCodigo.Text) == true)
                {
                    Bitacora("Actualizo Cliente del Restaurante Piccola Stella (Barra)", "Actualizo Cliente del Restaurante Piccola Stella");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void comboBoxPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            precio();
        }

        private void precio()
        {
            Querys clogiga = new Querys();
            BaseDeDatos bd = new BaseDeDatos();


            if (comboBoxPedido.SelectedIndex != -1)
            {
                string valor = comboBoxPedido.SelectedItem.ToString();

                string precio = bd.selectstring("select PrecioBuffet from Buffet where NombreBuffet = '" + clogiga.encriptacion(valor) + "'");
                textBoxPrecio.Text = clogiga.desencriptacion(precio);


            }
            else
            {
                textBoxPrecio.Text = "0";
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
