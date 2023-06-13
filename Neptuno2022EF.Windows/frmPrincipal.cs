using Neptuno2022EF.Ioc;
using Neptuno2022EF.Servicios.Interfaces;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            frmPaises frm=new frmPaises(DI.Create<IServiciosPaises>());
            frm.ShowDialog();
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            frmCiudades frm=new frmCiudades(DI.Create<IServiciosCiudades>());
            frm.ShowDialog(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes(DI.Create<IServiciosClientes>());
            frm.ShowDialog(this);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frm=new frmProveedores(DI.Create<IServiciosProveedores>());
            frm.ShowDialog(this);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias frm = new frmCategorias(DI.Create<IServiciosCategorias>());
            frm.ShowDialog(this);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frm=new frmVentas(DI.Create<IServiciosVentas>(), DI.Create<IServiciosCtasCtes>());
            frm.ShowDialog(this);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm=new frmProductos(DI.Create<IServiciosProductos>());
            frm.ShowDialog(this);
        }

        private void btnCtaCte_Click(object sender, EventArgs e)
        {
            frmCtasCtes frm = new frmCtasCtes(DI.Create<IServiciosCtasCtes>(), DI.Create<IServiciosVentas>());
            frm.ShowDialog(this);
        }
    }
}
