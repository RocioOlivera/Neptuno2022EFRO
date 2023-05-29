using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmSeleccionarFecha : Form
    {
        public frmSeleccionarFecha()
        {
            InitializeComponent();
        }
        private DateTime fechaSeleccionada;
        private void frmSeleccionarFecha_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                fechaSeleccionada = dtpFecha.Value.Date;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (dtpFecha.Value.Date > DateTime.Today.Date)
            {
                valido = false;
                errorProvider1.SetError(dtpFecha, "Fecha superior a la actual");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public DateTime GetFecha()
        {
            return fechaSeleccionada;
        }
    }
}
