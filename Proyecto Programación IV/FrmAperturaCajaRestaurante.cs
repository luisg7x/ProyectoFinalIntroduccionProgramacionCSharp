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
    public partial class FrmAperturaCajaRestaurante : Form
    {

        string[] rols = new string[6];
        public FrmAperturaCajaRestaurante()
        {
            InitializeComponent();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Bitacora("No abrio CAJA", "No abrio CAJA");
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCerrar_Click_1(object sender, EventArgs e)
        {
            Bitacora("No abrio CAJA", "No abrio CAJA");
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
                    FrmNottediFuoco frm = new FrmNottediFuoco();
                    frm.privilegios(rols);
                    frm.Show();
                    this.Close();
                }
                if (rols[3].Equals("Turin Anivo"))
                {
                    agregar();
                    FrmTurinAnivo frm = new FrmTurinAnivo();
                    frm.privilegios(rols);
                    frm.Show();
                    this.Close();
                }
                if (rols[3].Equals("Piccola Stella"))
                {
                    agregar();
                    FrmPiccolaStella frm = new FrmPiccolaStella();
                    frm.privilegios(rols);
                    frm.Show();
                    this.Close();

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
                cLogica_BD.descripcion = "Apertura Caja";
                cLogica_BD.entrada = maskedTextBoxMonto.Text;
                cLogica_BD.montoApertura = maskedTextBoxMonto.Text;
                cLogica_BD.montoCierre = "-";
                cLogica_BD.restaurante = rols[3];


                if (cLogica_BD.agregar_CajaRestaurante() == true)
                {
                    Bitacora("Abrio Caja de " + textBoxRestaurante.Text, "Abrio Caja");
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
            rols[5] = cadena[6];

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
