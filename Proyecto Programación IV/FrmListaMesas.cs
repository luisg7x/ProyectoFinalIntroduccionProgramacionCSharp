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

namespace Proyecto_Programación_IV
{
    public partial class FrmListaMesas : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmListaMesas()
        {
            InitializeComponent();
            actualizarDataGrid("Select CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 110;

            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizarDataGrid("Select CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas");
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

            bd.executecommand("update Mesas set NombreMesa='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',NumeroMesa='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',CantidadSillasMesa='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',RestauranteMesa='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "'WHERE CodigoMesa='" + clogiga.encriptacion(id) + "'");
            Bitacora("Se Actualizo una Mesa", "Actualizar Mesa");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();

            if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select  CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas where CodigoMesa= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas where NombreMesa= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas where NombreMesa= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoMesa='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
            if (!string.IsNullOrEmpty(textBoxRestaurante.Text)) actualizarDataGrid("Select  CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas where RestauranteMesa= '" + clogiga.encriptacion(textBoxRestaurante.Text) + "'");
            if (!string.IsNullOrEmpty(textBoxCantidadSillas.Text)) actualizarDataGrid("Select  CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas where CantidadSillasMesa= '" + clogiga.encriptacion(textBoxCantidadSillas.Text) + "'");
            if (string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(textBoxCantidadSillas.Text) && string.IsNullOrEmpty(textBoxRestaurante.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autoCompletar();
        }

        private void autoCompletar()
        {
            bd.autocompletar("select NombreMesa from Mesas", "NombreMesa", 1, TextboxNombre);
            bd.autocompletar("select CodigoMesa from Mesas", "CodigoMesa", 1, TextboxCodigo);
            bd.autocompletar("select CantidadSillasMesa from Mesas", "CantidadSillasMesa", 1, textBoxCantidadSillas);
            bd.autocompletar("select RestauranteMesa from Mesas", "RestauranteMesa", 1, textBoxRestaurante);
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
            frm.privilegios(rols);
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
                bd.executecommand("delete Mesas WHERE CodigoMesa='" + clogiga.encriptacion(id) + "'");
                actualizarDataGrid("Select CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa from Mesas");
                Bitacora("Se Eliminar una Mesa", "Eliminar Mesa");
                CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
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
