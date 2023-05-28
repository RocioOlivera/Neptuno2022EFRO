using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Ioc;
using Neptuno2022EF.Servicios.Interfaces;
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
    public partial class frmVentas : Form
    {
        private readonly IServiciosVentas _servicio;
        private List<VentaListDto> lista;
        public frmVentas(IServiciosVentas servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetVentas();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (VentaListDto cliente in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, cliente);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var ventaDto = (VentaListDto)r.Tag;
            try
            {
                ////var venta = _servicio.GetVentaConDetalle(ventaDto.VentaId);
                //frmDetalleVenta frm = new frmDetalleVenta() { Text = $"Detalle de Venta {venta.venta.VentaId}" };
                ////frm.SetVenta(venta);
                //DialogResult dr = frm.ShowDialog(this);
                var detalle = _servicio.GetDetalleVenta(ventaDto.VentaId);
                var ventaDetalleDto = new VentaDetalleDto()
                {
                    venta = ventaDto,
                    detalleVenta = detalle
                };
                frmDetalleVenta frm = new frmDetalleVenta() { Text = "Detalle de la Venta" };
                frm.SetVenta(ventaDetalleDto);
                frm.ShowDialog(this);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmVentaAE frm = new frmVentaAE(DI.Create<IServiciosClientes>(),DI.Create<IServiciosProductos>()) { Text = "Nueva Venta" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                var venta = frm.GetVenta();
                _servicio.Guardar(venta);
                MessageBox.Show("Venta guardada", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var r=GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, dgvDatos);
                GridHelper.AgregarFila(dgvDatos, r);
                venta = null;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
