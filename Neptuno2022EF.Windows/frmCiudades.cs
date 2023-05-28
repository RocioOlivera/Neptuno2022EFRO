using Neptuno2022EF.Entidades.Dtos.Ciudad;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _servicio;

        private int cantidadPorPagina = 5;
        private int registros;
        private int paginas;
        private int paginaActual = 1;

        private bool filtroOn=false;
        public frmCiudades(IServiciosCiudades servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<CiudadListDto> lista;

        private void MostrarDatosEnGrilla()
        {
            //GridHelper.LimpiarGrilla(dgvDatos);
            //foreach (CiudadListDto ciudad in lista)
            //{
            //    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
            //    GridHelper.SetearFila(r, ciudad);
            //    GridHelper.AgregarFila(dgvDatos,r);
            //}
            FormHelper.MostrarDatosEnGrilla<CiudadListDto>(dgvDatos, lista);
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();

        }



        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCiudadAE frm = new frmCiudadAE(_servicio) { Text = "Agregar Ciudad" };
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
                CiudadListDto ciudadDto = (CiudadListDto)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Confirma la baja de {ciudadDto.NombreCiudad}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                var ciudad = _servicio.GetCiudadPorId(ciudadDto.CiudadId);
                if (ciudad == null)
                {
                    MessageBox.Show("Registro dado de baja por otro usuario", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RecargarGrilla();
                    return;
                }
                if (!_servicio.EstaRelacionada(ciudad))
                {
                    _servicio.Borrar(ciudad.CiudadId);
                    //GridHelper.BorrarFila(dgvDatos, r);
                    RecargarGrilla();
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


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            CiudadListDto ciudadDto = (CiudadListDto)r.Tag;
            var ciudad = _servicio.GetCiudadPorId(ciudadDto.CiudadId);
            if (ciudad==null)
            {
                MessageBox.Show("Registro dado de baja por otro usuario");
                RecargarGrilla();
                return;

            }
            frmCiudadAE frm = new frmCiudadAE(_servicio) { Text = "Editar Ciudad" };
            frm.SetCiudad(ciudad);
            RecargarGrilla();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            RecargarGrilla();

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
                //lista = _servicio.GetCiudades();
                //MostrarDatosEnGrilla();
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
                lista = _servicio.Filtrar(predicado,cantidadPorPagina, paginaActual);
            }
            else
            {
                lista = _servicio.GetCiudadesPorPagina(cantidadPorPagina, paginaActual);

            }
            MostrarDatosEnGrilla();
        }
        Func<Ciudad, bool> predicado;
        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarPais frm = new frmSeleccionarPais() { Text = "Seleccionar..." };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var paisSeleccionado = frm.GetPais();
                predicado = c => c.PaisId == paisSeleccionado.PaisId;
                //lista = _servicio.Filtrar(predicado);
                //lista = _servicio.GetCiudades(paisSeleccionado.PaisId);
                //MostrarDatosEnGrilla();
                filtroOn = true;
                RecargarGrilla();
                tsbFiltrar.BackColor = Color.Orange;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroOn=false;
            RecargarGrilla();
            tsbFiltrar.BackColor = Color.White;

        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
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
