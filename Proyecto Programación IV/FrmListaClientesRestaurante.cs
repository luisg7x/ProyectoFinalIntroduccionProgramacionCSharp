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
using System.Collections;

namespace Proyecto_Programación_IV
{
    public partial class FrmListaClientesRestaurante : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
       
        public FrmListaClientesRestaurante()
        {
            InitializeComponent();
            dateTimePickerFechaReservacion.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaReservacion.CustomFormat = "dd-MM-yyyy";
 
            

            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
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

                modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()));


                
            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();   

            bd.executecommand("update Clientes set NombreCompletoCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',MontoPagadoCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',DetalleCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',FechaCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())+ "',ReservacionCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString())+ "',RestauranteCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString())+ "'WHERE CodigoCliente='" + clogiga.encriptacion(id) + "'");
            Bitacora("Se Actualizo un Cliente(Mesa, DataGrid)", "Actualizar Clientes");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();

            
            if (checkBoxReservacion.Checked)
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where CodigoCliente= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and ReservacionCliente='" + clogiga.encriptacion("SI") + "'and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and ReservacionCliente='" + clogiga.encriptacion("SI") + "'and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoCliente='" + clogiga.encriptacion(TextboxCodigo.Text) + "' and ReservacionCliente='" + clogiga.encriptacion("SI") + "'and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
                if (!string.IsNullOrEmpty(dateTimePickerFechaReservacion.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where FechaCliente= '" + clogiga.encriptacion(dateTimePickerFechaReservacion.Text) + "' and ReservacionCliente='" + clogiga.encriptacion("SI") + "'and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
            }
            else
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where CodigoCliente= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoCliente='" + clogiga.encriptacion(TextboxCodigo.Text) + "'and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
                if (!string.IsNullOrEmpty(dateTimePickerFechaReservacion.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where FechaCliente= '" + clogiga.encriptacion(dateTimePickerFechaReservacion.Text) + "'and BarraCliente is null  and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
            }
            if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autoCompletar();
            Querys clogiga = new Querys();

            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente from Clientes where BarraCliente is null and RestauranteCliente ='" + clogiga.encriptacion(rols[3]) + "'");
            dataGridView1.Columns[0].Width = 85;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 210;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 120;
        }

        private void autoCompletar()
        {
            bd.autocompletar("select NombreCompletoCliente from Clientes", "NombreCompletoCliente", 1, TextboxNombre);
            bd.autocompletar("select CodigoCliente from Clientes", "CodigoCliente", 1, TextboxCodigo);
          
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
            FrmAgregarComestibles frm = new FrmAgregarComestibles();
            frm.Show();
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();

            //desencrip
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //todo encriptado
            string nombre = bd.selectstring("select NombreCompletoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string montoPago = bd.selectstring("select MontoPagadoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string tiempoMesa = bd.selectstring("select TiempoMesa from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string numMesa = bd.selectstring("select NumMesa from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla1 = bd.selectstring("select silla1Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla2 = bd.selectstring("select silla2Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla3 = bd.selectstring("select silla3Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla4 = bd.selectstring("select silla4Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string reservacion = bd.selectstring("select ReservacionCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string fecha = bd.selectstring("select FechaCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string prefijo = bd.selectstring("select PrefijoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string entrada = bd.selectstring("select HoraEntrada from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string lista = bd.selectstring("select DetalleCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list1 = bd.selectstring("select List1Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list2 = bd.selectstring("select List2Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list3 = bd.selectstring("select List3Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list4 = bd.selectstring("select List4Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string estado = bd.selectstring("select EstadoPago from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string fechaReservacion = bd.selectstring("select FechaReservacion from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            //desencrip
            string idPrefijo = string.Empty;
            if (!string.IsNullOrEmpty(prefijo))
            {
                string PrefijoDesencrip = clogiga.desencriptacion(prefijo);
                idPrefijo = PrefijoDesencrip + " " + id;
            }
            else
            {
                idPrefijo = id;
            }

            FrmAgregarClientes frm = new FrmAgregarClientes();
            frm.edicionValor = 1;
            frm.privilegios(rols);
            frm.cargarCliente(lista,list1, list2, list3, list4, nombre, montoPago, fecha, reservacion, tiempoMesa, numMesa, pedidoSilla1, pedidoSilla2, pedidoSilla3, pedidoSilla4, idPrefijo, entrada, estado, fechaReservacion);
            frm.Show();

            
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
