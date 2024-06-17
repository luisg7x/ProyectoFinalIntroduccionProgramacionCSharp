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
using System.IO;

namespace Proyecto_Programación_IV
{
    public partial class FrmListaEspecialidades : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        int tabla = 0;
        string[] rols = new string[6];
        public FrmListaEspecialidades()
        {
            InitializeComponent();
            labelRestaurante.Hide();
            textBoxRestaurante.Hide();
            textBoxNacionalidad.Hide();
            labelNacionalidad.Hide();
            labelAño.Hide();
            labelPrecio.Hide();
            textBoxPrecio.Hide();
            textBoxAño.Hide();
                //pictureBox2.Image = byteArrayToImage(GetBytes(doto));
            //MessageBox.Show(System.Text.ASCIIEncoding.Default.GetBytes(bd.SelectDataSet("SELECT FotoBuffet from Buffet where CodigoBuffet = 1")).ToString());             
            
        }


        public void selector(int tablas)
        {
           if (tablas == 1)
            {
                tabla = 1;
                label3.Text = "Lista Buffet";
                actualizarDataGrid("SELECT CodigoBuffet, NombreBuffet, PrecioBuffet , TipoComidaBuffet, UnidadMedidaBuffet FROM Buffet");
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 170;
                dataGridView1.Columns[2].Width = 170;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 110;
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Restaurant_96;
                
            }
           if (tablas == 2)
           {
               tabla = 2;
               label3.Text = "Lista Bebida Calientes";
               actualizarDataGrid("SELECT CodigoBebida, NombreBebida, PrecioBebida , RestauranteBebida FROM BebidaCalientes");
               dataGridView1.Columns[0].Width = 110;
               dataGridView1.Columns[1].Width = 180;
               dataGridView1.Columns[2].Width = 180;
               dataGridView1.Columns[3].Width = 180;
               pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Cafe_96;
  
           }
           if (tablas == 3)
           {
               tabla = 3;
               label3.Text = "Lista Bebida Heladas";
               actualizarDataGrid("SELECT CodigoBebida, NombreBebida, PrecioBebida , RestauranteBebida FROM BebidaHeladas");
               dataGridView1.Columns[0].Width = 110;
               dataGridView1.Columns[1].Width = 180;
               dataGridView1.Columns[2].Width = 180;
               dataGridView1.Columns[3].Width = 180;
               pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Winter_96;

           }
           if (tablas == 4)
           {
               labelRestaurante.Show();
               textBoxRestaurante.Show();
               tabla = 4;        
               label3.Text = "Lista Bebida Gaseosas";
               actualizarDataGrid("SELECT CodigoBebida, NombreBebida, PrecioBebida FROM BebidaGaseosas");
               dataGridView1.Columns[0].Width = 170;
               dataGridView1.Columns[1].Width = 240;
               dataGridView1.Columns[2].Width = 240;
               pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Soda_Bottle_96;
               

           }
           if (tablas == 5)
           {
               labelRestaurante.Show();
               textBoxRestaurante.Show();
               textBoxNacionalidad.Show();
               labelNacionalidad.Show();
               labelRestaurante.Location = new Point(523, 66);
               textBoxRestaurante.Location = new Point(526, 87);
               TextboxCodigo.Location = new Point(333, 33);
               TextboxNombre.Location = new Point(333, 87);
               buttonAgregar.Location = new Point(262, 12);
               buttonEliminar.Location = new Point(262, 66);
               labelCod.Location = new Point(333, 12);
               labelNombre.Location = new Point(333, 66);
               labelNacionalidad.Location = new Point(523, 12);
               textBoxNacionalidad.Location = new Point(526, 33);   
               tabla = 5;
               label3.Text = "Lista Bebida Licores";
               actualizarDataGrid("select CodigoLicor,NombreLicor,CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores");
               dataGridView1.Columns[0].Width = 90;
               dataGridView1.Columns[1].Width = 130;
               dataGridView1.Columns[2].Width = 130;
               dataGridView1.Columns[3].Width = 100;
               dataGridView1.Columns[4].Width = 100;
               dataGridView1.Columns[5].Width = 100;
               pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Wine_Bottle_96;


           }
           if (tablas == 6)
           {
               labelRestaurante.Show();
               textBoxRestaurante.Show();
               textBoxNacionalidad.Show();
               labelNacionalidad.Show();
               labelAño.Show();
               labelPrecio.Show();
               textBoxPrecio.Show();
               textBoxAño.Show();
               labelRestaurante.Location = new Point(419, 11);
               textBoxRestaurante.Location = new Point(422, 32);
               TextboxCodigo.Location = new Point(235, 32);
               TextboxNombre.Location = new Point(235, 86);
               buttonAgregar.Location = new Point(164, 11);
               buttonEliminar.Location = new Point(164, 65);
               labelCod.Location = new Point(235, 11);
               labelNombre.Location = new Point(235, 65);
               labelNacionalidad.Location = new Point(419, 65);
               textBoxNacionalidad.Location = new Point(422, 86);
               labelAño.Location = new Point(603, 65);
               labelPrecio.Location = new Point(603, 11);
               textBoxPrecio.Location = new Point(606, 32);
               textBoxAño.Location = new Point(606, 86);
               tabla = 6;
               label3.Text = "Lista Bebida Vinos";
               actualizarDataGrid("Select CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos");
               dataGridView1.Columns[0].Width = 90;
               dataGridView1.Columns[1].Width = 130;
               dataGridView1.Columns[2].Width = 130;
               dataGridView1.Columns[3].Width = 100;
               dataGridView1.Columns[4].Width = 100;
               dataGridView1.Columns[5].Width = 100;
               pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Wine_Glass_96;


           }
           if (tablas == 7)
           {
               tabla = 7;
               label3.Text = "Lista Especiales";
               actualizarDataGrid("select CodigoEspecial,NombrePlatilloEspecial,IngredientesEspecial,PrecioEspecial,DetalleEspecial from Especiales");
               dataGridView1.Columns[0].Width = 100;
               dataGridView1.Columns[1].Width = 170;
               dataGridView1.Columns[2].Width = 170;
               dataGridView1.Columns[3].Width = 100;
               dataGridView1.Columns[4].Width = 110;
               pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Paste_Special_96;

           }
        }
        //array a imagen :*
       /* public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }*/

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            selector(tabla);
            autocompletar();
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
            if (tabla == 1 || tabla == 7) 
            { 
                foreach (DataRow row in dt.Rows)
                {
       
                        modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()));
              
              
                
                }
      
            }
            if (tabla == 2 || tabla == 3)
            {
                foreach (DataRow row in dt.Rows)
                {

                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()));



                }
         
            }
            if (tabla == 4)
            {
                foreach (DataRow row in dt.Rows)
                {

                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()));



                }

            }
            if (tabla == 5 || tabla == 6)
            {
                foreach (DataRow row in dt.Rows)
                {

                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()));



                }

            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //selector
            Querys clogiga = new Querys();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (tabla == 1)
            {
                bd.executecommand("update Buffet set NombreBuffet='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',PrecioBuffet='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',TipoComidaBuffet='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',UnidadMedidaBuffet='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "'WHERE CodigoBuffet='" + clogiga.encriptacion(id) + "'");
                Bitacora("Se Actualizo un Buffet", "Actualizar Buffet");
            }
            if (tabla == 2)
            {
                bd.executecommand("update BebidaCalientes set NombreBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',PrecioBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',RestauranteBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "'WHERE CodigoBebida='" + clogiga.encriptacion(id) + "'");
                Bitacora("Se Actualizo una BebidaCalientes", "Actualizar BebidaCalientes");
            }
            if (tabla == 3)
            {
                bd.executecommand("update BebidaHeladas set NombreBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',PrecioBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',RestauranteBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "'WHERE CodigoBebida='" + clogiga.encriptacion(id) + "'");
                Bitacora("Se Actualizo una BebidaHeladas", "Actualizar BebidaHeladas");
            }
            if (tabla == 4)
            {
                bd.executecommand("update BebidaGaseosas set NombreBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',PrecioBebida='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "'WHERE CodigoBebida='" + clogiga.encriptacion(id) + "'");
                Bitacora("Se Actualizo una BebidaGaseosas", "Actualizar BebidaGaseosas");
            }
            if (tabla == 5)
            {
                bd.executecommand("update Licores set NombreLicor='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',CantidadLicor='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',PrecioUnitarioLicor='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',PrecioBotellaLicor='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "',NacionalidadLicor='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) + "'WHERE CodigoLicor='" + clogiga.encriptacion(id) + "'");
                Bitacora("Se Actualizo un Licor", "Actualizar Licores");
            }
            if (tabla == 6)
            {
                bd.executecommand("update Vinos set NombreVino='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',PrecioUnitarioVino='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',PrecioBotellaVino='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',NacionalidadVino='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + "',AñoCosechaVino='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) + "'WHERE CodigoVino='" + clogiga.encriptacion(id) + "'");
                Bitacora("Se Actualizo un Vino", "Actualizar Vinos");
            }                                                                                                                                                         
            if (tabla == 7)
            {
                bd.executecommand("update Especiales set NombrePlatilloEspecial='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "',IngredientesEspecial='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) + "',PrecioEspecial='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + "',DetalleEspecial='" + clogiga.encriptacion(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) +"'WHERE CodigoEspecial='" + clogiga.encriptacion(id) + "'");
            
            }

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
            //Debe ser mejorado, mucho codigo :S
            if (tabla == 1)
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoBuffet,NombreBuffet,PrecioBuffet ,TipoComidaBuffet, UnidadMedidaBuffet from Buffet where CodigoRestaurante= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoBuffet,NombreBuffet,PrecioBuffet ,TipoComidaBuffet, UnidadMedidaBuffet from Buffet where NombreBuffet= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoBuffet,NombreBuffet,PrecioBuffet ,TipoComidaBuffet, UnidadMedidaBuffet from Buffet where NombreBuffet= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoBuffet='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tabla == 2) 
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoBebida,NombreBebida,PrecioBebida ,RestauranteBebida from BebidaCalientes where CodigoBebida= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoBebida,NombreBebida,PrecioBebida ,RestauranteBebida from BebidaCalientes where NombreBebida= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoBebida,NombreBebida,PrecioBebida ,RestauranteBebida from BebidaCalientes where NombreBebida= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoBebida='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tabla == 3)
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoBebida,NombreBebida,PrecioBebida ,RestauranteBebida from BebidaHeladas where CodigoBebida= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoBebida,NombreBebida,PrecioBebida ,RestauranteBebida from BebidaHeladas where NombreBebida= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoBebida,NombreBebida,PrecioBebida ,RestauranteBebida from BebidaHeladas where NombreBebida= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoBebida='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tabla == 4)
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select  CodigoBebida, NombreBebida, PrecioBebida FROM BebidaGaseosas where CodigoBebida= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoBebida, NombreBebida, PrecioBebida FROM BebidaGaseosas where NombreBebida= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoBebida, NombreBebida, PrecioBebida FROM BebidaGaseosas where NombreBebida= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoBebida='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxRestaurante.Text)) actualizarDataGrid("Select CodigoBebida, NombreBebida, PrecioBebida FROM BebidaGaseosas where RestauranteBebida= '" + clogiga.encriptacion(textBoxRestaurante.Text) + "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(textBoxRestaurante.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tabla == 5)
            {

                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select  CodigoLicor,NombreLicor,CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores where CodigoLicor= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select  CodigoLicor,NombreLicor,CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores where NombreLicor= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoLicor,NombreLicor,CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores where NombreLicor= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoLicor='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxRestaurante.Text)) actualizarDataGrid("Select CodigoLicor, NombreLicor, CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores where RestauranteLicor= '" + clogiga.encriptacion(textBoxRestaurante.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxNacionalidad.Text)) actualizarDataGrid("Select CodigoLicor,NombreLicor,CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores where NacionalidadLicor= '" + clogiga.encriptacion(textBoxNacionalidad.Text)+ "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(textBoxRestaurante.Text) && string.IsNullOrEmpty(textBoxNacionalidad.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tabla == 6)
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select   CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where CodigoVino= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select   CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where NombreVino= '" + clogiga.encriptacion(TextboxNombre.Text) + "'"); 
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select   CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where NombreVino= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoVino='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxRestaurante.Text)) actualizarDataGrid("Select CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where RestauranteVino= '" + clogiga.encriptacion(textBoxRestaurante.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxNacionalidad.Text)) actualizarDataGrid("Select  CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where NacionalidadVino= '" + clogiga.encriptacion(textBoxNacionalidad.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxPrecio.Text)) actualizarDataGrid("Select  CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where PrecioUnitarioVino= '" + clogiga.encriptacion(textBoxPrecio.Text) + "'");
                if (!string.IsNullOrEmpty(textBoxAño.Text)) actualizarDataGrid("Select  CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos where AñoCosechaVino= '" + clogiga.encriptacion(textBoxAño.Text) + "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(textBoxRestaurante.Text) && string.IsNullOrEmpty(textBoxNacionalidad.Text) && string.IsNullOrEmpty(textBoxAño.Text) && string.IsNullOrEmpty(textBoxPrecio.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            if (tabla == 7)
            {
                if (!string.IsNullOrEmpty(TextboxCodigo.Text) && string.IsNullOrEmpty(TextboxNombre.Text)) actualizarDataGrid("Select CodigoEspecial,NombrePlatilloEspecial,IngredientesEspecial,PrecioEspecial,DetalleEspecial from Especiales where CodigoEspecial= '" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoEspecial,NombrePlatilloEspecial,IngredientesEspecial,PrecioEspecial,DetalleEspecial from Especiales where NombrePlatilloEspecial= '" + clogiga.encriptacion(TextboxNombre.Text) + "'");
                if (!string.IsNullOrEmpty(TextboxNombre.Text) && !string.IsNullOrEmpty(TextboxCodigo.Text)) actualizarDataGrid("Select CodigoEspecial,NombrePlatilloEspecial,IngredientesEspecial,PrecioEspecial,DetalleEspecial from Especiales where NombrePlatilloEspecial= '" + clogiga.encriptacion(TextboxNombre.Text) + "' and CodigoEspecial='" + clogiga.encriptacion(TextboxCodigo.Text) + "'");
                if (string.IsNullOrEmpty(TextboxNombre.Text) && string.IsNullOrEmpty(TextboxCodigo.Text)) CustomMessageBox.ShowMessage("Inserte datos para poder realizar la busqueda", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dataGridView1.Rows.Count == 1) CustomMessageBox.ShowMessage("No se encontro ningun valor", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                                                                                                
        }

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            autocompletar();
        }

        private void autocompletar()
        {
            if (tabla == 1)
            {
                bd.autocompletar("select NombreBuffet from Buffet", "NombreBuffet", 1, TextboxNombre);
                bd.autocompletar("select CodigoBuffet from Buffet", "CodigoBuffet", 1, TextboxCodigo);
            }
            if (tabla == 2)
            {
                bd.autocompletar("select NombreBebida from BebidaCalientes", "NombreBebida", 1, TextboxNombre);
                bd.autocompletar("select CodigoBebida from BebidaCalientes", "CodigoBebida", 1, TextboxCodigo);
            }
            if (tabla == 3)
            {
                bd.autocompletar("select NombreBebida from BebidaHeladas", "NombreBebida", 1, TextboxNombre);
                bd.autocompletar("select CodigoBebida from BebidaHeladas", "CodigoBebida", 1, TextboxCodigo);
            }
            if (tabla == 4)
            {
                bd.autocompletar("select NombreBebida from BebidaGaseosas", "NombreBebida", 1, TextboxNombre);
                bd.autocompletar("select CodigoBebida from BebidaGaseosas", "CodigoBebida", 1, TextboxCodigo);
                bd.autocompletar("select RestauranteBebida from BebidaGaseosas", "RestauranteBebida", 1, textBoxRestaurante);
            }
            if (tabla == 5)
            {
                bd.autocompletar("select NombreLicor from Licores", "NombreLicor", 1, TextboxNombre);
                bd.autocompletar("select CodigoLicor from Licores", "CodigoLicor", 1, TextboxCodigo);
                bd.autocompletar("select RestauranteLicor from Licores", "RestauranteLicor", 1, textBoxRestaurante);
                bd.autocompletar("select NacionalidadLicor from Licores", "NacionalidadLicor", 1, textBoxNacionalidad);
            }
            if (tabla == 6)
            {      
                bd.autocompletar("select NombreVino from Vinos", "NombreVino", 1, TextboxNombre);
                bd.autocompletar("select CodigoVino from Vinos", "CodigoVino", 1, TextboxCodigo);
                bd.autocompletar("select RestauranteVino from Vinos", "RestauranteVino", 1, textBoxRestaurante);
                bd.autocompletar("select NacionalidadVino from Vinos", "NacionalidadVino", 1, textBoxNacionalidad);
                bd.autocompletar("select PrecioUnitarioVino from Vinos", "PrecioUnitarioVino", 1, textBoxPrecio);
            }   
           if (tabla == 7)
            {
                bd.autocompletar("select NombrePlatilloEspecial from Especiales", "NombrePlatilloEspecial", 1, TextboxNombre);
                bd.autocompletar("select CodigoEspecial from Especiales", "CodigoEspecial", 1, TextboxCodigo);
            }
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
            //selector
            if (tabla == 1)
            {
                FrmAgregarBuffet frm = new FrmAgregarBuffet();
                frm.privilegios(rols);
                frm.Show();
            }
            if (tabla == 2)
            {
                FrmAgregarBebidaCaliente frm = new FrmAgregarBebidaCaliente();
                frm.privilegios(rols);
                frm.Show();
            }
            if (tabla == 3)
            {
                FrmAgregarBebidaHelada frm = new FrmAgregarBebidaHelada();
                frm.privilegios(rols);
                frm.Show();
            }
            if (tabla == 4)
            {
                FrmAgregarBebidaGaseosa frm = new FrmAgregarBebidaGaseosa();
                frm.privilegios(rols);
                frm.Show();
            }
            if (tabla == 5)
            {
                FrmAgregarLicor frm = new FrmAgregarLicor();
                frm.privilegios(rols);
                frm.Show();
            }
            if (tabla == 6)
            {
                FrmAgregarVinos frm = new FrmAgregarVinos();
                frm.privilegios(rols);
                frm.Show();
            }
            if (tabla == 7)
            {
                FrmAgregarEspecial frm = new FrmAgregarEspecial();
                frm.privilegios(rols);
                frm.Show();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            Querys clogiga = new Querys();
            //Otro que debe ser mejorado
            if (dataGridView1.SelectedRows.Count == 0)
            {
                CustomMessageBox.ShowMessage("Error al eliminar no ha seleccionado una fila\n\nConsejo: \n• Haga click en el simbolo  ►  que esta en la tabla para \nseleccionar la fila y poder eliminarla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) 
            {
                if (tabla == 1)
                {
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete Buffet WHERE CodigoBuffet='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("SELECT CodigoBuffet, NombreBuffet, PrecioBuffet , TipoComidaBuffet, UnidadMedidaBuffet FROM Buffet");
                    Bitacora("Se Elimino un Buffet", "Eliminar Buffet");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
                }
                if (tabla == 2)
                {
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete BebidaCalientes WHERE CodigoBebida='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("SELECT CodigoBebida, NombreBebida, PrecioBebida , RestauranteBebida FROM BebidaCalientes");
                    Bitacora("Se Elimino una BebidaCalientes", "Eliminar BebidaCalientes");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
                }
                if (tabla == 3)
                {
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete BebidaHeladas WHERE CodigoBebida='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("SELECT CodigoBebida, NombreBebida, PrecioBebida , RestauranteBebida FROM BebidaHeladas");
                    Bitacora("Se Elimino una BebidaHeladas", "Eliminar BebidaHeladas");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
                }
                if (tabla == 4)
                {
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete BebidaGaseosas WHERE CodigoBebida='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("SELECT CodigoBebida, NombreBebida, PrecioBebida FROM BebidaGaseosas");
                    Bitacora("Se Elimino una BebidaGaseosas", "Eliminar BebidaGaseosas");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
                }
                if (tabla == 5)
                {
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete Licores WHERE CodigoLicor='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("select CodigoLicor,NombreLicor,CantidadLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor from Licores");
                    Bitacora("Se Elimino un Licores", "Eliminar Licores");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
                }
                if (tabla == 6)
                {   
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete Vinos WHERE CodigoVino='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("Select CodigoVino,NombreVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino from Vinos");
                    Bitacora("Se Elimino un Vino", "Eliminar Vinos");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
                }
                if (tabla == 7)
                {   
                    string id = row.Cells[0].Value.ToString();
                    bd.executecommand("delete Especiales WHERE CodigoEspecial='" + clogiga.encriptacion(id) + "'");
                    actualizarDataGrid("select CodigoEspecial,NombrePlatilloEspecial,IngredientesEspecial,PrecioEspecial,DetalleEspecial from Especiales");
                    Bitacora("Se Elimino un Especial", "Eliminar Especiales");
                    CustomMessageBox.ShowMessage("Se ha elimando correctamente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autocompletar();
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
