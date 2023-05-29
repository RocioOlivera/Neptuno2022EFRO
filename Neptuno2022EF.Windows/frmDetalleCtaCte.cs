using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Servicios.Servicios;
using Neptuno2022EF.Windows.Helpers;
using Neptuno2022EF.Windows.Helpers.Enum;
using NuevaAppComercial2022.Entidades.Entidades;
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
    public partial class frmDetalleCtaCte : Form
    {
        private readonly IServiciosVentas _servicioVentas;
        List<DetalleCtaCteListDto> lista;
        List<CtaCte> listaCta;
        private DetalleCtaCteListDto detalle;
        private Cliente cliente;
        public frmDetalleCtaCte()
        {
            InitializeComponent();
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

            //frmCobro frm = new frmCobro();
            //frm.Text = "Ingreso de Pago";
            //frm.SetMonto(decimal.Parse(txtSaldoTotal.Text));
            //DialogResult dr = frm.ShowDialog(this);
            //    if (dr == DialogResult.Cancel)
            //    {
            //        return;
            //    }else
            //    {

            //    try
            //    {
            //        FormaPago forma = frm.GetFormaDePago();
            //        decimal importeRecibido = frm.GetImportePagado();
            //        _servicioVentas.Pagar(venta, forma, importeRecibido);
            //        MessageHelper.Mensaje(TipoMensaje.OK, "Pago efectuado!!!", "Operación Exitosa");
            //        GridHelper.SetearFila(r, ctaCte);
            //        btnIngresarPago.Enabled = false;
            //    }
            //    catch (Exception exception)
            //    {
            //        MessageHelper.Mensaje(TipoMensaje.Error, exception.Message, "ERROR");
            //        btnIngresarPago.Enabled = false;
            //    }

            //    var ctaCte = frm.GetMovimientoCtaCte();
            //    try
            //    {
            //        ServiciosCtasCtes.GetInstancia().Agregar(ctaCte);
            //        DataGridViewRow r = new DataGridViewRow();
            //        r.CreateCells(dgvDatos);
            //        SetearFila(r, ctaCte);
            //        AgregarFila(r);
            //        txtSaldoTotal.Text = ServiciosCtasCtes.GetInstancia().GetSaldo(cliente).ToString("C");

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //    }
            //}
        }
    }
}

