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
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections;

namespace Proyecto_Programación_IV
{
    public partial class FrmListaClientes : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmListaClientes()
        {
            InitializeComponent();
            dateTimePickerFechaInicial.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaInicial.CustomFormat = "dd-MM-yyyy";
            dateTimePickerFechaFinal.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaFinal.CustomFormat = "dd-MM-yyyy";

            dateTimePickerFechaRservacionInicial.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaRservacionInicial.CustomFormat = "dd-MM-yyyy";
            dateTimePickerFechaRservacionFinal.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaRservacionFinal.CustomFormat = "dd-MM-yyyy";

            dateTimePickerFechaInicial.Enabled = false;
            dateTimePickerFechaFinal.Enabled = false;
            dateTimePickerFechaRservacionInicial.Enabled = false;
            dateTimePickerFechaRservacionFinal.Enabled = false;


            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes");
            dataGridView1.Columns[0].Width = 75;
            dataGridView1.Columns[1].Width = 148;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80; 

            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            
            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes");
            autoCompletar();
        }

        private void actualizarDataGrid(string query)
        {   //TABLA CON LOS DATOS ENCRIPTADOS
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable(query).Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataColumn col in dt.Columns)
            {
               
                modelo.Columns.Add(col.ToString());
            }
            foreach (DataRow row in dt.Rows)
            {



                if (!string.IsNullOrEmpty(row[6].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()));
                }
                else
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), row[6].ToString(), clogiga.desencriptacion(row[7].ToString()));
                }

                
            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            bd.executecommand("update Clientes set NombreCompletoCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',MontoPagadoCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',DetalleCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',FechaCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "',ReservacionCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) + "',BarraCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()) + "',RestauranteCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()) + "'WHERE CodigoCliente='" + clogiga.encriptacion(id) + "'");
            Bitacora("Se Actualizo la Lista Clientes", "Actualizar Lista Clientes");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
            //http://stackoverflow.com/questions/14208958/select-data-from-date-range-between-two-dates

            // is http://stackoverflow.com/questions/5125076/sql-query-to-select-dates-between-two-dates

         
                if (radioButtonBarra.Checked)
                {
                    if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where CodigoCliente= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and BarraCliente is not null");
                    if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                    if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoCliente='" + clogiga.encriptacion(TextboxCodigo.Text) + "'and BarraCliente is not null");
                    if (!string.IsNullOrEmpty(textBoxRestaurante.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where RestauranteCliente= '" + clogiga.encriptacion(textBoxRestaurante.Text) + "' and BarraCliente is not null");


                    if (checkBoxFecha.Checked)
                    {

                        fechas(dateTimePickerFechaInicial.Text, dateTimePickerFechaFinal.Text, 1, 2);

                    }
                    if (checkBoxRangoFechaReservacion.Checked)
                    {
                        //las barras no tienen reservaciones
                    }
            
                }
                if (radioButtonReservacion.Checked)
                {
                    if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where CodigoCliente= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and ReservacionCliente = '" + clogiga.encriptacion("SI")+ "'and BarraCliente is null");
                    if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "'and BarraCliente is null");
                    if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "' and CodigoCliente='" + clogiga.encriptacion(TextboxCodigo.Text) + "'and BarraCliente is null");
                    if (!string.IsNullOrEmpty(textBoxRestaurante.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where RestauranteCliente= '" + clogiga.encriptacion(textBoxRestaurante.Text) + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "'and BarraCliente is null");

                   if (checkBoxFecha.Checked)
                    {
                        fechas(dateTimePickerFechaInicial.Text, dateTimePickerFechaFinal.Text, 1, 1);
                       
                    }
                   if (checkBoxRangoFechaReservacion.Checked)
                    {
                 
                        fechas(dateTimePickerFechaRservacionInicial.Text, dateTimePickerFechaRservacionFinal.Text, 2,1);
                    }

                }

              
               if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autoCompletar();
        }

        private void autoCompletar()
        {
            bd.autocompletar("select NombreCompletoCliente from Clientes", "NombreCompletoCliente", 1, TextboxNombre);
            bd.autocompletar("select CodigoCliente from Clientes", "CodigoCliente", 1, TextboxCodigo);
            bd.autocompletar("select RestauranteCliente from Clientes", "RestauranteCliente", 1, textBoxRestaurante);
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarMesas frm = new FrmAgregarMesas();
            frm.Show();
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            //
            if (radioButtonBarra.Checked)
            {
               //
                if (checkBoxFecha.Checked)
                {

                    dateTimePickerFechaInicial.Enabled = true;
                    dateTimePickerFechaFinal.Enabled = true;

                }
                else
                {
                    dateTimePickerFechaInicial.Enabled = false;
                    dateTimePickerFechaFinal.Enabled = false;
                }


            }
            if (radioButtonReservacion.Checked)
            {


                if (checkBoxFecha.Checked)
                {

                    dateTimePickerFechaInicial.Enabled = true;
                    dateTimePickerFechaFinal.Enabled = true;

                }
                else
                {
                    dateTimePickerFechaInicial.Enabled = false;
                    dateTimePickerFechaFinal.Enabled = false;
                }
          

            }
        }

        private void checkBoxRangoFechaReservacion_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBarra.Checked)
            {
                //
                if (checkBoxRangoFechaReservacion.Checked)
                {
                    dateTimePickerFechaRservacionInicial.Enabled = false;
                    dateTimePickerFechaRservacionFinal.Enabled = false;
                }

            }
            if (radioButtonReservacion.Checked)
            {


                if (checkBoxRangoFechaReservacion.Checked)
                {

                    dateTimePickerFechaRservacionInicial.Enabled = true;
                    dateTimePickerFechaRservacionFinal.Enabled = true;

                }
                else
                {
                    dateTimePickerFechaRservacionInicial.Enabled = false;
                    dateTimePickerFechaRservacionFinal.Enabled = false;
                }


            }
        }

        private void fechas(string inicial, string Final, int tipofecha,int SinBarra)
        {
            Querys clogiga = new Querys();
            DataTable dt = new DataTable();
            DataTable dtFinal = new DataTable();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //lista de los ids seleccionados
            ArrayList listaId = new ArrayList();
            //LENA LA TABLA DT CON LOS DATOS
            string texto = string.Empty;
            
            if (SinBarra == 1)
            {
                texto = "BarraCliente is null";
            }
            else
            {
                texto = "BarraCliente is not null";
            }
            dt = bd.SelectDataTable("Select  CodigoCliente,FechaCliente,FechaReservacion from Clientes where "+texto+"").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO

            foreach (DataRow row in dt.Rows)
            {
                string tiempo = clogiga.desencriptacion(row[1].ToString());
                string tiempo2 = string.Empty;
               
                if(string.IsNullOrEmpty(row[2].ToString()) &&  radioButtonReservacion.Checked && checkBoxRangoFechaReservacion.Checked){
                    CustomMessageBox.ShowMessage("No hay cliente que hayan reservado todavia", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                if (!string.IsNullOrEmpty(row[2].ToString()) && radioButtonReservacion.Checked && checkBoxRangoFechaReservacion.Checked)
                {
                    tiempo2 = clogiga.desencriptacion(row[2].ToString());
                }
                

                string format = "dd-MM-yyyy";
                DateTime d1 = DateTime.ParseExact(tiempo, format, CultureInfo.InvariantCulture);//fecha normal
                DateTime d2 = new DateTime();
                if (!string.IsNullOrEmpty(row[2].ToString()) && radioButtonReservacion.Checked && checkBoxRangoFechaReservacion.Checked)
                {
                    tiempo2 = clogiga.desencriptacion(row[2].ToString());
                     d2 = DateTime.ParseExact(tiempo2, format, CultureInfo.InvariantCulture); //fecha reservacuion
                }
                
        

                DateTime dinicial = DateTime.ParseExact(inicial, format, CultureInfo.InvariantCulture);
                DateTime dfinal = DateTime.ParseExact(Final, format, CultureInfo.InvariantCulture);

                if (tipofecha == 1)
                {
                    if (d1 >= dinicial && d1 <= dfinal)
                    {
                        listaId.Add(row[0].ToString());
                    }
                }
                else
                {
                    if (d2 >= dinicial && d2 <= dfinal)
                    {
                        listaId.Add(row[0].ToString());
                    }
                }

            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            //recorre los ids, y los va agregando fila por fila a la tabla, para luego ser mostrados


            modelo.Columns.Add("CodigoCliente");
            modelo.Columns.Add("NombreCompletoCliente");
            modelo.Columns.Add("MontoPagadoCliente");
            modelo.Columns.Add("DetalleCliente");
            modelo.Columns.Add("FechaCliente");
            modelo.Columns.Add("ReservacionCliente");
            modelo.Columns.Add("BarraCliente");
            modelo.Columns.Add("RestauranteCliente");

            if (listaId.Count > 0)
            {


                for (int x = 0; x < listaId.Count; x++)
                {

                    dtFinal = bd.SelectDataTable("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,BarraCliente,RestauranteCliente from Clientes where CodigoCliente = '" + listaId[x] + "'");

                    foreach (DataRow row in dtFinal.Rows)
                    {


                        if (!string.IsNullOrEmpty(row[6].ToString()))
                        {
                            modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()));
                        }
                        else
                        {
                            modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), row[6].ToString(), clogiga.desencriptacion(row[7].ToString()));
                        }


                    }
                }
            }

            dataGridView1.DataSource = modelo;
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
