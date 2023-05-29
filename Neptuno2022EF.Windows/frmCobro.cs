using Microsoft.VisualBasic;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Windows.Helpers;
using Neptuno2022EF.Windows.Helpers.Enum;
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
    public partial class frmCobro : Form
    {
        public frmCobro()
        {
            InitializeComponent();
        }
        private decimal monto;
        private decimal importe;
        private FormaPago formaPago = 0;

        public void SetMonto(decimal monto)
        {
            this.monto = monto;
        }
        private void btnOk_Click(object sender, EventArgs e)
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
            if (formaPago == 0)
            {
                valido = false;
                errorProvider1.SetError(lblImporte, "Debe seleccionar una forma de pago");
            }

            return valido;
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            formaPago = FormaPago.Efectivo;
            var importeText = Interaction.InputBox("Ingrese el importe", "Pago en Efectivo", "0", 800, 400);
            decimal importeRecibido;
            if (!decimal.TryParse(importeText, out importeRecibido))
            {
                return;
            }
            else if (importeRecibido <= 0)
            {
                MessageHelper.Mensaje(TipoMensaje.Error, "Importe inferior a lo que se debe pagar", "Error");
                return;
            }

            lblImporteRecibido.Text = importeRecibido.ToString("N2");
            if (importeRecibido >= monto)
            {
                importe = monto;
                lblVuelto.Text = (importeRecibido - monto).ToString("N2");

            }
            else
            {
                importe = importeRecibido;
            }
        }

        public FormaPago GetFormaDePago()
        {
            return formaPago;
        }

        public decimal GetImportePagado()
        {
            return importe;
        }
        private void btnVisa_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lblImporte_Click(object sender, EventArgs e)
        {

        }
    }
}
