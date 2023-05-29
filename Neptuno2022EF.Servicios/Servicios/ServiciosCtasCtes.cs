using Neptuno2022EF.Datos;
using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosCtasCtes(IRepositorioCtasCtes repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio= repositorio;
            _unitOfWork = unitOfWork;
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
