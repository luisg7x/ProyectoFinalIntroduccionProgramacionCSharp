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
using System.IO;
using System.Drawing.Imaging;


namespace Proyecto_Programación_IV
{
    public partial class FrmAgregarUnidadesMedida : Form
    {
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarUnidadesMedida()
        {
            InitializeComponent();
            codigo();
            comboBoxDetalle.SelectedIndex = 0;
            comboBoxEscala.SelectedIndex = 0;
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            codigo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregar();
            Acciones clogiga = new Acciones();
            clogiga.limpiar(this);
            codigo();
        }

        private Boolean validar()
        {
            if (string.IsNullOrEmpty(textBoxUnidad.Text) || string.IsNullOrEmpty(textBoxSimbologia.Text) || comboBoxEscala.SelectedIndex == -1 || comboBoxDetalle.SelectedIndex == -1) 
            {
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en el campo: \n   Unidad  o esta vacia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void agregar()
        {

            if (validar() == false)
            {
                Querys cLogica_BD = new Querys();

                cLogica_BD.codigoValor = codigoValor;
                cLogica_BD.unidad = textBoxUnidad.Text;
                cLogica_BD.escala = comboBoxEscala.SelectedItem.ToString();
                cLogica_BD.detalle = comboBoxDetalle.SelectedItem.ToString();
                cLogica_BD.simbologia = textBoxSimbologia.Text;

                if (cLogica_BD.agregar_Unidad() == true)
                {
                    Bitacora("Agrego una Unidad de Medida", "Agrego una Unidad de Medida");
                    CustomMessageBox.ShowMessage("Datos agregados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo();
                }
                else
                {
                    CustomMessageBox.ShowMessage("No se han podido agregar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void codigo()
        {
            Querys clogiga = new Querys();
            string[] valores = clogiga.CodigoTabla("CodigoUnidad", "UnidadesMedida");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];

        }


        private void simbolo()
        {
       
            if(comboBoxEscala.SelectedItem.ToString().Equals("yotta"))
            {
                textBoxSimbolo.Text= "Y";

            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("zetta"))
            {
                textBoxSimbolo.Text= "Z";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("exa"))
            {
                textBoxSimbolo.Text= "E";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("peta"))
            {
                textBoxSimbolo.Text= "P";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("tera"))
            {
                textBoxSimbolo.Text= "T";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("giga"))
            {
                textBoxSimbolo.Text= "G";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("mega"))
            {
                textBoxSimbolo.Text= "M";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("miria"))
            {
                textBoxSimbolo.Text= "ma";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("kilo"))
            {
                textBoxSimbolo.Text= "k";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("hecto"))
            {
                textBoxSimbolo.Text= "h";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("deca"))
            {
                textBoxSimbolo.Text= "da";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("deci"))
            {
                textBoxSimbolo.Text= "d";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("centi"))
            {
                textBoxSimbolo.Text= "c";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("mili"))
            {
                textBoxSimbolo.Text= "m";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("micro"))
            {
                textBoxSimbolo.Text= "µ";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("nano"))
            {
                textBoxSimbolo.Text= "n";
            }	
            if(comboBoxEscala.SelectedItem.ToString().Equals("pico"))
            {
                textBoxSimbolo.Text= "f";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("atto"))
            {
                textBoxSimbolo.Text= "a";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("zepto"))
            {
                textBoxSimbolo.Text= "z";
            }
            if(comboBoxEscala.SelectedItem.ToString().Equals("yocto"))
            {
                textBoxSimbolo.Text= "y";
            }

           

        }

        /*private void simbologia()
        {
            try
            {
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de capacidad"))
                {
                    textBoxSimbologia.Text = "F";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de densidad"))
                {
                    //textBoxSimbologia.Text= "J"; ////////////////////////////
                    textBoxSimbologia.Text = textBoxUnidad.Text;
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de energía"))
                {
                    textBoxSimbologia.Text = "J";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de fuerza"))
                {
                    textBoxSimbologia.Text = "N";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de longitud"))
                {
                    textBoxSimbologia.Text = "m";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de masa"))
                {
                    textBoxSimbologia.Text = "g";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de peso específico"))
                {
                    ///textBoxSimbologia.Text= "p"; ////////////////////////
                    textBoxSimbologia.Text = textBoxUnidad.Text;
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de potencia"))
                {
                    textBoxSimbologia.Text = "W";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de superficie"))
                {
                    // textBoxSimbologia.Text= "km"; ////////////////////////
                    textBoxSimbologia.Text = textBoxUnidad.Text;
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de temperatura"))
                {
                    textBoxSimbologia.Text = "ºC";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de tiempo"))
                {
                    textBoxSimbologia.Text = "s";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de velocidad"))
                {
                    textBoxSimbologia.Text = "m/s ";
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de viscosidad"))
                {
                    // textBoxSimbologia.Text= "v"; ///////////////
                    textBoxSimbologia.Text = textBoxUnidad.Text;
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades de volumen"))
                {
                    // textBoxSimbologia.Text= "v"; //////////
                    textBoxSimbologia.Text = textBoxUnidad.Text;
                }
                if (comboBoxDetalle.SelectedItem.ToString().Equals("Unidades eléctricas"))
                {
                    // textBoxSimbologia.Text= "A"; ////
                    textBoxSimbologia.Text = textBoxUnidad.Text;
                }
            }
            catch (Exception)
            {
                
          
            }
           
        }*/

        private void text()
        {
            string texto = textBoxUnidad.Text.ToUpper();
            if (!string.IsNullOrEmpty(textBoxSimbolo.Text) && !string.IsNullOrEmpty(textBoxUnidad.Text))
            {
                if (texto.Equals("ACRE"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "acr";
                }
                if (texto.Equals("CENTIMETRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "cm";
                }
                if (texto.Equals("CENTÍMETRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "cm";
                }
                if (texto.Equals("CENTÍMETRO CÚBICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "cc";
                }
                if (texto.Equals("CENTIMETRO CUBICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "cc";
                }
                if (texto.Equals("CUARTO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "qt";
                }
                if (texto.Equals("GALON"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "gal";
                }
                if (texto.Equals("GALÓN"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "gal";
                }
                if (texto.Equals("GRAMO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "g";
                }
                if (texto.Equals("GRAMOS")) ///
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "g";
                }
                if (texto.Equals("HECTARIA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "ha";
                }
                if (texto.Equals("HECTÁRIA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "ha";
                }
                if (texto.Equals("HORA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "h";
                }
                if (texto.Equals("KILOMETRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "km";
                }
                if (texto.Equals("KILÓMETRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "km";
                }
                if (texto.Equals("HECTOLITRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "hL";
                }
                if (texto.Equals("KILOGRAMO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "kg";
                }
                if (texto.Equals("KILÓMETRO CUADRADO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "km2";
                }

                if (texto.Equals("KILÓMETRO CUADRADO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "km2";
                }
                if (texto.Equals("LEGUA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "legua";
                }
                if (texto.Equals("LIBRA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "lb";
                }
                if (texto.Equals("LITRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "L";
                }
                if (texto.Equals("METRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "m";
                }
                if (texto.Equals("METRO CUADRADO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "m2";
                }
                if (texto.Equals("METRO CÚBICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "m3";
                }
                if (texto.Equals("METRO CUBICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "m3";
                }
                if (texto.Equals("MICRÓN"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "μ";
                }
                if (texto.Equals("MICRON"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "μ";
                }
                if (texto.Equals("MILIGRAMO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "mg";
                }
                if (texto.Equals("MILÍMETRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "mg";
                }
                if (texto.Equals("MILIMETRO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "mm";
                }
                if (texto.Equals("MILIGRAMO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "mm";
                }
                if (texto.Equals("MILLA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "milla";
                }
                if (texto.Equals("MINUTO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "min";
                }
                if (texto.Equals("NUDO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "nudo";
                }
                if (texto.Equals("ONZA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "oz";
                }
                if (texto.Equals("ONZA LÍQUIDA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "oz fl";
                }
                if (texto.Equals("ONZA LIQUIDA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "oz fl";
                }
                if (texto.Equals("PARTE POR MILLON"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "ppm";
                }
                if (texto.Equals("PARTE POR MILLÓN"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "ppm";
                }
                if (texto.Equals("PIE"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "p";
                }
                if (texto.Equals("PIE CUADRADO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "p2";
                }
                if (texto.Equals("PIE CÚBICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "p3";
                }
                if (texto.Equals("PIE CUBICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "p3";
                }
                if (texto.Equals("PINTA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "pt";
                }
                if (texto.Equals("PORCIENTO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "%";
                }
                if (texto.Equals("PULGADA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "pulg";
                }
                if (texto.Equals("PULGADA CUADRADA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "pulg2";
                }
                if (texto.Equals("QUINTAL METRICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "qq";
                }
                if (texto.Equals("QUINTAL MÉTRICO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "qq";
                }
                if (texto.Equals("SEGUNDO"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "seg";
                }
                if (texto.Equals("TONELADA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "ton";
                }
                if (texto.Equals("YARDA"))
                {
                    textBoxSimbologia.Text = textBoxSimbolo.Text + "yarda";
                }
                
            }

        }

        private void comboBoxEscala_SelectedIndexChanged(object sender, EventArgs e)
        {
            simbolo();
            text();
        }

        private void comboBoxDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  simbologia();
        }

        private void textBoxUnidad_TextChanged(object sender, EventArgs e)
        {
            //simbologia();
            text();
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
