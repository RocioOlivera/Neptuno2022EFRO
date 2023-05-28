using Neptuno2022EF.Entidades.Dtos.Producto;
using Neptuno2022EF.Entidades.Dtos.Proveedor;
using Neptuno2022EF.Entidades.Entidades;
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
    public partial class frmProductos : Form
    {
        public frmProductos(IServiciosProductos servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private readonly IServiciosProductos _servicio;
        private List<ProductoListDto> lista;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (ProductoListDto producto in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, producto);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProductoAE frm = new frmProductoAE(_servicio) { Text = "Agregar Producto" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                var r = dgvDatos.SelectedRows[0];
                ProductoListDto productoDto = (ProductoListDto)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Confirma la baja de {productoDto.NombreProducto}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                var producto = _servicio.GetProductoPorId(productoDto.ProductoId);
                if (producto == null)
                {
                    MessageBox.Show("Registro dado de baja por otro usuario", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RecargarGrilla();
                    return;
                }
                if (!_servicio.EstaRelacionado(producto))
                {
                    _servicio.Borrar(producto.ProductoId);
                    GridHelper.BorrarFila(dgvDatos, r);
                    MessageBox.Show("Registro borrado satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro relacionado...Baja denegada", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void RecargarGrilla()
        {
            try
            {
                lista = _servicio.GetProductos();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ProductoListDto productoDto = (ProductoListDto)r.Tag;
            var producto = _servicio.GetProductoPorId(productoDto.ProductoId);
            if (producto == null)
            {
                MessageBox.Show("Registro dado de baja por otro usuario");
                RecargarGrilla();
                return;

            }

            frmProductoAE frm = new frmProductoAE(_servicio) { Text = "Editar Producto" };
            frm.SetProducto(producto);
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarCategoria frm = new frmSeleccionarCategoria() { Text = "Seleccionar País y Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Categoria categoria = frm.GetCategoria();
                
                lista = _servicio.GetProductos(categoria.CategoriaId);
                
                MostrarDatosEnGrilla();
                tsbFiltrar.BackColor = Color.Orange;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            tsbFiltrar.BackColor = Color.White;
        }

    }
}
