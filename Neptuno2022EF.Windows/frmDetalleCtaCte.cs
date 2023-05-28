using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using Neptuno2022EF.Windows.Helpers;
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
        List<DetalleCtaCteListDto> lista;
        CtaCteListDto ctaCte;
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
                //cliente = lista[0];
                //txtCliente.Text = ctaCteList.NombreCliente.ToString();
                //txtDomicilio.Text = ctaCteList.;
                //txtLocalidad.Text = cliente.Ciudad..NombreLocalidad;
                //txtProvincia.Text = cliente.Domicilio.Provincia.NombreProvincia;

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
            //txtSaldoTotal.Text = lista. ctaCte.Saldo.ToString();
            //txtCliente.Text = ventaDto.venta.Cliente;
            //txtFechaVenta.Text = ventaDto.venta.FechaVenta.ToShortDateString();
            //txtVenta.Text = ventaDto.venta.VentaId.ToString();
            //txtTotalVta.Text = ventaDto.venta.Total.ToString();
            //FormHelper.MostrarDatosEnGrilla<DetalleVentaListDto>(dgvDatos, ventaDto.detalleVenta);
        }
    }
}
