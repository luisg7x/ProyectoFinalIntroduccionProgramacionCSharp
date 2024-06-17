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
    public partial class FrmListaClientesBarra : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmListaClientesBarra()
        {
            InitializeComponent();
            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente from Clientes where BarraCliente is not null");
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 190;
            dataGridView1.Columns[4].Width = 110;

            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente from Clientes where BarraCliente is not null");
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

                modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()));


                
            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();   
  
            bd.executecommand("update Clientes set NombreCompletoCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',MontoPagadoCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',DetalleCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',FechaCliente='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())+ "'WHERE CodigoCliente='" + clogiga.encriptacion(id) + "'");
            Bitacora("Se Actualizo un Cliente (Barra,DataGrid)", "Actualizar Cliente (Barra)");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();


            if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente from Clientes where BarraCliente is not null and  CodigoCliente= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and BarraCliente is not null");
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente from Clientes where BarraCliente is not null and  NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and BarraCliente is not null");
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente from Clientes where BarraCliente is not null and  NombreCompletoCliente= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoCliente='" + clogiga.encriptacion(TextboxCodigo.Text) + "' and BarraCliente is not null");
               
       
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



        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                CustomMessageBox.ShowMessage("Error al eliminar no ha seleccionado una fila\n\nConsejo: \n• Haga click en el simbolo  ►  que esta en la tabla para \nseleccionar la fila y poder eliminarla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                bd.executecommand("delete Clientes WHERE CodigoCliente='" + clogiga.encriptacion(id) + "'");
                actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente from Clientes where BarraCliente is not null");
                Bitacora("Se Elimino un Cliente", "Eliminar Clientes");
                CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void buttonAgregar_Click_1(object sender, EventArgs e)
        {
            FrmAgregarClienteRestauranteBarra frm = new FrmAgregarClienteRestauranteBarra();
            frm.privilegios(rols);
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
            string numSilla = bd.selectstring("select NumSilla from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string fecha = bd.selectstring("select FechaCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string prefijo = bd.selectstring("select PrefijoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string entrada = bd.selectstring("select HoraEntrada from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string lista = bd.selectstring("select DetalleCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string estado = bd.selectstring("select EstadoPago from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
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

            FrmAgregarClienteRestauranteBarra frm = new FrmAgregarClienteRestauranteBarra();
            frm.edicionValor = 1;
            frm.privilegios(rols);
            frm.cargarCliente(lista, nombre, montoPago, fecha, tiempoMesa, numSilla, idPrefijo, entrada, estado);
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
