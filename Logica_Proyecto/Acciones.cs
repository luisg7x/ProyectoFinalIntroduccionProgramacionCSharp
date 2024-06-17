using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Logica_Proyecto
{
    public class Acciones
    {
        #region propiedades
        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        #endregion

        #region Metodos
        public void limpiar(Form f)
        {
            foreach (Control c in f.Controls)
            {
                if (c is Panel || c is GroupBox)
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2 is TextBox)
                        {
                            c2.Text = String.Empty;
                        }
                    }
                }
            }

        }



        #endregion

        #region constructor
        public Acciones()
        {
            _fecha= DateTime.Now;
        }
        #endregion
    }
}
