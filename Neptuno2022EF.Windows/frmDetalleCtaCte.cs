using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Ioc;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Servicios.Servicios;
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
        private readonly IServiciosClientes _serviciosClientes;
        private readonly IServiciosCtasCtes _servicioCtasCtes;
        private readonly IRepositorioCtasCtes _repoCtaCte;
        private readonly IRepositorioVentas _repositorioVentas;
        List<DetalleCtaCteListDto> lista;
        List<CtaCte> listaCta;
        private DetalleCtaCteListDto detalle;
        private Cliente cliente;
        public frmDetalleCtaCte(IServiciosCtasCtes servicioCtasCtes, IServiciosClientes serviciosClientes)
        {
            InitializeComponent();
            _servicioCtasCtes= servicioCtasCtes;
            _serviciosClientes= serviciosClientes;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (lista != null)
            {
                
                if (lista.Count > 0)
                {
                    //txtCliente.Text = detalle.cliente.Nombre.ToString();
                    //txtDomicilio.Text = detalle.cliente.Direccion.ToString();
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

            frmCobro frm = new frmCobro(DI.Create<IServiciosCtasCtes>(),DI.Create<IServiciosClientes>(), DI.Create<IServiciosVentas>()) { Text = "Ingresar pago..." }; 
            frm.SetMonto(decimal.Parse(txtSaldoTotal.Text));
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            //var r = dgvDatos.SelectedRows[0];
            //var ctaDto = (CtaCteListDto)r.Tag;
            //_servicioCtasCtes.GetCtaCtePorId(ctaDto.CtaCteId);

            try
            {
                var ctaCte = frm.GetMovimientoCtaCte();
                _servicioCtasCtes.Guardar(ctaCte);
                MessageBox.Show("Cuenta corriente actualizada!", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormHelper.MostrarDatosEnGrilla(dgvDatos, lista);
            }
            catch (Exception)
            {

                throw;
            }

            //var ctaCte = new CtaCte
            //{
            //    FechaMovimiento = DateTime.Now,
            //    ClienteId = ctaDto.ClienteId,
            //    Debe = 0,
            //    Haber = ctaDto.Saldo,
            //    Saldo = 0,
            //    Movimiento = $"FACT {ctaDto.CtaCteId}"
            //};

            //_servicioCtasCtes.Agregar(ctaCte);
            //DialogResult = DialogResult.OK;
            //MessageHelper.Mensaje(TipoMensaje.OK, "Pago efectuado!!!", "Operación Exitosa");
            //FormHelper.MostrarDatosEnGrilla(dgvDatos, lista);
            //try
            //{
            //    decimal importeRecibido = frm.GetImportePagado();




            //    PagarIconButton.Enabled = false;
            //}
            //catch (Exception exception)
            //{
            //    MessageHelper.Mensaje(TipoMensaje.Error, exception.Message, "ERROR");
            //    PagarIconButton.Enabled = false;
            //}

            //var ctaCte = frm.GetMovimientoCtaCte();
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

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

