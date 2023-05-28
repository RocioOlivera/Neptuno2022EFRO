using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Dtos.Producto;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Classes;
using Neptuno2022EF.Windows.Helpers;
using NuevaAppComercial2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmVentaAE : Form
    {
        private readonly IServiciosClientes _servicioCliente;
        private readonly IServiciosProductos _servicioProductos;
        private Venta venta;
        public frmVentaAE(IServiciosClientes servicioCliente, IServiciosProductos servicioProductos)
        {
            InitializeComponent();
            _servicioCliente = servicioCliente;
            _servicioProductos = servicioProductos;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboClientes(ref cboClientes);
            CombosHelper.CargarComboCategorias(ref cboCategorias);
        }
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            ActualizarUnidadesDisponibles();
            DialogResult = DialogResult.Cancel;
        }

        private void ActualizarUnidadesDisponibles()
        {

        }

        private Cliente cliente;
        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex > 0)
            {
                var clienteDto = (ClienteListDto)cboClientes.SelectedItem;
                cliente = _servicioCliente.GetClientePorId(clienteDto.ClienteId);
                MostrarDatosCliente();
            }
            else
            {
                LimpiarDatosCliente();
                cliente = null;
            }
        }

        private void LimpiarDatosCliente()
        {
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtPais.Clear();
            txtCodigoPostal.Clear();
        }

        private void MostrarDatosCliente()
        {
            txtDireccion.Text = cliente.Direccion;
            txtCiudad.Text = cliente.Ciudad.NombreCiudad;
            txtPais.Text = cliente.Pais.NombrePais;
            txtCodigoPostal.Text = cliente.CodPostal;
        }
        Categoria categoria;
        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedIndex > 0)
            {
                categoria = (Categoria)cboCategorias.SelectedItem;
                CombosHelper.CargarComboProductos(ref cboProducto, categoria);
            }
            else
            {
                cboProducto.DataSource = null;
                categoria = null;
            }
        }
        ProductoListDto producto;
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                producto = (ProductoListDto)cboProducto.SelectedItem;
                MostarDatosProducto();
            }
            else
            {
                producto = null;
                LimpiarDatosProducto();
            }
        }

        private void LimpiarDatosProducto()
        {
            txtStock.Clear();
            txtPrecioUnit.Clear();
            txtPrecioTotal.Clear();
            nudCantidad.Value = 0;
            nudCantidad.Maximum = 0;
            nudCantidad.Enabled = false;
        }

        private void MostarDatosProducto()
        {
            txtStock.Text = producto.UnidadesDisponibles.ToString();
            txtPrecioUnit.Text = producto.PrecioUnitario.ToString();
            if (producto.UnidadesDisponibles > 0)
            {
                nudCantidad.Enabled = true;
                nudCantidad.Maximum = producto.UnidadesDisponibles;
            }
            else
            {
                nudCantidad.Enabled = false;
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0 && nudCantidad.Value <= producto.UnidadesDisponibles)
            {
                txtPrecioTotal.Text = ((decimal)nudCantidad.Value * producto.PrecioUnitario).ToString();
            }
            else
            {
                txtPrecioTotal.Text = "0";
            }

        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            cboCategorias.SelectedIndex = 0;
            cboProducto.DataSource = null;
            LimpiarDatosProducto();
        }

        private void btnAceptarProducto_Click(object sender, EventArgs e)
        {
            if (ValidarProductoComprado())
            {
                //Creo un instancia de item de carrito
                //y le asigno sus valores
                var itemCarrito = new ItemCarrito()
                {
                    ProductoId = producto.ProductoId,
                    Descripcion = producto.NombreProducto,
                    Precio = producto.PrecioUnitario,
                    Cantidad = (int)nudCantidad.Value

                };
                Carrito.GetInstancia().Agregar(itemCarrito);
                
                _servicioProductos.ActualizarUnidadesEnPedido(itemCarrito.ProductoId, itemCarrito.Cantidad);
                FormHelper.MostrarDatosEnGrilla<ItemCarrito>(dgvDatos, Carrito.GetInstancia().GetItems());
                MessageBox.Show("Producto agregado", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            txtTotalVenta.Text = Carrito.GetInstancia().GetTotal().ToString();
        }

        private bool ValidarProductoComprado()
        {
            bool validar = true;
            if (nudCantidad.Value == 0)
            {
                validar = false;
                errorProvider1.SetError(nudCantidad, "Debe llevar al menos uno!!!");
            }
            return validar;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarVenta())
            {
                List<DetalleVenta> detalle = new List<DetalleVenta>();
                foreach (var item in Carrito.GetInstancia().GetItems())
                {
                    var detalleVta = new DetalleVenta()
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.Precio
                    };
                    detalle.Add(detalleVta);
                }
                venta = new Venta()
                {
                    ClienteId = cliente.Id,
                    FechaVenta = dtpFechaVenta.Value,
                    Total = Carrito.GetInstancia().GetTotal(),
                    Estado=Estado.Impaga,
                    Detalles = detalle
                };

                Carrito.GetInstancia().LimpiarCarrito();

                DialogResult=DialogResult.OK;
            }
        }

        private bool ValidarVenta()
        {
            bool validarVenta = true;
            errorProvider1.Clear();
            if (cboClientes.SelectedIndex == 0)
            {
                validarVenta = false;
                errorProvider1.SetError(cboClientes, "Debe seleccionar un cliente");

            }
            if (Carrito.GetInstancia().GetCantidad() == 0)
            {
                validarVenta = false;
                errorProvider1.SetError(cboProducto, "Debe comprar al menos un producto");
            }
            return validarVenta;
        }

        public Venta GetVenta()
        {
            return venta;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DialogResult dr = MessageBox.Show("¿Desea eliminar del pedido el item seleccionado?", "Pregunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                var r = dgvDatos.SelectedRows[0];
                var item = (ItemCarrito)r.Tag;
                Carrito.GetInstancia().QuitarItem(item);
                MessageBox.Show("Item eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTotal();
            }

        }
    }
}
