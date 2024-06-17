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
using DGVPrinterHelper;

namespace Proyecto_Programación_IV
{
    public partial class FrmReportesFactura : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        public FrmReportesFactura()
        {
            InitializeComponent();
            


            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void actualizarDataGrid()
        {   //TABLA CON LOS DATOS ENCRIPTADOS
            DataTable dt = new DataTable();
            DataTable dtCaja = new DataTable();
            DataTable dtFactura = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS



            dt = bd.SelectDataTable("select codigocaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja from CajasRestaurante").Copy();

            string prefijoCaja = bd.selectstring("SELECT  PrefijoConsecutivo  FROM  Consecutivos where TipoConsecutivo = '" + clogiga.encriptacion("Caja") + "'");
            if (string.IsNullOrEmpty(prefijoCaja))
            {
                prefijoCaja = string.Empty;
            }
            else
            {
                prefijoCaja = clogiga.desencriptacion(prefijoCaja);
            }
            

            //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
         
              

            //
                dtCaja.Columns.Add("Codigo");
                dtCaja.Columns.Add("Fecha Registro");
                dtCaja.Columns.Add("Descripcion");
                dtCaja.Columns.Add("Entrada de Dinero");
                dtCaja.Columns.Add("Apertura de Caja");
                dtCaja.Columns.Add("Cierre de Caja");
                dtCaja.Columns.Add("Restaurante");
           
                //
                dtFactura.Columns.Add("Codigo");
                dtFactura.Columns.Add("Fecha Registro");
                dtFactura.Columns.Add("Descripcion");
                dtFactura.Columns.Add("Entrada de Dinero");
                dtFactura.Columns.Add("Apertura de Caja");
                dtFactura.Columns.Add("Cierre de Caja");
                dtFactura.Columns.Add("Restaurante");


                foreach (DataRow row in dt.Rows)
               {


                   dtCaja.Rows.Add(prefijoCaja + clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()));
                
                          
             }

                dt = bd.SelectDataTable("select CodigoFactura,FechaFactura,'Pago Cliente',MontoFactura,'','',NombreRestaurante from Facturas").Copy();

                string prefijoFactura = bd.selectstring("SELECT  PrefijoConsecutivo  FROM  Consecutivos where TipoConsecutivo = '" + clogiga.encriptacion("Facturas") + "'");
                if (string.IsNullOrEmpty(prefijoCaja))
                {
                    prefijoFactura = string.Empty;
                }
                else
                {
                    prefijoFactura = clogiga.desencriptacion(prefijoFactura);
                }
            
             foreach (DataRow row in dt.Rows)
             {


                 dtFactura.Rows.Add(prefijoFactura + clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), row[2].ToString(), clogiga.desencriptacion(row[3].ToString()), row[4].ToString(), row[5].ToString(), clogiga.desencriptacion(row[6].ToString()));
                 
             }


            modelo = dtCaja.Copy();
            modelo.Merge(dtFactura);
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridView1.DataSource = modelo;

          
        }
           


        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            
        }

     

   
        private void FrmListaRestaurantes_Load(object sender, EventArgs e)
        {
            actualizarDataGrid();       
        }

    
        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Lista de Factura";
            print.SubTitle = "Fecha: " + DateTime.Now.ToString("dd-MM-yyyy") + "   Hora: " + DateTime.Now.ToString("HH:mm:ss") ;
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Progra IV";
            print.PrintDataGridView(dataGridView1);
      
        }


        
    }
}
