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
    public partial class FrmAgregarUsuarios : Form
    {
        string[] rols = new string[6];
        string codigoValor = string.Empty;
        public FrmAgregarUsuarios()
        {
            InitializeComponent();
            panelRestaurante.Visible = false;
            codigo();
            buttonPassword.Enabled = false;
            
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
            if (!Regex.IsMatch(textBoxNombre.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(textBoxPrimerApellido.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(textBoxSegundoApellido.Text, @"^[a-zA-Z]+$") || !maskedTextBoxTel1.MaskFull || !maskedTextBoxTel2.MaskFull || string.IsNullOrEmpty(textBoxUsuario.Text) || string.IsNullOrEmpty(textBoxContraseña.Text) || string.IsNullOrEmpty(textBoxContraseña2.Text)) 
            {
                if (!textBoxContraseña.Text.Equals(textBoxContraseña2.Text)) {
                    CustomMessageBox.ShowMessage("Las contraseñas son diferentes", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CustomMessageBox.ShowMessage("Posibles errores: \n• No se permiten numeros o no hay ningun valor en los campos: \n   Nombre y PrimerApellido o alguno esta vacio.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               cLogica_BD.nombre = textBoxNombre.Text;
               cLogica_BD.apellido1 = textBoxPrimerApellido.Text;
               cLogica_BD.apellido2 = textBoxSegundoApellido.Text;
               cLogica_BD.telefono = maskedTextBoxTel1.Text;
               cLogica_BD.telefono2 = maskedTextBoxTel2.Text;

               //SEGURIDAD
               if (checkBoxAdminSeguridad.Checked)
               {
                   cLogica_BD.adminSegu = "SI";
                   
               }
               else if(!checkBoxAdminSeguridad.Checked)
               {
                   cLogica_BD.adminSegu = "NO";
               }
               //RESTAURABTE
               if (checkBoxAdminRestaurante.Checked)
               {
                   cLogica_BD.adminRestau = "SI";

                   if (radioButtonPiccola.Checked)
                   {
                       cLogica_BD.restaurante = "Piccola Stella";
                   }
                   if (radioButtonTurinAnivo.Checked)
                   {
                       cLogica_BD.restaurante = "Turin Anivo";
                   }
                   if (radioButtonNotteDi.Checked) 
                   {
                       cLogica_BD.restaurante = "Notte Di Fuoco";
                   }
                   if (!radioButtonPiccola.Checked && !radioButtonTurinAnivo.Checked && !radioButtonNotteDi.Checked)
                   {
                       cLogica_BD.restaurante = "-";
                   }
               }
               else if (!checkBoxAdminRestaurante.Checked)
               {
                   cLogica_BD.adminRestau = "NO";
                   cLogica_BD.restaurante = "-";
               }
               //CUENTAS
               if (checkBoxAdminCuentas.Checked)
               {
                   cLogica_BD.adminCuent = "SI";
               }
               else if (!checkBoxAdminCuentas.Checked)
               {
                   cLogica_BD.adminCuent = "NO";
               }
               //SISTEMA
               if (checkBoxAdminSiste.Checked)
               {
                   cLogica_BD.adminSist = "SI";
               }
               else if (!checkBoxAdminSiste.Checked)
               {
                   cLogica_BD.adminSist = "NO";
               }

               cLogica_BD.usuario = textBoxUsuario.Text;
               cLogica_BD.contraseña = textBoxContraseña.Text;
 

                if (cLogica_BD.agregar_Usuario() == true)
                {
                    Bitacora("Agrego un Usuario", "Agrego un Usuario");
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
            string[] valores = clogiga.CodigoTabla("CodigoUsuario", "Usuarios");
            codigoValor = valores[0];
            textBoxCodigo.Text = valores[1];

        }

        private void checkBoxAdminRestaurante_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdminRestaurante.Checked)
            {
                panelRestaurante.Visible = true;
            }
            else if (!checkBoxAdminRestaurante.Checked)
            {
                panelRestaurante.Visible = false;
            }
        }

        private void checkBoxCambioContra_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxCambioContra.Checked)
            {
                buttonPassword.Enabled = true;
                textBoxNombre.Enabled = false;
                textBoxPrimerApellido.Enabled = false;
                textBoxSegundoApellido.Enabled = false;
                maskedTextBoxTel1.Enabled = false;
                maskedTextBoxTel2.Enabled = false;
                checkBoxAdminCuentas.Enabled = false;
                checkBoxAdminRestaurante.Enabled = false;
                checkBoxAdminSeguridad.Enabled = false;
                checkBoxAdminSiste.Enabled = false;
                CustomMessageBox.ShowMessage("Digite su Nombre de Usuario actual y luego su nueva \ncontraseña luego presione el boton con el cantado \npara confirmar ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (!checkBoxCambioContra.Checked)
            {
                buttonPassword.Enabled = false;
                textBoxNombre.Enabled = true;
                textBoxPrimerApellido.Enabled = true;
                textBoxSegundoApellido.Enabled = true;
                maskedTextBoxTel1.Enabled = true;
                maskedTextBoxTel2.Enabled = true;
                checkBoxAdminCuentas.Enabled = true;
                checkBoxAdminRestaurante.Enabled = true;
                checkBoxAdminSeguridad.Enabled = true;
                checkBoxAdminSiste.Enabled = true;
            }
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            cambiarPass();
        }

        private void cambiarPass()
        {
            if (string.IsNullOrEmpty(textBoxUsuario.Text) || string.IsNullOrEmpty(textBoxContraseña.Text) || string.IsNullOrEmpty(textBoxContraseña2.Text))
            {
                if (!textBoxContraseña.Text.Equals(textBoxContraseña2.Text))
                {
                    CustomMessageBox.ShowMessage("Las contraseñas son diferentes", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxContraseña.Focus();
                    return;
                }
                CustomMessageBox.ShowMessage("Ingrese el nombre de usuario contraseñas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUsuario.Focus();
                return;
                
            }

            Querys cLogica_BD = new Querys();
            cLogica_BD.usuario = textBoxUsuario.Text;
            cLogica_BD.contraseña = textBoxContraseña.Text;


            if (cLogica_BD.actualizar_UsuarioPassword() == true)
            {
                Bitacora("Cambio contraseña de un Usuario", "Cambio contraseña de un Usuario");
                CustomMessageBox.ShowMessage("Contraseña actualizada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CustomMessageBox.ShowMessage("No se ha podido actualizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
