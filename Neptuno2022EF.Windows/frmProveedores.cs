using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Dtos.Proveedor;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
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
    public partial class frmProveedores : Form
    {
        public frmProveedores(IServiciosProveedores servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private readonly IServiciosProveedores _servicio;
        private List<ProveedorListDto> lista;

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
            foreach (ProveedorListDto proveedor in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, proveedor);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedorAE frm = new frmProveedorAE(_servicio) { Text = "Agregar Proveedor" };
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
                ProveedorListDto proveedorDto = (ProveedorListDto)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Confirma la baja de {proveedorDto.NombreProveedor}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                var proveedor = _servicio.GetProveedorPorId(proveedorDto.ProveedorId);
                if (proveedor == null)
                {
                    MessageBox.Show("Registro dado de baja por otro usuario", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RecargarGrilla();
                    return;
                }
                if (!_servicio.EstaRelacionado(proveedor))
                {
                    _servicio.Borrar(proveedor.Id);
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
                lista = _servicio.GetProveedores();
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
            ProveedorListDto proveedorDto = (ProveedorListDto)r.Tag;
            var proveedor = _servicio.GetProveedorPorId(proveedorDto.ProveedorId);
            if (proveedor == null)
            {
                MessageBox.Show("Registro dado de baja por otro usuario");
                RecargarGrilla();
                return;

            }

            frmProveedorAE frm = new frmProveedorAE(_servicio) { Text = "Editar Proveedor" };
            frm.SetProveedor(proveedor);
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarPaisCiudad frm = new frmSeleccionarPaisCiudad() { Text = "Seleccionar País y Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var pais = frm.GetPais();
                var ciudad = frm.GetCiudad();
                Func<Proveedor, bool> predicado;
                if (ciudad == null)
                {
                    predicado = c => c.PaisId == pais.PaisId;
                }
                else
                {
                    predicado = c => c.PaisId == pais.PaisId && c.CiudadId == ciudad.CiudadId;
                }
                //lista = _servicio.GetClientes(pais.PaisId, ciudad.CiudadId);
                lista = _servicio.Filtrar(predicado);
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
