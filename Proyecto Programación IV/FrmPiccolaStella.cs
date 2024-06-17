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
using System.IO;
using System.Drawing.Imaging;

namespace Proyecto_Programación_IV
{
    public partial class FrmPiccolaStella : Form
    {
        string[] rols = new string[6];
        private byte[] _foto;

        public byte[] foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public FrmPiccolaStella()
        {
            InitializeComponent();
            panelMesas.Visible = false;
            panelReserva.Visible = false;
            panelCliente.Visible = false;
            panelProductos.Visible = false;
            buttonSillaBarra1.Visible = false;
            buttonSillaBarra2.Visible = false;
            reservacionesEstado();
            /* buttonSeguridad.Enabled = false;
             buttonRestaurante.Enabled = false;
             buttonProveedor.Enabled = false;
             buttonAdmin.Enabled = false;
             buttonCliente.Enabled = false;
             buttonReport.Enabled = false;*/
            iniciarMesasOcupada();


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

        //metodo de comprobacion de las mesas
        public void iniciarMesasOcupada()
        {
            for (int i = 0; i <= 23; i++)
            {
                string valor = i.ToString();
                MesasOcupada(valor);
            }
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
                FrmLogin frm = new FrmLogin();
                Bitacora("Cerro Sesion", "Cerrar sesion");
                frm.Show();
                this.Close();
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCierreCajaRestaurante frm = new FrmCierreCajaRestaurante();
            Bitacora("Salir de la App Restaurante", "Salio de la App Restaurante");
            frm.privilegios(rols);
            this.Close();
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
            FrmCierreCajaRestaurante frm = new FrmCierreCajaRestaurante();
            Bitacora("Salir de la App Restaurante", "Salio de la App Restaurante");
            frm.privilegios(rols);
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (panelCliente.Visible == true)
            {
                panelCliente.Visible = false;
            }
            else
            {
                panelCliente.Visible = true;
                reservacionesEstado();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (panelMesas.Visible == true)
            {
                panelMesas.Visible = false;
            }
            else
            {
                panelMesas.Visible = true;
                reservacionesEstado();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmListaClientes frm = new FrmListaClientes();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (panelReserva.Visible == true)
            {
                panelReserva.Visible = false;
            }
            else
            {
                panelReserva.Visible = true;
                reservacionesEstado();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeguridad frm = new FrmSeguridad();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panelProductos.Visible == true)
            {
                panelProductos.Visible = false;
            }
            else
            {
                panelProductos.Visible = true;
                llenarGrid();
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

            if (!string.IsNullOrEmpty(cadena[0]))
            {
                if (cadena[0].Equals("Administrador Seguridad"))
                {
                    buttonMesa1.Enabled = true;
                    buttonProductos.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[1]))
            {
                if (cadena[1].Equals("Administrador Sistema"))
                {
                    buttonMesas.Enabled = true;
                    buttonReservaciones.Enabled = true;
                    buttonClientes.Enabled = true;
                    //buttonCliente.Enabled = true;
                    buttonProductos.Enabled = true;
                }
            }
            if (!string.IsNullOrEmpty(cadena[2]))
            {
                if (cadena[2].Equals("Administrador Restaurante"))
                {
                    if (cadena[3].Equals("note7"))
                    {

                    }
                }
            }
            if (!string.IsNullOrEmpty(cadena[4]))
            {
                if (cadena[4].Equals("Administrador Cuentas"))
                {

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            contextMenuStripClientes.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void buttonCerrarPanelMesas_Click(object sender, EventArgs e)
        {
            panelMesas.Visible = false;
        }

        private void buttonCerrarRserva_Click(object sender, EventArgs e)
        {
            panelReserva.Visible = false;
        }

        private void buttonCerrarCliente_Click(object sender, EventArgs e)
        {
            panelCliente.Visible = false;
        }

        private void buttonCerrarProductos_Click(object sender, EventArgs e)
        {
            panelProductos.Visible = false;
        }

        private void llenarGrid()
        {   //TABLA CON LOS DATOS ENCRIPTADOS



            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            BaseDeDatos bd = new BaseDeDatos();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            string restaurante = clogiga.encriptacion("Piccola Stella");

            dt1 = bd.SelectDataTable("select NombreBuffet,FotoBuffet from Buffet").Copy();
            dt2 = bd.SelectDataTable("select NombrePlatilloEspecial,FotoEspecial from Especiales").Copy();
            dt3 = bd.SelectDataTable("select NombreBebida,Foto from BebidaCalientes where RestauranteBebida = '" + restaurante + "'").Copy();
            dt4 = bd.SelectDataTable("select NombreBebida,Foto from BebidaGaseosas where RestauranteBebida = '" + restaurante + "'").Copy();
            dt5 = bd.SelectDataTable("select NombreBebida,Foto from BebidaHeladas where RestauranteBebida = '" + restaurante + "'").Copy();
            dt6 = bd.SelectDataTable("select NombreLicor,FotoLicor from Licores where RestauranteLicor = '" + restaurante + "'").Copy();
            dt7 = bd.SelectDataTable("select NombreVino,FotoVino from Vinos where RestauranteVino = '" + restaurante + "'").Copy();

            modelo.Columns.Add("Productos");
            modelo.Columns.Add("Foto", typeof(byte[]));


            foreach (DataRow row in dt1.Rows)
            {
                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            foreach (DataRow row in dt2.Rows)
            {

                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            foreach (DataRow row in dt3.Rows)
            {

                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            foreach (DataRow row in dt4.Rows)
            {

                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            foreach (DataRow row in dt5.Rows)
            {

                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            foreach (DataRow row in dt6.Rows)
            {

                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            foreach (DataRow row in dt7.Rows)
            {

                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    modelo.Rows.Add(clogiga.desencriptacion(row[0].ToString()), row[1]);
                }
            }
            //MUESTRA LA TABLA MODELO QUE ES LA QUE ESTA DESECRIPTADA
            dataGridViewProductos.DataSource = modelo;
            dataGridViewProductos.Columns[0].Width = 205;
            dataGridViewProductos.Columns[1].Visible = false;

        }


        private void fotoProducto()
        {
            try
            {
                var data = (Byte[])(dataGridViewProductos.CurrentRow.Cells[1].Value);
                var stream = new MemoryStream(data);
                pictureBoxProductos.Image = Image.FromStream(stream);
            }
            catch (Exception)
            {

                CustomMessageBox.ShowMessage("Debe Seleccionar un Producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //array a imagen :*
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        private void dataGridViewProductos_MouseClick(object sender, MouseEventArgs e)
        {
            fotoProducto();
        }

        private void barra1()
        {
            if (radioButtonAbiertoBarra1.Checked)
            {
                labelEstadoBarra1.Text = "ABIERTA";
                buttonSillaBarra1.Visible = true;
            }
            else if (radioButtonCerradoBarra1.Checked)
            {
                labelEstadoBarra1.Text = "CERRADA";
                buttonSillaBarra1.Visible = false;
            }
        }

        private void barra2()
        {
            if (radioButtonAbiertoBarra2.Checked)
            {

                labelestadoBarra2.Text = "ABIERTA";
                buttonSillaBarra2.Visible = true;
            }
            else if (radioButtonCerradoBarra2.Checked)
            {
                labelestadoBarra2.Text = "CERRADA";
                buttonSillaBarra2.Visible = false;
            }
        }

        private void radioButtonAbiertoBarra1_CheckedChanged(object sender, EventArgs e)
        {
            barra1();
        }

        private void radioButtonCerradoBarra1_CheckedChanged(object sender, EventArgs e)
        {
            barra1();
        }

        private void radioButtonAbiertoBarra2_CheckedChanged(object sender, EventArgs e)
        {
            barra2();
        }

        private void radioButtonCerradoBarra2_CheckedChanged(object sender, EventArgs e)
        {
            barra2();

        }

        private void buttonMesa1_Click(object sender, EventArgs e)
        {
            if (buttonMesa1.BackColor == Color.Gray)
            {
                ocupa("1");


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2);
                frm.numMesa(1);
                frm.Show();
            }

        }

        private void reservacionesEstado()
        {
            Querys clogiga = new Querys();
            BaseDeDatos bd = new BaseDeDatos();
            string restaurante = clogiga.encriptacion("Piccola Stella");
            string fecha = clogiga.encriptacion(DateTime.Now.ToString("dd-MM-yyyy"));
            //boton Mesas
            labelTotalMesas.Text = "23";
            string MesasOcupadas = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("NO") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fecha + "' and BarraCliente is null");
            labelMesasLibres.Text = (23 - int.Parse(MesasOcupadas)).ToString();
            labelMesasOcupadas.Text = MesasOcupadas;

            //boton reservaciones
            labelTotalMesas2.Text = "23";

            string Reservar = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and BarraCliente is null");
            int sinReservar = 23 - int.Parse(Reservar);
            labelRservada.Text = Reservar;
            labelNoReservada.Text = sinReservar.ToString();
            //boton Clientes
            //mesas
            string MesasSinReservar = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("NO") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fecha + "' and BarraCliente is null");
            string MesasReservadas = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fecha + "' and BarraCliente is null");
            int totalMesas = int.Parse(MesasSinReservar) + int.Parse(MesasReservadas);
            labelMesasCliente.Text = totalMesas.ToString();

            //barra
            string BarraSinReservar = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("NO") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fecha + "' and BarraCliente is not null");
            string BarraReservadas = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fecha + "' and BarraCliente is not null");
            int totalBarra = int.Parse(BarraSinReservar) + int.Parse(BarraReservadas);
            labelBarraCliente.Text = totalBarra.ToString();

            //total
            string BarraReservadasTotal = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "' and FechaCliente = '" + fecha + "' and BarraCliente is not null");
            string MesasReservadasTotal = bd.selectstring("select Count(*) from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("SI") + "' and FechaCliente = '" + fecha + "' and BarraCliente is null");
            int totalReservacion = int.Parse(BarraReservadasTotal) + int.Parse(MesasReservadasTotal);
            labelReservacionesCliente.Text = totalReservacion.ToString();
            //

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListaClientesRestaurante frm = new FrmListaClientesRestaurante();
           frm.privilegios(rols);
           frm.Show();
        }

        public void MesasOcupada(string mesa)
        {
            Querys clogiga = new Querys();
            string restaurante = clogiga.encriptacion("Piccola Stella");
            string fecha = clogiga.encriptacion(DateTime.Now.ToString("dd-MM-yyyy"));
            BaseDeDatos bd = new BaseDeDatos();
            string MesaOcupada = bd.selectstring("select * from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("NO") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fecha + "' and NumMesa = '" + clogiga.encriptacion(mesa) + "' and BarraCliente is null");
            if (mesa.Equals("1"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa1.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("2"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa2.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("3"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa3.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("4"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa4.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("5"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa5.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("6"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa6.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("7"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa7.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("8"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa8.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("9"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa9.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("10"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {
                    buttonMesa10.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("11"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa11.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("12"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa12.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("13"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa13.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("14"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa14.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("15"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa15.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("16"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa16.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("17"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa17.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("18"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa18.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("19"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa19.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("20"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa20.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("21"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa21.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("22"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa22.BackColor = Color.Gray;
                }
            }
            if (mesa.Equals("23"))
            {
                if (!string.IsNullOrEmpty(MesaOcupada))
                {

                    buttonMesa23.BackColor = Color.Gray;
                }
            }


        }

        private void ocupa(string mesa)
        {
            BaseDeDatos bd = new BaseDeDatos();
            Querys clogiga = new Querys();
            string restaurante = clogiga.encriptacion("Piccola Stella");
            string fechaHoy = clogiga.encriptacion(DateTime.Now.ToString("dd-MM-yyyy"));
            string NumMesa = mesa;
            //desencrip
            string id = clogiga.desencriptacion(bd.selectstring("select CodigoCliente from Clientes where RestauranteCliente = '" + restaurante + "' and ReservacionCliente = '" + clogiga.encriptacion("NO") + "' and EstadoPago = '" + clogiga.encriptacion("SIN PAGAR") + "' and FechaCliente = '" + fechaHoy + "' and NumMesa = '" + clogiga.encriptacion(NumMesa) + "' and BarraCliente is null"));

            //todo encriptado
            string nombre = bd.selectstring("select NombreCompletoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string montoPago = bd.selectstring("select MontoPagadoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string tiempoMesa = bd.selectstring("select TiempoMesa from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string numMesa = bd.selectstring("select NumMesa from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla1 = bd.selectstring("select silla1Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla2 = bd.selectstring("select silla2Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla3 = bd.selectstring("select silla3Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string pedidoSilla4 = bd.selectstring("select silla4Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string reservacion = bd.selectstring("select ReservacionCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string fecha = bd.selectstring("select FechaCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string prefijo = bd.selectstring("select PrefijoCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string entrada = bd.selectstring("select HoraEntrada from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string lista = bd.selectstring("select DetalleCliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list1 = bd.selectstring("select List1Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list2 = bd.selectstring("select List2Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list3 = bd.selectstring("select List3Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string list4 = bd.selectstring("select List4Cliente from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string estado = bd.selectstring("select EstadoPago from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            string fechaReservacion = bd.selectstring("select FechaReservacion from Clientes where CodigoCliente = '" + clogiga.encriptacion(id) + "'");
            //desencrip
            string idPrefijo = string.Empty;
            if (!string.IsNullOrEmpty(prefijo))
            {
                string PrefijoDesencrip = clogiga.desencriptacion(prefijo);
                idPrefijo = PrefijoDesencrip + " " + id;
            }
            else
            {
                idPrefijo = id;
            }

            FrmAgregarClientes frm = new FrmAgregarClientes();
            frm.edicionValor = 1;
            frm.cargarCliente(lista,list1, list2, list3, list4, nombre, montoPago, fecha, reservacion, tiempoMesa, numMesa, pedidoSilla1, pedidoSilla2, pedidoSilla3, pedidoSilla4, idPrefijo, entrada, estado, fechaReservacion);
            frm.privilegios(rols);
            frm.Show();
        }

        private void buttonMesa2_Click(object sender, EventArgs e)
        {
            if (buttonMesa2.BackColor == Color.Gray) //buton mesa
            {
                ocupa("2"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(2); //mesa
                frm.Show();
            }

        }

        private void buttonMesa3_Click(object sender, EventArgs e)
        {
            if (buttonMesa3.BackColor == Color.Gray) //buton mesa
            {
                ocupa("3"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(3); //mesa
                frm.Show();
            }
        }

        private void buttonMesa4_Click(object sender, EventArgs e)
        {
            if (buttonMesa4.BackColor == Color.Gray) //buton mesa
            {
                ocupa("4"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(4); //mesa
                frm.Show();
            }
        }

        private void buttonMesa5_Click(object sender, EventArgs e)
        {
            if (buttonMesa5.BackColor == Color.Gray) //buton mesa
            {
                ocupa("5"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(5); //mesa
                frm.Show();

            }

        }

        private void buttonMesa6_Click(object sender, EventArgs e)
        {
            if (buttonMesa6.BackColor == Color.Gray) //buton mesa
            {
                ocupa("6"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(6); //mesa
                frm.Show();

            }
        }

        private void buttonMesa7_Click(object sender, EventArgs e)
        {
            if (buttonMesa7.BackColor == Color.Gray) //buton mesa
            {
                ocupa("7"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(7); //mesa
                frm.Show();
            }

        }

        private void buttonMesa8_Click(object sender, EventArgs e)
        {
            if (buttonMesa8.BackColor == Color.Gray) //buton mesa
            {
                ocupa("8"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(8); //mesa
                frm.Show();
            }

        }

        private void buttonMesa9_Click(object sender, EventArgs e)
        {
            if (buttonMesa9.BackColor == Color.Gray) //buton mesa
            {
                ocupa("9"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(9); //mesa
                frm.Show();
            }

        }

        private void buttonMesa10_Click(object sender, EventArgs e)
        {
            if (buttonMesa10.BackColor == Color.Gray) //buton mesa
            {
                ocupa("10"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(10); //mesa
                frm.Show();
            }

        }

        private void buttonMesa11_Click(object sender, EventArgs e)
        {
            if (buttonMesa11.BackColor == Color.Gray) //buton mesa
            {
                ocupa("11"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(11); //mesa
                frm.Show();
            }
        }

        private void buttonMesa12_Click(object sender, EventArgs e)
        {
            if (buttonMesa12.BackColor == Color.Gray) //buton mesa
            {
                ocupa("12"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(12); //mesa
                frm.Show();
            }
        }

        private void buttonMesa13_Click(object sender, EventArgs e)
        {
            if (buttonMesa13.BackColor == Color.Gray) //buton mesa
            {
                ocupa("13"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(13); //mesa
                frm.Show();
            }
        }

        private void buttonMesa14_Click(object sender, EventArgs e)
        {
            if (buttonMesa14.BackColor == Color.Gray) //buton mesa
            {
                ocupa("14"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(14); //mesa
                frm.Show();
            }
        }

        private void buttonMesa15_Click(object sender, EventArgs e)
        {
            if (buttonMesa15.BackColor == Color.Gray) //buton mesa
            {
                ocupa("15"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(15); //mesa
                frm.Show();
            }
        }

        private void buttonMesa16_Click(object sender, EventArgs e)
        {
            if (buttonMesa16.BackColor == Color.Gray) //buton mesa
            {
                ocupa("16"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(16); //mesa
                frm.Show();
            }
        }

        private void buttonMesa17_Click(object sender, EventArgs e)
        {
            if (buttonMesa17.BackColor == Color.Gray) //buton mesa
            {
                ocupa("17"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(17); //mesa
                frm.Show();
            }
        }

        private void buttonMesa18_Click(object sender, EventArgs e)
        {
            if (buttonMesa18.BackColor == Color.Gray) //buton mesa
            {
                ocupa("18"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(18); //mesa
                frm.Show();
            }
        }

        private void buttonMesa19_Click(object sender, EventArgs e)
        {
            if (buttonMesa19.BackColor == Color.Gray) //buton mesa
            {
                ocupa("19"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(19); //mesa
                frm.Show();
            }
        }

        private void buttonMesa20_Click(object sender, EventArgs e)
        {
            if (buttonMesa20.BackColor == Color.Gray) //buton mesa
            {
                ocupa("20"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(20); //mesa
                frm.Show();
            }
        }

        private void buttonMesa21_Click(object sender, EventArgs e)
        {
            if (buttonMesa21.BackColor == Color.Gray) //buton mesa
            {
                ocupa("21"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(4); //sillas
                frm.numMesa(21); //mesa
                frm.Show();
            }
        }

        private void buttonMesa22_Click(object sender, EventArgs e)
        {
            if (buttonMesa22.BackColor == Color.Gray) //buton mesa
            {
                ocupa("22"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(22); //mesa
                frm.Show();
            }

        }

        private void buttonMesa23_Click(object sender, EventArgs e)
        {
            if (buttonMesa23.BackColor == Color.Gray) //buton mesa
            {
                ocupa("23"); //mesa


            }
            else
            {
                FrmAgregarClientes frm = new FrmAgregarClientes();
                frm.privilegios(rols);
                frm.sillas(2); //sillas
                frm.numMesa(23); //mesa
                frm.Show();
            }
        }

        private void buttonSillaBarra1_Click(object sender, EventArgs e)
        {
            FrmListaClientesBarra frm = new FrmListaClientesBarra();
            frm.privilegios(rols);
            frm.Show();
        }

        private void buttonSillaBarra2_Click(object sender, EventArgs e)
        {
            FrmListaClientesBarra frm = new FrmListaClientesBarra();
            frm.privilegios(rols);
            frm.Show();
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.privilegiosNoInicio(rols);
            frm.Show();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            panelProductos.Visible = false;
            panelCliente.Visible = false;
            panelReserva.Visible = false;
            panelMesas.Visible = false;
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.privilegiosNoInicio(rols); 
            frm.Show();
        }



    }
}
