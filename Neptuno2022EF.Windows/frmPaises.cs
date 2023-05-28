using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Servicios.Servicios;
using Neptuno2022EF.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmPaises : Form
    {
        private List<Pais> lista;
        private readonly IServiciosPaises _servicio;

        private int cantidadPorPagina = 20;
        private int registros;
        private int paginas;
        private int paginaActual = 1;

        public frmPaises(IServiciosPaises servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPaisAE frm = new frmPaisAE(_servicio) { Text = "Agregar País" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();

        }

        private void frmPaises_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (Pais pais in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, pais);
                GridHelper.AgregarFila(dgvDatos, r);
            }
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
                Pais pais = (Pais)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Confirma la baja de {pais.NombrePais}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (!_servicio.EstaRelacionado(pais))
                {
                    _servicio.Borrar(pais.PaisId);
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
            Pais pais = (Pais)r.Tag;
            frmPaisAE frm = new frmPaisAE(_servicio) { Text = "Editar Pais" };
            frm.SetPais(pais);
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
                //lista = _servicio.GetPaises();
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
            lista = _servicio.GetPaisPorPagina(cantidadPorPagina, paginaActual);
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
