using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using System;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmCategoriaAE : Form
    {
        public frmCategoriaAE(IServiciosCategorias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private readonly IServiciosCategorias _servicio;
        private bool esEdicion = false;
        private Categoria categoria;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                esEdicion = true;
            }
        }
        public Categoria GetCategoria()
        {
            return categoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }
                categoria.NombreCategoria = txtCategoria.Text;
                try
                {

                    if (!_servicio.Existe(categoria))
                    {
                        _servicio.Guardar(categoria);

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
                            categoria = null;
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
                        errorProvider1.SetError(txtCategoria, "Categoria existente!!!");

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
            errorProvider1.Clear();
            txtCategoria.Clear();
            txtCategoria.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "El País es requerido!!!");
            }
            return valido;
        }

        public void SetCategoria(Categoria categoria)
        {
            this.categoria = categoria;
        }

    }
}
