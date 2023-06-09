using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Dtos.Producto;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Ioc;
using Neptuno2022EF.Servicios.Interfaces;
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
    public partial class frmVentas : Form
    {
        private readonly IServiciosVentas _servicio;
        private List<VentaListDto> lista;

        private int cantidadPorPagina = 10;
        private int registros;
        private int paginas;
        private int paginaActual = 1;

        private bool filtroOn = false;
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
            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            FormHelper.MostrarDatosEnGrilla<VentaListDto>(dgvDatos, lista);
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
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
            frmVentaAE frm = new frmVentaAE(DI.Create<IServiciosClientes>(), DI.Create<IServiciosProductos>()) { Text = "Nueva Venta" };
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
                RecargarGrilla();
                venta = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RecargarGrilla()
        {
            try
            {
                if (filtroOn)
                {
                    registros = _servicio.GetCantidad(predicado);
                }
                else
                {
                    registros = _servicio.GetCantidad();

                }

                paginas = CalculosHelper.CalcularCantidadPaginas(registros, cantidadPorPagina);
                paginaActual = 1;
                MostrarPaginado();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void RecargarGrillaFiltroFecha()
        {
            try
            {
                if (filtroOn)
                {
                    registros = _servicio.GetCantidad(predicado);
                }
                else
                {
                    registros = _servicio.GetCantidad();

                }

                paginas = CalculosHelper.CalcularCantidadPaginas(registros, cantidadPorPagina);
                paginaActual = 1;
                MostrarPaginadoFiltroFecha();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void MostrarPaginado()
        {
            if (filtroOn)
            {
                lista = _servicio.Filtrar(predicado, cantidadPorPagina, paginaActual);
            }
            else
            {
                lista = _servicio.GetVentasPorPagina(cantidadPorPagina, paginaActual);

            }
            MostrarDatosEnGrilla();

        }

        private void MostrarPaginadoFiltroFecha()
        {
            if (filtroOn)
            {
                lista = _servicio.FiltrarFecha(predicado, cantidadPorPagina, paginaActual);
            }
            else
            {
                lista = _servicio.GetVentasPorPagina(cantidadPorPagina, paginaActual);

            }
            MostrarDatosEnGrilla();

        }


        Func<Venta, bool> predicado;
        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
        }
        private void tsbFiltrarFecha_Click(object sender, EventArgs e)
        {
        }

        private void tsbFiltrar_Click_1(object sender, EventArgs e)
        {
            frmSeleccionarCliente frm = new frmSeleccionarCliente() { Text = "Seleccionar Cliente" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var clienteSeleccionado = frm.GetCliente();
                predicado = c => c.ClienteId == clienteSeleccionado.ClienteId;
                filtroOn = true;
                RecargarGrilla();
                tsbFiltrar.BackColor = Color.Orange;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbFiltrarFecha_Click_1(object sender, EventArgs e)
        {
            frmSeleccionarFecha frm = new frmSeleccionarFecha() { Text = "Seleccione fecha a filtrar" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                DateTime fechaSeleccionada = frm.GetFecha();
                predicado = v => v.FechaVenta == fechaSeleccionada.Date;
                filtroOn = true;
                RecargarGrillaFiltroFecha();
                tsbFiltrarFecha.BackColor = Color.Orange;


            }
            catch (Exception exception)
            {
                MessageHelper.Mensaje(TipoMensaje.Error, exception.Message, "ERROR");
            }
        }

        private void btnPrimero_Click_1(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();
        }

        private void btnUltimo_Click_1(object sender, EventArgs e)
        {
            paginaActual = paginas;
            MostrarPaginado();
        }

        private void tsbActualizar_Click_1(object sender, EventArgs e)
        {
            filtroOn = false;
            RecargarGrilla();
            tsbFiltrar.BackColor = Color.White;
            tsbFiltrarFecha.BackColor = Color.White;
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var ventaDto = (VentaListDto)r.Tag;
            
            if (ventaDto.Estado == Estado.Anulada || ventaDto.Estado == Estado.Paga)
            {
                return;
            }
            var venta = _servicio.GetVentaPorId(ventaDto.VentaId);
            try
            {
                venta.Estado = Estado.Anulada;
                _servicio.CambiarEstado(venta);
                GridHelper.SetearFila(r, ventaDto);
                RecargarGrilla();
                MessageHelper.Mensaje(TipoMensaje.OK, "Venta anulada correctamente", "Mensaje");
            }
            catch (Exception exception)
            {
                MessageHelper.Mensaje(TipoMensaje.Error, exception.Message, "Error");
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var ventaDto = (VentaListDto)r.Tag;
            frmCobro frm = new frmCobro() { Text = "Seleccionar método de cobro" };
            frm.SetMonto(ventaDto.Total);
            DialogResult dr = frm.ShowDialog(this);
            var venta = _servicio.GetVentaPorId(ventaDto.VentaId);
            try
            {
                venta.Estado = Estado.Paga;
                _servicio.CambiarEstado(venta);
                GridHelper.SetearFila(r, venta);
                MessageHelper.Mensaje(TipoMensaje.OK, "Venta Pagada!!!", "Mensaje");
                RecargarGrilla();
            }
            catch (Exception exception)
            {
                MessageHelper.Mensaje(TipoMensaje.Error, exception.Message, "Error");
            }
        }
    }
    
}
