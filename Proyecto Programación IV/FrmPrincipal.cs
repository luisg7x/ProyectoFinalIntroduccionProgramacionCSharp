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
    public partial class FrmPrincipal : Form
    {
        string[] rols = new string[6];
        public FrmPrincipal()
        {
            InitializeComponent();
            buttonSeguridad.Enabled = false;
            buttonRestaurante.Enabled = false;
            buttonProveedor.Enabled = false;
            buttonAdmin.Enabled = false;
            buttonCliente.Enabled = false;
            buttonReport.Enabled = false;
           
        
           
        }

        private Acciones cLogica_Acciones;
        private Querys cLogica_BD;

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            
        }

  

        private void timer1_Tick(object sender, EventArgs e)
        {
            cLogica_Acciones = new Acciones();
            cLogica_BD = new Querys();
            statusBar1.Panels[3].Text = cLogica_Acciones.fecha.ToString("h:mm:ss tt");
            statusBar1.Panels[2].Text = cLogica_Acciones.fecha.ToShortDateString();
            statusBar1.Panels[1].Text = "Administrador de Restaurantes";
        }

        private void sistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAyudaSistema frm = new FrmAyudaSistema();
            frm.Show();
        }
        public void obtengo_Usuario(string user)
        {
            statusBar1.Panels[0].Text = "Usuario: " + user;
        }

        private void SistemaButton_Click(object sender, EventArgs e)
        {
            //contextMenuStripMenuSistemas.Show(SistemaButton.Left + this.Left, SistemaButton.Top + SistemaButton.Height + this.Top);
            contextMenuStripMenuSistemas.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void AyudaButton_Click(object sender, EventArgs e)
        {
            //contextMenuStripAyuda.Show(AyudaButton.Left + this.Left, AyudaButton.Top + AyudaButton.Height + this.Top);
            contextMenuStripAyuda.Show(Cursor.Position.X, Cursor.Position.Y);
        
        }

        private void cerrarSesiónToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.ShowMessage("Desea cerrar sesión?", "Inicio de Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bitacora("Cerro Sesion", "Cerrar sesion");
                FrmLogin frm = new FrmLogin();
                frm.Show();
                this.Close();
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitacora("Salir total", "Salio de la App");
            Application.Exit();
        }

        private void sistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAyudaSistema frm = new FrmAyudaSistema();
            frm.titulo(1);
            frm.Show();
        }

        private void seguridadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAyudaSistema frm = new FrmAyudaSistema();
            frm.titulo(2);
            frm.Show();
        }

        private void restauranteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmAyudaSistema frm = new FrmAyudaSistema();
            frm.titulo(3);
            frm.Show();
        }

        private void licoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAyudaSistema frm = new FrmAyudaSistema();
            frm.titulo(4);
            frm.Show();
        }

        private void vinosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAyudaSistema frm = new FrmAyudaSistema();
            frm.titulo(5);
            frm.Show();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Bitacora("Salir total", "Salio de la App");
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmListaRestaurantes frm = new FrmListaRestaurantes();
            frm.privilegios(rols);
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAdministracion frm = new FrmAdministracion();
            frm.privilegios(rols);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmListaClientes frm = new FrmListaClientes();
            frm.privilegios(rols);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.privilegios(rols);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeguridad frm = new FrmSeguridad();
            frm.privilegios(rols);
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.privilegios(rols);
            frm.Show();
        }

        public void privilegiosNoInicio(string[] cadena)
        {
            rols[0] = cadena[0];
            rols[1] = cadena[1];
            rols[2] = cadena[2];
            rols[3] = cadena[3];
            rols[4] = cadena[4];
            rols[5] = cadena[5];


            if (!string.IsNullOrEmpty(cadena[0]))
            {
                if (cadena[0].Equals("Administrador Seguridad"))
                {
                    buttonSeguridad.Enabled = true;
                    buttonReport.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[1]))
            {
                if (cadena[1].Equals("Administrador Sistema"))
                {
                    buttonAdmin.Enabled = true;
                    buttonProveedor.Enabled = true;
                    buttonRestaurante.Enabled = true;
                    buttonCliente.Enabled = true;
                    buttonReport.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[2]))
            {
                if (cadena[2].Equals("Administrador Restaurante"))
                {
                    if (cadena[3].Equals("Notte Di Fuoco"))
                    {
                        buttonAdmin.Enabled = true;
                    }
                    if (cadena[3].Equals("Turin Anivo"))
                    {
                        buttonAdmin.Enabled = true;
                    }
                    if (cadena[3].Equals("Piccola Stella"))
                    {
                        buttonAdmin.Enabled = true;
                    }
                }
            }
            if (!string.IsNullOrEmpty(cadena[4]))
            {
                if (cadena[4].Equals("Administrador Cuentas"))
                {
                    buttonReport.Enabled = true;
                    buttonSeguridad.Enabled = true;
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
            

            if (!string.IsNullOrEmpty(cadena[0]))
            {
                if (cadena[0].Equals("Administrador Seguridad"))
                {
                    buttonSeguridad.Enabled = true;
                    buttonReport.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[1]))
            {
                if (cadena[1].Equals("Administrador Sistema"))
                {
                    buttonAdmin.Enabled = true;
                    buttonProveedor.Enabled = true;
                    buttonRestaurante.Enabled = true;
                    buttonCliente.Enabled = true;
                    buttonReport.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[2]))
            {
                if (cadena[2].Equals("Administrador Restaurante"))
                {
                    if (cadena[3].Equals("Notte Di Fuoco"))
                    {
                        this.Show();
                    }
                    if (cadena[3].Equals("Turin Anivo"))
                    {
                        this.Show();
                    }
                    if (cadena[3].Equals("Piccola Stella"))
                    {
                        this.Show();
                    }
                }
            }
            if (!string.IsNullOrEmpty(cadena[4]))
            {
                if (cadena[4].Equals("Administrador Cuentas"))
                {
                    buttonReport.Enabled = true;
                    buttonSeguridad.Enabled = true;
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
