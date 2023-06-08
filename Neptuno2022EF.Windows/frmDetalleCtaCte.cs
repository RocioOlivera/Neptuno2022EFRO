using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using Neptuno2022EF.Windows.Helpers.Enum;
using NuevaAppComercial2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmDetalleCtaCte : Form
    {
        private readonly IServiciosVentas _servicioVentas;
        private readonly IServiciosCtasCtes _servicioCtasCtes;
        private readonly IRepositorioCtasCtes _repoCtaCte;
        private readonly IRepositorioVentas _repositorioVentas;
        List<DetalleCtaCteListDto> lista;
        List<CtaCte> listaCta;
        private DetalleCtaCteListDto detalle;
        private Cliente cliente;
        private Venta venta;
        public frmDetalleCtaCte(IServiciosCtasCtes servicioCtasCtes)
        {
            InitializeComponent();
            _servicioCtasCtes= servicioCtasCtes;
            //_repositorioVentas= repositorioVentas;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (lista != null)
            {
                
                if (lista.Count > 0)
                {

                    FormHelper.MostrarDatosEnGrilla<DetalleCtaCteListDto>(dgvDatos, lista);
                    
                }
            }
        }

        public void SetCtaCte(List<DetalleCtaCteListDto> ctaCteDetalleDto)
        {
            lista = ctaCteDetalleDto;
        }

        private void frmDetalleCtaCte_Load(object sender, EventArgs e)
        {
            txtSaldoTotal.Text = lista.Sum(x => x.Debe - x.Haber).ToString();
        }

        private void btnIngresarPago_Click(object sender, EventArgs e)
        {

            frmCobro frm = new frmCobro(_servicioCtasCtes, _servicioVentas );
            frm.Text = "Ingreso de Pago";
            frm.SetMonto(decimal.Parse(txtSaldoTotal.Text));
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                FormaPago forma = frm.GetFormaDePago();
                decimal importeRecibido = frm.GetImportePagado();
                //_servicioVentas.Pagar(venta, forma, importeRecibido);
                MessageHelper.Mensaje(TipoMensaje.OK, "Pago efectuado!!!", "Operación Exitosa");
                FormHelper.MostrarDatosEnGrilla(dgvDatos, lista);
                //PagarIconButton.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageHelper.Mensaje(TipoMensaje.Error, exception.Message, "ERROR");
                //PagarIconButton.Enabled = false;
            }

            var ctaCte = frm.GetMovimientoCtaCte();
            //try
            //{
            //    _repoCtaCte.Agregar(ctaCte);
            //    DataGridViewRow r = new DataGridViewRow();
            //    r.CreateCells(dgvDatos);
            //    GridHelper.SetearFila(r, ctaCte);
            //    GridHelper.AgregarFila(dgvDatos, r);
            //    txtSaldoTotal.Text = _repoCtaCte.GetSaldo(venta.ClienteId).ToString("C");

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}

