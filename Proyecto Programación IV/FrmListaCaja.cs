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
using System.Globalization;

namespace Proyecto_Programación_IV
{
    public partial class FrmListaCaja : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmListaCaja()
        {
            InitializeComponent();
            dateTimePickerFechaIncial.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaIncial.CustomFormat = "dd-MM-yyyy";
            actualizarDataGrid("select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante");
            dateTimePickerFechaIncial.Enabled = false;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].Width = 100;

            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizarDataGrid("select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante");
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

                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()),clogiga.desencriptacion(row[6].ToString()));

                   

            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();          
                                                                                                                                                                                       
            bd.executecommand("update CajasRestaurante set FechaRegistro='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',Descripcion='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',EntradaDinero='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',AperturaCaja='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "',CierreCaja='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "',RestauranteCaja='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "'WHERE CodigoCaja='" + clogiga.encriptacion(id) + "'");
            Bitacora("Actualizo datos de la Caja", "Actualizo Caja");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
         
           if (radioButtonAperura.Checked)
            { 
         
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante where CodigoCaja= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and CierreCaja= '" + clogiga.encriptacion("-") + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante where RestauranteCaja= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CierreCaja= '" + clogiga.encriptacion("-") + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante RestauranteCaja= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoCaja='" + clogiga.encriptacion(TextboxCodigo.Text) + "' and CierreCaja= '" + clogiga.encriptacion("-") + "'");

                if (checkBoxFecha.Checked)
                {
                    fechas(dateTimePickerFechaIncial.Text, 2);
                }
                
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           if (radioButtonCierre.Checked)
            { 
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante where CodigoCaja= '" + clogiga.encriptacion(TextboxCodigo.Text) + "' and AperturaCaja= '" + clogiga.encriptacion("-") + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante where RestauranteCaja= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and AperturaCaja= '" + clogiga.encriptacion("-") + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante RestauranteCaja= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoCaja='" + clogiga.encriptacion(TextboxCodigo.Text) + "' and AperturaCaja= '" + clogiga.encriptacion("-") + "'");
              
                if (checkBoxFecha.Checked)
                {
                    fechas(dateTimePickerFechaIncial.Text, 1);
                }

                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autoCompletar();
        }

        private void autoCompletar()
        {                                               
                                                                                                              
                bd.autocompletar("select RestauranteCaja from CajasRestaurante", "RestauranteCaja", 1, TextboxNombre);
                bd.autocompletar("select CodigoCaja from CajasRestaurante", "CodigoCaja", 1, TextboxCodigo);
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
            FrmAgregarPuestos frm = new FrmAgregarPuestos();
            frm.Show();
        }

        private void radioButtonFecha_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButtonGeneral_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void radioButtonUsuario_CheckedChanged(object sender, EventArgs e)
        {
          
        }


        private void fechas(string fecha, int ConCierre)
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

            if (ConCierre == 1)
            {
                texto = "AperturaCaja";
            }
            else
            {
                texto =  "CierreCaja";
            }

            dt = bd.SelectDataTable("Select CodigoCaja,FechaRegistro from CajasRestaurante  where " + texto + " = '" + clogiga.encriptacion("-") + "'").Copy();

            foreach (DataRow row in dt.Rows)
            {
                string tiempoSinFormat = clogiga.desencriptacion(row[1].ToString());
                string tiempo = tiempoSinFormat.Substring(0, 10);
                string format = "dd-MM-yyyy";
                DateTime d1 = DateTime.ParseExact(tiempo, format, CultureInfo.InvariantCulture);//fecha normal

                DateTime fechaEstable = DateTime.ParseExact(fecha, format, CultureInfo.InvariantCulture);

                if (d1 == fechaEstable)
                    {
                        listaId.Add(row[0].ToString());
                      
                    }
                
        

            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            //recorre los ids, y los va agregando fila por fila a la tabla, para luego ser mostrados
            for (int x = 0; x < listaId.Count; x++)
            {

                dtFinal = bd.SelectDataTable("select CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante where CodigoCaja = '" + listaId[x] + "'");
                foreach (DataColumn col in dtFinal.Columns)
                {

                    modelo.Columns.Add(col.ToString());
                }
                foreach (DataRow row in dtFinal.Rows)
                {

                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()));

                }
            }

            dataGridView1.DataSource = modelo;
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFecha.Checked)
            {
                dateTimePickerFechaIncial.Enabled = true;
            }
            else
            {
                dateTimePickerFechaIncial.Enabled = false;
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
