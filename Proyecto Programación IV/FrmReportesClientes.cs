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
    public partial class FrmReportesClientes : Form
    {
  
        BaseDeDatos bd = new BaseDeDatos();
        string[] rols = new string[6];
        int cantidad = 0;
        public FrmReportesClientes()
        {
            InitializeComponent();
            


            
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
         
               
                modelo.Columns.Add("Codigo");
                modelo.Columns.Add("Nombre");
                modelo.Columns.Add("Monto Pagado");
                modelo.Columns.Add("Detalle");
                modelo.Columns.Add("Fecha");
                modelo.Columns.Add("Reservacion");
                modelo.Columns.Add("Barra");
                modelo.Columns.Add("Restaurante");

            foreach (DataRow row in dt.Rows)
            {
                if (string.IsNullOrEmpty(row[6].ToString()) && !string.IsNullOrEmpty(row[8].ToString()) && !string.IsNullOrEmpty(row[5].ToString()))
                {
                  
                    modelo.Rows.Add(clogiga.desencriptacion(row[8].ToString()) +""+clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), row[6].ToString(), clogiga.desencriptacion(row[7].ToString()));
                }
                if (!string.IsNullOrEmpty(row[6].ToString()) && string.IsNullOrEmpty(row[8].ToString()) && !string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add(row[8].ToString()+""+clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()));
                }
                if (!string.IsNullOrEmpty(row[6].ToString()) && !string.IsNullOrEmpty(row[8].ToString()) && !string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[8].ToString()) + "" + clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()));
                }

                if (string.IsNullOrEmpty(row[6].ToString()) && string.IsNullOrEmpty(row[8].ToString()) && !string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add( row[8].ToString()+""+clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), clogiga.desencriptacion(row[5].ToString()), row[6].ToString(), clogiga.desencriptacion(row[7].ToString()));
                }


                if (string.IsNullOrEmpty(row[6].ToString()) && !string.IsNullOrEmpty(row[8].ToString()) && string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[8].ToString()) + "" + clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), row[5].ToString(), row[6].ToString(), clogiga.desencriptacion(row[7].ToString()));
                }
                if (!string.IsNullOrEmpty(row[6].ToString()) && string.IsNullOrEmpty(row[8].ToString()) && string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add(row[8].ToString() + "" + clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), row[5].ToString(), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()));
                }
                if (!string.IsNullOrEmpty(row[6].ToString()) && !string.IsNullOrEmpty(row[8].ToString()) && string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[8].ToString()) + "" + clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), row[5].ToString(), clogiga.desencriptacion(row[6].ToString()), clogiga.desencriptacion(row[7].ToString()));
                }
                
                if (string.IsNullOrEmpty(row[6].ToString()) && string.IsNullOrEmpty(row[8].ToString()) && string.IsNullOrEmpty(row[5].ToString()))
                {
                    modelo.Rows.Add(row[8].ToString()+""+clogiga.desencriptacion(row[0].ToString()), clogiga.desencriptacion(row[1].ToString()), clogiga.desencriptacion(row[2].ToString()), clogiga.desencriptacion(row[3].ToString()), clogiga.desencriptacion(row[4].ToString()), row[5].ToString(), row[6].ToString(), clogiga.desencriptacion(row[7].ToString()));
                }

                
            }
            //cuenta
            cantidad = int.Parse(bd.selectstring("select count(*) from clientes"));
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
            actualizarDataGrid("select CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,FechaReservacion, BarraCliente,RestauranteCliente, PrefijoCliente from clientes");       
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
            print.Title = "Lista de Clientes";
            print.SubTitle = "Fecha: " + DateTime.Now.ToString("dd-MM-yyyy") + "   Hora: " + DateTime.Now.ToString("HH:mm:ss") + "   Cantidad Clientes: " + cantidad ;
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
