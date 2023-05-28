using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using NuevaAppComercial2022.Entidades.Entidades;
using System;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmClienteAE : Form
    {
        private readonly IServiciosClientes _servicio;
        public frmClienteAE(IServiciosClientes servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Cliente cliente;
        bool esEdicion=false;

        public Cliente GetCliente()
        {
            return cliente;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (cliente!=null)
            {
                esEdicion = true;
                CombosHelper.CargarComboCiudades(ref cboCiudades, cliente.Pais);
                txtCliente.Text = cliente.Nombre;
                txtDireccion.Text = cliente.Direccion;
                txtFijo.Text = cliente.TelefonoFijo;
                txtCelular.Text = cliente.TelefonoMovil;
                txtCodPostal.Text = cliente.CodPostal;
                cboPaises.SelectedValue = cliente.PaisId;

                cboCiudades.SelectedValue = cliente.CiudadId;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }
        private Pais paisSeleccionado;
        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex>0)
            {
                paisSeleccionado=(Pais)cboPaises.SelectedItem;
                CombosHelper.CargarComboCiudades(ref cboCiudades, paisSeleccionado);
            }
            else
            {
                paisSeleccionado=null;
                cboCiudades.DataSource = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente==null)
                {
                    cliente = new Cliente();
                }
                cliente.Nombre = txtCliente.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.TelefonoFijo = txtFijo.Text;
                cliente.TelefonoMovil = txtCelular.Text;
                cliente.CodPostal = txtCodPostal.Text;

                cliente.PaisId = (int)cboPaises.SelectedValue;
                cliente.CiudadId = (int)cboCiudades.SelectedValue;

                try
                {

                    if (!_servicio.Existe(cliente))
                    {
                        _servicio.Guardar(cliente);

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
                            cliente = null;
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
                        errorProvider1.SetError(txtCliente, "Cliente existente!!!");

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
            txtCliente.Clear();
            txtDireccion.Clear();
            txtCodPostal.Clear();
            txtCelular.Clear();
            txtFijo.Clear();
            cboCiudades.Items.Clear();
            cboPaises.SelectedIndex = 0;
            txtCliente.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return true;
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }
    }
}
