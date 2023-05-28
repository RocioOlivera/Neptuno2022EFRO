using Neptuno2022EF.Datos;
using Neptuno2022EF.Datos.Repositorios;
using Neptuno2022EF.Entidades.Dtos.Producto;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace Neptuno2022EF.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        private readonly RepositorioProductos _repositorio;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosProductos(RepositorioProductos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public void ActualizarUnidadesEnPedido(int productoId, int cantidad)
        {
            try
            {
                _repositorio.ActualizarUnidadesEnPedido(productoId, cantidad);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Borrar(int id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            try
            {
                return _repositorio.EstaRelacionado(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                return _repositorio.Existe(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductoListDto> Filtrar(Func<Producto, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public Producto GetProductoPorId(int id)
        {
            try
            {
                return _repositorio.GetProductoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductoListDto> GetProductos()
        {
            try
            {
                return _repositorio.GetProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<ProductoListDto> GetProductos(int categoriaId)
        {
            try
            {
                return _repositorio.GetProductos(categoriaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Producto producto)
        {
            try
            {
                if (producto.ProductoId==0)
                {
                    _repositorio.Agregar(producto);
                }
                else
                {
                    _repositorio.Editar(producto);
                }
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
