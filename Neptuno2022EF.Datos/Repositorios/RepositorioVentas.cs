using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Neptuno2022EF.Datos.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly NeptunoDbContext _context;

        public RepositorioVentas(NeptunoDbContext context)
        {
            _context = context;
        }

        public void Agregar(Venta venta)
        {
            _context.Ventas.Add(venta);
        }

        public void Editar(Venta venta)
        {
            try
            {
                var ventaInDb = GetVentaPorId(venta.VentaId);
                _context.Entry(venta).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VentaListDto> Filtrar(Func<Venta, bool> predicado, int cantidad, int pagina)
        {
            return _context.Ventas.Include(v => v.Cliente).Where(predicado).OrderBy(v => v.FechaVenta)
                                  .Skip(cantidad * (pagina - 1)).Take(cantidad).Select(v => new VentaListDto
            {
                VentaId = v.VentaId,
                FechaVenta = v.FechaVenta,
                Cliente = v.Cliente.Nombre,
                Total = v.Total,
                Estado = v.Estado.ToString(),
            }).ToList();
        }
        public int GetCantidad()
        {
            return _context.Ventas.Count();
        }
        public int GetCantidad(Func<Venta, bool> predicado)
        {
            return _context.Ventas.Count(predicado);
        }
       
        public List<VentaListDto> FiltrarFecha(Func<Venta, bool>predicado, int cantidad, int pagina)
        {
            try
            {
                return _context.Ventas.Include(v => v.Cliente).
                    Where(predicado).OrderBy(v => v.FechaVenta).Skip(cantidad * (pagina - 1)).Take(cantidad).Select(v => new VentaListDto
                    {
                        VentaId = v.VentaId,
                        FechaVenta = v.FechaVenta,
                        Cliente = v.Cliente.Nombre,
                        Total = v.Total,
                        Estado = v.Estado.ToString()
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<VentaListDto> GetVentasPorPagina(int cantidad, int pagina)
        {
            return _context.Ventas.Include(v => v.Cliente).OrderBy(v => v.ClienteId).
                Skip(cantidad * (pagina - 1)).Take(cantidad).Select
                (v => new VentaListDto
                {
                    VentaId = v.VentaId,
                    FechaVenta = v.FechaVenta,
                    Cliente = v.Cliente.Nombre,
                    Total = v.Total,
                    Estado = v.Estado.ToString()
                }).ToList();
        }
        public Venta GetVentaPorId(int id)
        {
            try
            {
                return _context.Ventas.Include(v => v.Cliente).SingleOrDefault(v => v.VentaId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VentaListDto> GetVentas()
        {
            return _context.Ventas
                .Include(v=>v.Cliente)
                .OrderBy(v=>v.FechaVenta)
                .Select(v=>new VentaListDto
                {
                    VentaId=v.VentaId,
                    FechaVenta=v.FechaVenta,
                    Cliente=v.Cliente.Nombre,
                    Total=v.Total,
                    Estado=v.Estado.ToString()
                }).ToList();
        }
        public List<VentaListDto> GetVentas(int clienteId)
        {
            try
            {
                return _context.Ventas.Include(v => v.Cliente).
                    Where(v => v.ClienteId == clienteId).Select(v => new VentaListDto
                    {
                        VentaId = v.VentaId,
                        FechaVenta = v.FechaVenta,
                        Cliente = v.Cliente.Nombre,
                        Total = v.Total,
                        Estado = v.Estado.ToString(),
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private Venta ConstruirVenta(SqlDataReader reader)
        {
            return new Venta()
            {
                VentaId = reader.GetInt32(0),
                ClienteId = reader.GetInt32(1),
                FechaVenta = reader.GetDateTime(2),
                Total = reader.GetDecimal(3),
                Estado = (Estado)reader.GetInt32(4),
                RowVersion = (byte[])reader[5]
            };
        }

        public void AnularVenta(Venta venta)
        {
            try
            {
                _context.Entry(venta).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
