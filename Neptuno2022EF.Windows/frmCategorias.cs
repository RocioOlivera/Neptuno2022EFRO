using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmCategorias : Form
    {
        public frmCategorias(IServiciosCategorias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private List<Categoria> lista;
        private readonly IServiciosCategorias _servicio;

        private int cantidadPorPagina = 20;
        private int registros;
        private int paginas;
        private int paginaActual = 1;


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriaAE frm = new frmCategoriaAE(_servicio) { Text = "Agregar Categoría" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();

        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            //GridHelper.LimpiarGrilla(dgvDatos);
            //foreach (Categoria categoria in lista)
            //{
            //    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
            //    GridHelper.SetearFila(r, categoria);
            //    GridHelper.AgregarFila(dgvDatos, r);
            //}
            FormHelper.MostrarDatosEnGrilla<Categoria>(dgvDatos, lista);
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
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
                Categoria categoria = (Categoria)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Confirma la baja de {categoria.NombreCategoria}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (!_servicio.EstaRelacionado(categoria))
                {
                    _servicio.Borrar(categoria.CategoriaId);
                    GridHelper.BorrarFila(dgvDatos, r);
                    MessageBox.Show("Registro borrado satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro relacionado",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                RecargarGrilla();

            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            frmCategoriaAE frm = new frmCategoriaAE(_servicio) { Text = "Editar Categoria" };
            frm.SetCategoria(categoria);
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();

        }

        private void RecargarGrilla()
        {
            try
            {
                registros = _servicio.GetCantidad();
                paginas = CalculosHelper.CalcularCantidadPaginas(registros, cantidadPorPagina);
                MostrarPaginado();
                //lista = _servicio.GetCategoriaes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetCategoriasPorPagina(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            MostrarPaginado();
        }

    }
}
