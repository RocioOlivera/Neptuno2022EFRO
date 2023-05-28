using Neptuno2022EF.Entidades.Dtos.Ciudad;
using Neptuno2022EF.Entidades.Entidades;
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
    public partial class frmSeleccionarPaisCiudad : Form
    {
        public frmSeleccionarPaisCiudad()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmSeleccionarPaisCiudad_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult= DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            //if (cboCiudades.SelectedIndex==0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(cboCiudades, "Debe selccionar una ciudad");
            //}

            return valido;
        }

        private Pais paisSeleccionado;
        private CiudadListDto ciudadSeleccionada;
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

        public Pais GetPais()
        {
            return paisSeleccionado;
        }

        public CiudadListDto GetCiudad()
        {
            return ciudadSeleccionada;
        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiudades.SelectedIndex==0)
            {
                ciudadSeleccionada = null;
            }
            else
            {
                ciudadSeleccionada = (CiudadListDto)cboCiudades.SelectedItem;
            }
        }
    }
}
