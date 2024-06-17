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
using System.Text.RegularExpressions;


namespace Proyecto_Programación_IV
{
    public partial class FrmCierreCajaRestaurante : Form
    {
        private Querys cLogica_BD;
        string[] rols = new string[6];
        public FrmCierreCajaRestaurante()
        {
            InitializeComponent();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            maskedTextBoxMonto.Clear();
         
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

            if (validar() == false)
            {
                if (rols[3].Equals("Notte Di Fuoco"))
                {
                    agregar();
                    Application.Exit();
                }
                if (rols[3].Equals("Turin Anivo"))
                {
                    agregar();
                    Application.Exit();
                }
                if (rols[3].Equals("Piccola Stella"))
                {
                    agregar();
                    Application.Exit();

                }
            }
       
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(maskedTextBoxMonto.Text)) 
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• Mascara incompleta.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void agregar()
        {

            if (validar() == false)
            {
                Querys cLogica_BD = new Querys();
                cLogica_BD.fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                cLogica_BD.descripcion = "Cierre Caja";
                cLogica_BD.montoCierre = maskedTextBoxMonto.Text;
                cLogica_BD.montoApertura = "-";
                cLogica_BD.restaurante = rols[3];

                BaseDeDatos bd = new BaseDeDatos();
                DataTable dt = new DataTable();
                string fecha = cLogica_BD.encriptacion(DateTime.Now.ToString("dd-MM-yyyy"));
                //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
                DataTable modelo = new DataTable();
                //LENA LA TABLA DT CON LOS DATOS
                dt = bd.SelectDataTable("select MontoPagadoCliente from Clientes where FechaCliente = '" + fecha + "' and EstadoPago = '" + cLogica_BD.encriptacion("PAGADO") + "'").Copy();
                //LOS 2 FOREACH PASAN Y CONVIERTEN LA INFORMACION DESENCRIPTADA A LA TABLA MODELO
                int precio = 0;
                foreach (DataRow row in dt.Rows)
                {

                    precio = 0 + int.Parse(cLogica_BD.desencriptacion(row[0].ToString()));

                }

                cLogica_BD.entrada = precio.ToString();


                if (cLogica_BD.agregar_CajaRestaurante() == true)
                {
                    Bitacora("Cerro Caja", "Cerro Caja");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            if (!string.IsNullOrEmpty(cadena[2]))
            {
                if (cadena[2].Equals("Administrador Restaurante"))
                {
                    if (cadena[3].Equals("Notte Di Fuoco"))
                    {
                        textBoxRestaurante.Text = "Notte Di Fuoco";
                        this.Show();
                    }
                    if (cadena[3].Equals("Turin Anivo"))
                    {
                        textBoxRestaurante.Text = "Turin Anivo";
                        this.Show();
                    }
                    if (cadena[3].Equals("Piccola Stella"))
                    {
                        textBoxRestaurante.Text = "Piccola Stella";
                        this.Show();
                    }
                    
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


    }
}
