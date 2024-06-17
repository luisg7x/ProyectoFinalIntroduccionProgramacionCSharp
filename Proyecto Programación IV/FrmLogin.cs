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



namespace Proyecto_Programación_IV
{
    public partial class FrmLogin : Form
    {
        string[] privilegios = new string[7];
        public FrmLogin()
        {
            InitializeComponent();
   
        }

        private Querys cLogica_BD;
        private void login()
        {
            
            if (string.IsNullOrEmpty(privilegios[5]))
            {
                CustomMessageBox.ShowMessage("Datos Incorrectos", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(privilegios[2]))
            {
                if (privilegios[2].Equals("Administrador Restaurante"))
                {

                    Bitacora("Iniciar Sesíon", "Iniciar Sesíon");
                        FrmAperturaCajaRestaurante frm = new FrmAperturaCajaRestaurante();
                        frm.privilegios(privilegios);
                        this.Hide();
                        return;
                  
                  
                }
            }
            Bitacora("Iniciar Sesíon", "Iniciar Sesíon");
            FrmPrincipal frm1 = new FrmPrincipal();
            frm1.privilegios(privilegios);
            frm1.Show();
            frm1.obtengo_Usuario(cLogica_BD.usuario);
            this.Hide();
        }


        private void textBoxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cLogica_BD = new Querys();
                cLogica_BD.usuario = textBoxUsuario.Text;
                cLogica_BD.contraseña = textBoxContraseña.Text;
                privilegios = cLogica_BD.autenticar();
                login();
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            
            cLogica_BD = new Querys();
            cLogica_BD.usuario = textBoxUsuario.Text;
            cLogica_BD.contraseña = textBoxContraseña.Text;
            privilegios = cLogica_BD.autenticar();
            login();
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
        }

        private void buttonCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Bitacora(string descripcion, string detalle)
        {
            Querys cLogica_BD = new Querys();

            cLogica_BD.fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            cLogica_BD.usuario = textBoxUsuario.Text;
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
