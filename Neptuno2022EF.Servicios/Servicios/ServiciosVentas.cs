﻿using Neptuno2022EF.Datos;
using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using Neptuno2022EF.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Neptuno2022EF.Servicios.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        private readonly IRepositorioVentas _repositorio;
        private readonly IRepositorioDetalleVentas _repoDetalleVentas;
        private readonly IRepositorioProductos _repoProductos;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosVentas(IRepositorioVentas repositorio,
            IRepositorioDetalleVentas repoDetalleVentas,
            IRepositorioProductos repoProductos,
            IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _repoDetalleVentas = repoDetalleVentas;
            _repoProductos = repoProductos;
            _unitOfWork = unitOfWork;
        }

        public int GetCantidad()
        {
            return _repositorio.GetCantidad();
        }

        public List<DetalleVentaListDto> GetDetalleVenta(int ventaId)
        {
            try
            {
                return _repoDetalleVentas.GetDetalleVentas(ventaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VentaListDto> GetVentasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetVentasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VentaListDto> GetVentas()
        {
            try
            {
                return _repositorio.GetVentas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Venta venta)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    var ventaGuardar = new Venta()
                    {
                        ClienteId = venta.ClienteId,
                        FechaVenta = venta.FechaVenta,
                        Total = venta.Total
                    };
                    _repositorio.Agregar(ventaGuardar);
                    _unitOfWork.SaveChanges();
                    foreach (var item in venta.Detalles)
                    {
                        item.VentaId = ventaGuardar.VentaId;
                        _repoDetalleVentas.Agregar(item);
                        _repoProductos.ActualizarStock(item.ProductoId, item.Cantidad);
                    }
                    _unitOfWork.SaveChanges();
                    transaction.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<VentaListDto> GetFechas()
        //{
        //    try
        //    {
        //        return _repositorio.GetFechas();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<VentaListDto> Filtrar(Func<Venta, bool> predicado, int cantidad, int pagina)
        {
            try
            {
                return _repositorio.Filtrar(predicado, cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int GetCantidad(Func<Venta, bool> predicado)
        {
            try
            {
                return _repositorio.GetCantidad(predicado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VentaListDto> GetVentas(int clienteId)
        {
            try
            {
                return _repositorio.GetVentas(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Pagar(Venta venta, FormaPago forma, decimal importe)
        {
    
            
            //venta.Estado = Estado.Paga;
            //_repositorio.Editar(venta);
            //var saldo = _repoCtasCtes.GetSaldo(venta.ClienteId);//consulto el saldo del cliente

            ////Creo la clase ctacte y le paso los datos
            //var ctaCte = new CtaCte
            //{
            //    FechaMovimiento = DateTime.Now,
            //    ClienteId = venta.ClienteId,
            //    Debe = 0,
            //    Haber = importe,
            //    Saldo = saldo - importe,
            //    Movimiento = ConstruirMovimiento(venta, forma)

            //};
            //_repoCtasCtes.Agregar(ctaCte);

        }
        public List<VentaListDto> FiltrarFecha(DateTime fechaSeleccionada)
        {
            return _repositorio.FiltrarFecha(fechaSeleccionada);
        }
    }
}
