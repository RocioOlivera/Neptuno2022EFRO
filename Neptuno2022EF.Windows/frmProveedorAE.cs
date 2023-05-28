using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmProveedorAE : Form
    {
        public frmProveedorAE(IServiciosProveedores servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private readonly IServiciosProveedores _servicio;
        private Proveedor proveedor;
        bool esEdicion = false;

        public Proveedor GetProveedor()
        {
            return proveedor;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (proveedor != null)
            {
                esEdicion = true;
                CombosHelper.CargarComboCiudades(ref cboCiudades, proveedor.Pais);
                txtProveedor.Text = proveedor.Nombre;
                txtDireccion.Text = proveedor.Direccion;
                txtCodPostal.Text = proveedor.CodPostal;
                cboPaises.SelectedValue = proveedor.PaisId;

                cboCiudades.SelectedValue = proveedor.CiudadId;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private Pais paisSeleccionado;
        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex > 0)
            {
                paisSeleccionado = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarComboCiudades(ref cboCiudades, paisSeleccionado);
            }
            else
            {
                paisSeleccionado = null;
                cboCiudades.DataSource = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                }
                proveedor.Nombre = txtProveedor.Text;
                proveedor.Direccion = txtDireccion.Text;
                proveedor.CodPostal = txtCodPostal.Text;

                proveedor.PaisId = (int)cboPaises.SelectedValue;
                proveedor.CiudadId = (int)cboCiudades.SelectedValue;

                try
                {

                    if (!_servicio.Existe(proveedor))
                    {
                        _servicio.Guardar(proveedor);

                        MessageBox.Show("Registro agregado satisfactoriamente", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!esEdicion)
                        {
                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                                "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;
                                return;
                            }
                            proveedor = null;
                            InicialControles();

                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtProveedor, "Proveedor existente!!!");

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al intentar agregar un registro", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void InicialControles()
        {
            txtProveedor.Clear();
            txtDireccion.Clear();
            txtCodPostal.Clear();
            cboCiudades.Items.Clear();
            cboPaises.SelectedIndex = 0;
            txtProveedor.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return true;
        }

        public void SetProveedor(Proveedor proveedor)
        {
            this.proveedor = proveedor;
        }

    }
}
