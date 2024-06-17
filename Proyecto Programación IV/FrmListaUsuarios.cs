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
    public partial class FrmListaUsuarios : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmListaUsuarios()
        {
            InitializeComponent();
            actualizarDataGrid("select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios");
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].Width = 50;
            dataGridView1.Columns[10].Width = 90;
            dataGridView1.Columns[11].Width = 50;
           

            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizarDataGrid("select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios");
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

                modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()), clogiga.desencriptacion(row[8].ToString()), clogiga.desencriptacion(row[9].ToString()), clogiga.desencriptacion(row[10].ToString()), clogiga.desencriptacion(row[11].ToString()));


                
            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            bd.executecommand("update Usuarios set NombreUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',PrimerApellidoUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',SegundoApellidoUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',Telefono1Usuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "',Telefono2Usuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) + "',LoginUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()) + "',AdminSistemaUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString().ToUpper()) + "',AdminSeguridadUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString().ToUpper()) + "',AdminRestauranteUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().ToUpper()) + "',AdminTipoRestauranteUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString()) + "',AdminCuentasUsuario='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString().ToUpper()) + "'WHERE CodigoUsuario='" + clogiga.encriptacion(id) + "'");
            Bitacora("Actualizo un usuario de la lista", "Actualizo Usuario");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();

            if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where CodigoUsuario= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'"); 
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where NombreUsuario= '" + clogiga.encriptacion(TextboxNombre.Text) + "'"); 
            if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios  where NombreUsuario= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoUsuario='" + clogiga.encriptacion(TextboxCodigo.Text) + "'"); 
            if (!string.IsNullOrEmpty(textBoxNickname.Text)) actualizarDataGrid("Select  CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where LoginUsuario= '" + clogiga.encriptacion(textBoxNickname.Text) + "'");

            try
            {
                if (comboBoxPrivilegios.SelectedItem.Equals("Administrador Seguridad"))
                {
                    actualizarDataGrid("Select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where AdminSeguridadUsuario= '" + clogiga.encriptacion("SI") + "'");
                }
                if (comboBoxPrivilegios.SelectedItem.Equals("Administrador Sistema"))
                {
                    actualizarDataGrid("Select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where AdminSistemaUsuario= '" + clogiga.encriptacion("SI") + "'");
                }
                if (comboBoxPrivilegios.SelectedItem.Equals("Administrador Restaurante"))
                {
                    actualizarDataGrid("Select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where AdminRestauranteUsuario= '" + clogiga.encriptacion("SI") + "'");
                }
                if (comboBoxPrivilegios.SelectedItem.Equals("Administrador Cuentas"))
                {
                    actualizarDataGrid("Select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios where AdminCuentasUsuario= '" + clogiga.encriptacion("SI") + "'");
                }
            }
            catch (Exception)
            {

                //
            }
                
           
            if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autoCompletar();
        }

        private void autoCompletar()
        {  
            bd.autocompletar("select NombreUsuario from Usuarios", "NombreUsuario", 1, TextboxNombre);
            bd.autocompletar("select CodigoUsuario from Usuarios", "CodigoUsuario", 1, TextboxCodigo);
            bd.autocompletar("select LoginUsuario from Usuarios", "LoginUsuario", 1, textBoxNickname);
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
            FrmAgregarUsuarios frm = new FrmAgregarUsuarios();
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
                bd.executecommand("delete Usuarios WHERE CodigoUsuario='" + clogiga.encriptacion(id) + "'");
                actualizarDataGrid(" select CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,LoginUsuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario from Usuarios");
                Bitacora("Elimino un usuario de la lista", "Elimino Usuario");
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
