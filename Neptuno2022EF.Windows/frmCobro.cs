using Microsoft.VisualBasic;
using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Classes;
using Neptuno2022EF.Windows.Helpers;
using Neptuno2022EF.Windows.Helpers.Enum;
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
    public partial class frmCobro : Form
    {
        private readonly IServiciosCtasCtes _serviciosCtasCtes;
        private readonly IServiciosVentas _serviciosVentas;
        private readonly IServiciosClientes _serviciosClientes;
        
        public frmCobro(IServiciosCtasCtes serviciosCta, IServiciosClientes serviciosClientes, IServiciosVentas serviciosVentas)
        {
            InitializeComponent();
            _serviciosCtasCtes=serviciosCta;
            _serviciosClientes = serviciosClientes;
            _serviciosVentas= serviciosVentas;
        }
        private decimal monto;
        private decimal importe;
        private FormaPago formaPago;
        private int clienteId;
        
        private CtaCte ctaCte;
        private Venta venta;

        public void SetMonto(decimal monto)
        {
            this.monto = monto;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (ValidarDatos())
            //{
            //    var ctaCte = new CtaCte
            //    {
            //        FechaMovimiento = DateTime.Now,
            //        ClienteId = venta.ClienteId,
            //        Debe = monto - importe,
            //        Haber = importe,
            //        Saldo = monto - importe,
            //        Movimiento = $"PAGO EFECT. {venta.VentaId}"

            //    };

            //    _serviciosCtasCtes.Agregar(ctaCte);

            //    DialogResult = DialogResult.OK;

            //}


            //if (ValidarDatos())
            //{
            //venta.Estado = Estado.Paga;
            //_serviciosVentas.Editar(venta);

            //var saldo = _serviciosCtasCtes.GetSaldo(venta.ClienteId);//consulto el saldo del cliente



            //var saldo = _repositorioCtasCtes.GetSaldo();

            //Creo la clase ctacte y le paso los datos
            //var ctaCte = new CtaCte
            //{
            //    FechaMovimiento = DateTime.Now,
            //    ClienteId = 2,
            //    Debe = monto - importe,
            //    Haber = importe,
            //    Saldo = monto - importe,
            //    Movimiento = ConstruirMovimiento()

            //};
            //_serviciosCtasCtes.Agregar(ctaCte);
            //DialogResult = DialogResult.OK;
            //}
        }
        //private string ConstruirMovimiento()
        //{
        //    return $"PAGO ";
        //}
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (formaPago == 0)
            {
                valido = false;
                errorProvider1.SetError(lblImporte, "Debe seleccionar una forma de pago");
            }

            return valido;
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            formaPago = FormaPago.Efectivo;
            var importeText = Interaction.InputBox("Ingrese el importe", "Pago en Efectivo", "0", 800, 400);
            decimal importeRecibido;
            if (!decimal.TryParse(importeText, out importeRecibido))
            {
                return;
            }
            else if (importeRecibido <= 0 || importeRecibido < monto)
            {
                MessageHelper.Mensaje(TipoMensaje.Error, "Importe inferior a lo que se debe pagar", "Error");
                return;
            }

            lblImporteRecibido.Text = importeRecibido.ToString("N2");
            //if (importeRecibido >= monto)
            //{
            //    importe = monto;
                lblVuelto.Text = (importeRecibido - monto).ToString("N2");

            //}
            //else
            //{
            //    importe = importeRecibido;
            //}
        }

        public FormaPago GetFormaDePago()
        {
            return formaPago;
        }

        public decimal GetImportePagado()
        {
            return importe;
        }
        private void btnVisa_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblImporte_Click(object sender, EventArgs e)
        {

        }

        private void frmCobro_Load(object sender, EventArgs e)
        {
            lblImporte.Text = monto.ToString("N2");
        }

        public CtaCte GetMovimientoCtaCte()
        {
            return ctaCte;
        }
        private Cliente cliente;
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            //Venta venta=new Venta();
            //if (ValidarDatos())
            //{
            //    var ctaCte = new CtaCte
            //    {
            //        FechaMovimiento = DateTime.Now,
            //        ClienteId = venta.ClienteId,
            //        Debe = 0,
            //        Haber = venta.Total,
            //        Saldo = 0,
            //        Movimiento = $"PAGO EFECT. {venta.VentaId}"
            //    };

                //_serviciosCtasCtes.Agregar(ctaCte);

                //ctaCte = new CtaCte
                //{
                //    FechaMovimiento = DateTime.Now,
                //    ClienteId = 2,
                //    Debe = monto - importe,
                //    Haber = importe,
                //    Saldo = monto - importe,
                //    Movimiento = "PAGO EFECT."

                //};

                //_serviciosCtasCtes.Agregar(ctaCte);

                DialogResult = DialogResult.OK;
                MessageHelper.Mensaje(TipoMensaje.OK, "Venta Pagada!!!", "Mensaje");
            //}



        }

        public void SetCliente(int clienteId)
        {
            this.clienteId = clienteId;
        }
    }
}
