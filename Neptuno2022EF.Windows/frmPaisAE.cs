using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using System;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmPaisAE : Form
    {
        private readonly IServiciosPaises _servicio;
        private bool esEdicion=false;
        public frmPaisAE(IServiciosPaises servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Pais pais;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                txtNombrePais.Text = pais.NombrePais;
                esEdicion = true;
            }
        }
        public Pais GetPais()
        {
            return pais;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new Pais();
                }
                pais.NombrePais=txtNombrePais.Text;
                try
                {
                    
                    if (!_servicio.Existe(pais))
                    {
                        _servicio.Guardar(pais);

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
                                pais = null;
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
                        errorProvider1.SetError(txtNombrePais, "Pais existente!!!");

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
            txtNombrePais.Clear();
            txtNombrePais.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombrePais.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombrePais, "El País es requerido!!!");
            }
            return valido;
        }

        public void SetPais(Pais pais)
        {
            this.pais = pais;
        }
    }
}
