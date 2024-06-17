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
    public partial class FrmListaBitacora : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();

        public FrmListaBitacora()
        {
            InitializeComponent();
            dateTimePickerFechaIncial.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaIncial.CustomFormat = "dd-MM-yyyy";
            dateTimePickerFechaFinal.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaFinal.CustomFormat = "dd-MM-yyyy";
            actualizarDataGrid("select CodigoBitacora,Usuario,Fecha,Descripcion from Bitacora");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 210;
            cargarComboUsuario();

            comboBoxUsuario.Enabled = false;
            dateTimePickerFechaIncial.Enabled = false;
            dateTimePickerFechaFinal.Enabled = false;
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizarDataGrid("select CodigoBitacora,Usuario,Fecha,Descripcion from Bitacora");
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

                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()));

                   

            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();                                                                                                                                       
            bd.executecommand("update Bitacora set Usuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',Fecha='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',Descripcion='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',ExternoPuesto='" + "'WHERE CodigoBitacora='" + clogiga.encriptacion(id) + "'");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
        
            if (radioButtonFecha.Checked)
            {
                comboBoxUsuario.Enabled = false;
                dateTimePickerFechaIncial.Enabled = true;
                dateTimePickerFechaFinal.Enabled = true;
                fechas(dateTimePickerFechaIncial.Text, dateTimePickerFechaFinal.Text);
                return;
            }
            if(radioButtonGeneral.Checked)
            {
                comboBoxUsuario.Enabled = false;
                dateTimePickerFechaIncial.Enabled = false;
                dateTimePickerFechaFinal.Enabled = false;
                actualizarDataGrid("select CodigoBitacora,Usuario,Fecha,Descripcion from Bitacora");
                return;
            }
            if(radioButtonUsuario.Checked)
            {
                if (!string.IsNullOrEmpty(comboBoxUsuario.Text))
                {
                    actualizarDataGrid("Select CodigoBitacora,Usuario,Fecha,Descripcion from Bitacora where Usuario= '" + clogiga.encriptacion(comboBoxUsuario.SelectedItem.ToString()) +"'");
                }
                else
                {
                    CustomMessageBox.ShowMessage("No selecciono ningun Usuario para la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            /*    bd.autocompletar("select NombrePuesto from Puestos", "NombrePuesto", 1, TextboxNombre);
                bd.autocompletar("select CodigoPuesto from Puestos", "CodigoPuesto", 1, TextboxCodigo);*/
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
            radioButtons();
        }

        private void radioButtonGeneral_CheckedChanged(object sender, EventArgs e)
        {
            radioButtons();
        }

        private void radioButtonUsuario_CheckedChanged(object sender, EventArgs e)
        {
            radioButtons();
        }


        private void radioButtons()
        {
            if (radioButtonFecha.Checked)
            {
                dateTimePickerFechaIncial.Enabled = true;
                dateTimePickerFechaFinal.Enabled = true;
                comboBoxUsuario.Enabled = false;
            }
            else if (radioButtonGeneral.Checked)
            {
                dateTimePickerFechaIncial.Enabled = false;
                dateTimePickerFechaFinal.Enabled = false;
                comboBoxUsuario.Enabled = false;
            }
            else if (radioButtonUsuario.Checked)
            {
                dateTimePickerFechaIncial.Enabled = false;
                dateTimePickerFechaFinal.Enabled = false;
                comboBoxUsuario.Enabled = true;
            }
        }

        private void cargarComboUsuario()
        {
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("select LoginUsuario from Usuarios").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
            foreach (DataRow row in dt.Rows)
            {
               
                comboBoxUsuario.Items.Add(clogiga.desencriptacion(row[0].ToString()));

            }
 
        }

        private void fechas(string inicial, string Final)
        {
            Querys clogiga = new Querys();
            DataTable dt = new DataTable();
            DataTable dtFinal = new DataTable();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable final = new DataTable();
            //lista de los ids seleccionados
            ArrayList listaId = new ArrayList();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("Select  CodigoBitacora,Fecha from Bitacora").Copy();
            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO

            foreach (DataRow row in dt.Rows)
            {
                //
                string tiempoSinFormat = clogiga.desencriptacion(row[1].ToString());
                string tiempo = tiempoSinFormat.Substring(0, 10);
                string format = "dd-MM-yyyy";
                //
                DateTime d1 = DateTime.ParseExact(tiempo, format, CultureInfo.InvariantCulture);//fecha normal

                DateTime dinicial = DateTime.ParseExact(inicial, format, CultureInfo.InvariantCulture);
                DateTime dfinal = DateTime.ParseExact(Final, format, CultureInfo.InvariantCulture);

  
                    if (d1 >= dinicial && d1 <= dfinal)
                    {
                        listaId.Add(row[0].ToString());
                    }
               
              

            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            //recorre los ids, y los va agregando fila por fila a la tabla, para luego ser mostrados
            final.Columns.Add("CodigoBitacora");
            final.Columns.Add("Usuario");
            final.Columns.Add("Fecha");
            final.Columns.Add("Descripcion");
            for (int x = 0; x < listaId.Count; x++)
            {

                dtFinal = bd.SelectDataTable("select CodigoBitacora,Usuario,Fecha,Descripcion from Bitacora where CodigoBitacora = '" + listaId[x] + "'");
                
                foreach (DataRow row in dtFinal.Rows)
                {


                    final.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()));


                }
            }

            dataGridView1.DataSource = final;
        }
    }
}
