
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Programación_IV
{
    public partial class FrmMessageYesNo : Form
    {

        public FrmMessageYesNo()
        {
            InitializeComponent();

            
        }

        public Image MessageIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value;  }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value;  }
        }

     

    }
}
