using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Proyecto_Programación_IV
{
    public partial class FrmAyudaSistema : Form
    {
        int pag = 0;
        private int linesPrinted;
        private string[] lines;
        public FrmAyudaSistema()
        {
            InitializeComponent();

        }
       
           
        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            int t = pag + 1;
            if (t != 6)
            {
                tipoAyuda(t);
                pag += 1;
            }
            t = 0;
            
            
        }
  
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
         
        }
        //print
        private void OnBeginPrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };

            if (printDialog1.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                lines = richTextBox1.SelectedText.Split(param);
            }
            else
            {
                lines = richTextBox1.Text.Split(param);
            }

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        // OnPrintPage
        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(richTextBox1.ForeColor);

            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                    richTextBox1.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }
        //end print


        public void titulo(int valor)
        {
          
            if (valor == 1)
            {
                lblTitulo.Text = "Ayuda Sistemas";
                richTextBox1.Text = "Este reporte deberá mencionar todas las actividades que el usuario con permisos de sistema realiza, para esto deberán mostrar dichas actividades en la caja de texto que se muestra en la figura Nº 6. Para el despliegue de la información deberá ir a la sección de seguridad, de ésta manera sabrá los permisos que requiere mostrar.";
                pag = 1;
            }
            if (valor == 2)
            {
                lblTitulo.Text = "Ayuda Seguridad";
                richTextBox1.Text = "Este reporte deberá mencionar todas las actividades que el usuario con permisos de seguridad realiza, para esto deberán mostrar dichas actividades en la caja de texto que se muestra en la figura Nº 7. Para el despliegue de la información deberá ir a la sección de seguridad, de ésta manera sabrá los permisos que requiere mostrar.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Lock_96;
                pag = 2;
            }
            if (valor == 3)
            {
                lblTitulo.Text = "Ayuda Restaurante";
                richTextBox1.Text = "Este reporte deberá mencionar todas las actividades que realizan los restaurantes, esta información dependerá del tipo de restaurante, para esto deberá mostrar las actividades en la caja de texto que se muestra en la figura Nº 8.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Restaurant_96;
                pag = 3;
            }
            if (valor == 4)
            {
                lblTitulo.Text = "Ayuda Licores";
                richTextBox1.Text = "Para los 3 restaurantes se manejan todas las clases y tipos de licores, desde el ADVOCAAT, hasta el WHISKY, de esta manera, cada vez que se presiona el botón hacia adelante o hacia atrás, se deberá mostrar el tipo de licor que se desea consultar, para esto deberá mostrar las información en la caja de texto que se muestra en la figura Nº 9.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Wine_Bottle_96;
                pag = 4;
            }
            if (valor == 5)
            {
                lblTitulo.Text = "Ayuda Vinos";
                richTextBox1.Text = "Para los 3 restaurantes se manejan todas las clases y tipos de vinos, desde los vinos espumosos secos, hasta los vinos rosados, además deberá aparecer cuales de ellos son buenos acompañantes para el almuerzo, la cena o el postre, de esta manera, cada vez que se presiona el botón hacia adelante o hacia atrás, se deberá mostrar el tipo de licor que se desea consultar, para esto deberá mostrar las información en la caja de texto que se muestra en la figura Nº 10.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Wine_Glass_96;
                pag = 5;
            }
        }

        public void tipoAyuda(int valor)
        {
            if (valor == 1)
            {
                lblTitulo.Text = "Ayuda Sistemas";
                richTextBox1.Text = "Este reporte deberá mencionar todas las actividades que el usuario con permisos de sistema realiza, para esto deberán mostrar dichas actividades en la caja de texto que se muestra en la figura Nº 6. Para el despliegue de la información deberá ir a la sección de seguridad, de ésta manera sabrá los permisos que requiere mostrar.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Warning_Shield_96;
           
            }
            if (valor == 2)
            {
                lblTitulo.Text = "Ayuda Seguridad";
                richTextBox1.Text = "Este reporte deberá mencionar todas las actividades que el usuario con permisos de seguridad realiza, para esto deberán mostrar dichas actividades en la caja de texto que se muestra en la figura Nº 7. Para el despliegue de la información deberá ir a la sección de seguridad, de ésta manera sabrá los permisos que requiere mostrar.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Lock_96;
            }
            if (valor == 3)
            {
                lblTitulo.Text = "Ayuda Restaurante";
                richTextBox1.Text = "Este reporte deberá mencionar todas las actividades que realizan los restaurantes, esta información dependerá del tipo de restaurante, para esto deberá mostrar las actividades en la caja de texto que se muestra en la figura Nº 8.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Restaurant_96;
            }
            if (valor == 4)
            {
                lblTitulo.Text = "Ayuda Licores";
                richTextBox1.Text = richTextBox1.Text = "Para los 3 restaurantes se manejan todas las clases y tipos de licores, desde el ADVOCAAT, hasta el WHISKY, de esta manera, cada vez que se presiona el botón hacia adelante o hacia atrás, se deberá mostrar el tipo de licor que se desea consultar, para esto deberá mostrar las información en la caja de texto que se muestra en la figura Nº 9.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Wine_Bottle_96;
            }
            if (valor == 5)
            {
                lblTitulo.Text = "Ayuda Vinos";
                richTextBox1.Text = "Para los 3 restaurantes se manejan todas las clases y tipos de vinos, desde los vinos espumosos secos, hasta los vinos rosados, además deberá aparecer cuales de ellos son buenos acompañantes para el almuerzo, la cena o el postre, de esta manera, cada vez que se presiona el botón hacia adelante o hacia atrás, se deberá mostrar el tipo de licor que se desea consultar, para esto deberá mostrar las información en la caja de texto que se muestra en la figura Nº 10.";
                pictureBox1.Image = Proyecto_Programación_IV.Properties.Resources.Wine_Glass_96;  
            }
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
            int t = pag - 1;
            if (t != 0)
            {
                tipoAyuda(t);
                pag -= 1;
            }
            t = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonVistImprimir_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }




    }
        

 }

