using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Windows.Helpers;
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
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }
        private VentaDetalleDto ventaDto;
        public void SetVenta(VentaDetalleDto ventaDetalleDto)
        {
            ventaDto = ventaDetalleDto;
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtCliente.Text = ventaDto.venta.Cliente;
            txtFechaVenta.Text = ventaDto.venta.FechaVenta.ToShortDateString();
            txtVenta.Text=ventaDto.venta.VentaId.ToString();
            txtTotalVta.Text=ventaDto.venta.Total.ToString();
            FormHelper.MostrarDatosEnGrilla<DetalleVentaListDto>(dgvDatos, ventaDto.detalleVenta);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
