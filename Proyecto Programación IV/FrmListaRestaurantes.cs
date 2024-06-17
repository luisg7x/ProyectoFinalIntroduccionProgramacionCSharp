﻿using System;
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
    public partial class FrmListaRestaurantes : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmListaRestaurantes()
        {
            InitializeComponent();
            actualizarDataGrid("SELECT CodigoRestaurante,NombreRestaurante,DireccionRestaurante ,CantidadClientes, TelefonoRestaurante FROM Restaurante");
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
            actualizarDataGrid("SELECT CodigoRestaurante,NombreRestaurante,DireccionRestaurante ,CantidadClientes, TelefonoRestaurante FROM Restaurante");
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
                //SE VALIDA QUE ESTE VACIO, PARA QUE NO DE ERROR EN LA DESENCRIPTACION
                if (!string.IsNullOrEmpty(row[3].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()));
                }
                else
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), row[3].ToString(), clogiga.desencriptacion(row[4].ToString()));
                }
                
            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

           string Cantidad = string.Empty;
           if (!string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()))
            {
                Cantidad = clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }

     
           bd.executecommand("update Restaurante set NombreRestaurante='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',DireccionRestaurante='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',CantidadClientes='" + Cantidad + "',TelefonoRestaurante='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "'WHERE CodigoRestaurante='" + clogiga.encriptacion(id) + "'");
           Bitacora("Se Actualizo un Restaurante", "Actualizar Restaurante");
     
            

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();

            if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoRestaurante,NombreRestaurante,DireccionRestaurante ,CantidadClientes, TelefonoRestaurante from Restaurante where CodigoRestaurante= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoRestaurante,NombreRestaurante,DireccionRestaurante ,CantidadClientes, TelefonoRestaurante from Restaurante where NombreRestaurante= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoRestaurante,NombreRestaurante,DireccionRestaurante ,CantidadClientes, TelefonoRestaurante from Restaurante where NombreRestaurante= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoRestaurante='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
            if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autoCompletar();
        }

        private void autoCompletar()
        {
            bd.autocompletar("select NombreRestaurante from Restaurante", "NombreRestaurante", 1, TextboxNombre);
            bd.autocompletar("select CodigoRestaurante from Restaurante", "CodigoRestaurante", 1, TextboxCodigo);
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
            FrmAgregarRestaurante frm = new FrmAgregarRestaurante();
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
                bd.executecommand("delete Restaurante WHERE CodigoRestaurante='" + clogiga.encriptacion(id) + "'");
                actualizarDataGrid("SELECT CodigoRestaurante,NombreRestaurante,DireccionRestaurante ,CantidadClientes, TelefonoRestaurante FROM Restaurante");
                Bitacora("Se Elimino un Restaurante", "Eliminar Restaurante");
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
