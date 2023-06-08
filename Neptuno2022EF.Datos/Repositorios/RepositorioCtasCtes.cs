using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Datos.Repositorios
{
    public class RepositorioCtasCtes:IRepositorioCtasCtes
    {
        private readonly NeptunoDbContext _context;

        public RepositorioCtasCtes(NeptunoDbContext context)
        {
            _context = context;
        }
        public void Agregar(CtaCte ctaCte)
        {
            _context.CtasCtes.Add(ctaCte);
        }

        public CtaCte GetCtaCtePorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteListDto> GetCtasCtes()
        {
            //return _context.CtasCtes
            //    .Include(c=>c.Cliente)
            //    .OrderBy(c => c.Cliente.Nombre)
            //    .Select(c => new CtaCteListDto
            //    {
            //        CtaCteId = c.CtaCteId,
            //        Cliente = c.Cliente.Nombre,
            //        Saldo = c.Saldo

            //    }).ToList();
            var lista = _context.CtasCtes.Include(c => c.Cliente)
                .GroupBy(c => c.Cliente.Nombre)
                .ToList();
            var registros = new List<CtaCteListDto>();
            foreach (var grupo in lista)
            {
                var itemCta = new CtaCteListDto
                {
                    ClienteId = grupo.First().ClienteId,
                    NombreCliente = grupo.Key,
                    Saldo = grupo.Sum(x => x.Debe - x.Haber)
                };
                registros.Add(itemCta);
            }
            return registros;
        }
        public List<DetalleCtaCteListDto> GetDetalleCtasCtes(int clienteId)
        {
            return _context.CtasCtes
                .Include(c => c.Cliente).Where(c=>c.ClienteId== clienteId)
                .OrderBy(c => c.FechaMovimiento)
                .Select(c => new DetalleCtaCteListDto
                {
                    FechaMovimiento = c.FechaMovimiento,
                    Movimiento = c.Movimiento,
                    Debe = c.Debe,
                    Haber = c.Haber

                }).ToList();
        }

        public decimal GetSaldo(int clienteId)
        {
            return _context.CtasCtes.Include(c => c.ClienteId).Where(c => c.ClienteId == clienteId).Max(c => c.CtaCteId);
        }

        //public decimal GetSaldo()
        //{
        //    return _context.CtasCtes.Include(c => c.ClienteId).Max(c => c.CtaCteId);
        //}
    }
}
