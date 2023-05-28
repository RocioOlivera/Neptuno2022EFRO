using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Neptuno2022EF.Datos.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        private readonly NeptunoDbContext _context;

        public RepositorioPaises(NeptunoDbContext context)
        {
            _context = context;
        }


        public void Agregar(Pais pais)
        {
           
            _context.Paises.Add(pais);

           
        }

        public void Borrar(int id)
        {
            try
            {
                    var paisInDb = _context.Paises.SingleOrDefault(p => p.PaisId == id);
                    if (paisInDb == null)
                    {
                        Exception ex = new Exception("Borrado por otro usuario");
                        throw ex;
                    }
                    _context.Entry(paisInDb).State = EntityState.Deleted;
                    //_context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Pais pais)
        {
            try
            {
                 _context.Entry(pais).State=EntityState.Modified;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                    return _context.Ciudades.Any(c => c.PaisId == pais.PaisId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                    if (pais.PaisId==0)
                    {
                        return _context.Paises.Any(p => p.NombrePais == pais.NombrePais);
                    }
                    return _context.Paises.Any(p => p.NombrePais == pais.NombrePais && p.PaisId != pais.PaisId);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            return _context.Paises.Count();
        }

        public List<Pais> GetPaises()
        {
            try
            {
                    return _context.Paises
                        .OrderBy(p=>p.NombrePais)
                        .ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Pais> GetPaisesPorPagina(int cantidad, int pagina)
        {
            return _context.Paises.OrderBy(p=>p.NombrePais)
                .Skip(cantidad*(pagina-1))
                .Take(cantidad)
                .ToList();
        }

        public Pais GetPaisPorId(int paisId)
        {
            try
            {
                    var paisInDb= _context.Paises
                        .SingleOrDefault(p => p.PaisId == paisId);
                    //if (paisInDb != null) {
                    //    _context.Entry(paisInDb).Reload();
                    //}
                    return paisInDb;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
