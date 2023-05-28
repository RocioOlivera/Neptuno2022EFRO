using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmCiudadAE : Form
    {
        private readonly IServiciosCiudades _servicio;
        private Ciudad ciudad;
        private bool esEdicion = false;
        public frmCiudadAE(IServiciosCiudades servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (ciudad != null)
            {
                txtCiudad.Text = ciudad.NombreCiudad;
                cboPaises.SelectedValue = ciudad.PaisId;
                esEdicion = true;
            }
        }
        public Ciudad GetCiudad()
        {
            return ciudad;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ciudad == null)
                {
                    ciudad = new Ciudad();
                }
                ciudad.NombreCiudad = txtCiudad.Text;
                ciudad.PaisId = (int)cboPaises.SelectedValue;
                try
                {

                    if (!_servicio.Existe(ciudad))
                    {
                        _servicio.Guardar(ciudad);

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
                            ciudad = null;
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
                        errorProvider1.SetError(txtCiudad, "Ciudad existente!!!");

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al intentar agregar un registro", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");

            }
            if (string.IsNullOrEmpty(txtCiudad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCiudad, "Nombre de la Ciudad es requerido");
            }
            return valido;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }
        private void InicialControles()
        {
            errorProvider1.Clear();
            txtCiudad.Clear();
            cboPaises.SelectedIndex = 0;
            cboPaises.Focus();
        }
    }

}
