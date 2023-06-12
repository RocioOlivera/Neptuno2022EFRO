using Neptuno2022EF.Datos;
using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using NuevaAppComercial2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Neptuno2022EF.Servicios.Servicios
{
    public class ServiciosCtasCtes :IServiciosCtasCtes
    {
        private readonly IRepositorioCtasCtes _repositorio;
        private readonly IRepositorioVentas _repositorioVentas;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosCtasCtes(IRepositorioCtasCtes repositorio, IRepositorioVentas repositorioVentas, IUnitOfWork unitOfWork)
        {
            _repositorio= repositorio;
            _repositorioVentas=repositorioVentas;
            _unitOfWork = unitOfWork;
        }

        public void Agregar(CtaCte ctaCte)
        {
            try
            {
                _repositorio.Agregar(ctaCte);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CtaCte GetCtaCtePorId(int id)
        {
            try
            {
                return _repositorio.GetCtaCtePorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CtaCteListDto> GetCtasCtes()
        {
            try
            {
                return _repositorio.GetCtasCtes();
            }
            catch (Exception)
            {

                throw;
            }
        }
     
        public List<DetalleCtaCteListDto> GetDetalleCtasCtes(int clienteId)
        {
            try
            {
                return _repositorio.GetDetalleCtasCtes(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal GetSaldo(int clienteId)
        {
            try
            {
                return _repositorio.GetSaldo(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Guardar(CtaCte ctaCte)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    var ctaCteGuardar = new CtaCte()
                    {
                        FechaMovimiento = ctaCte.FechaMovimiento,
                        Movimiento = ctaCte.Movimiento,
                        Debe = ctaCte.Debe,
                        Haber = ctaCte.Haber,
                        Saldo = ctaCte.Saldo,
                        ClienteId = ctaCte.ClienteId
                    };
                    _repositorio.Agregar(ctaCteGuardar);
                    _unitOfWork.SaveChanges();

                    transaction.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
