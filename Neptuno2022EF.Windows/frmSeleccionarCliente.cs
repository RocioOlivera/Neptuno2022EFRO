using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Dtos.Venta;
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
    public partial class frmSeleccionarCliente : Form
    {
        public frmSeleccionarCliente()
        {
            InitializeComponent();
        }
        private ClienteListDto clienteSeleccionado;

        public ClienteListDto GetCliente()
        {
            return clienteSeleccionado;
        }
        private void frmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            Helpers.CombosHelper.CargarComboClientes(ref cboCliente);
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
                clienteSeleccionado = (ClienteListDto)cboCliente.SelectedItem;
            }
            else
            {
                clienteSeleccionado = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboCliente.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCliente, "Debe seleccionar un cliente");
            }
            return valido;
        }
    }
}
