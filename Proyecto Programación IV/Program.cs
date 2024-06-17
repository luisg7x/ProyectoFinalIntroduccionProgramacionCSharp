using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Programación_IV
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAgregarUsuarios());
            //FrmListaUsuarios
            //FrmLogin
            //FrmPiccolaStella
            //FrmListaProveedores
            //FrmAgregarBuffet
           // FrmListaClientesRestaurante
            
          
        }
    }
}
