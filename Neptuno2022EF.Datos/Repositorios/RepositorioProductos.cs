using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Entidades.Dtos.Producto;
using Neptuno2022EF.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Datos.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly NeptunoDbContext _context;
        public RepositorioProductos(NeptunoDbContext context)
        {
            _context = context;
        }

        public void ActualizarStock(int productoId, int cantidad)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == productoId);
            productoInDb.UnidadesEnPedido -= cantidad;
            productoInDb.Stock-=cantidad;
            _context.Entry(productoInDb).State = EntityState.Modified;

        }

        public void ActualizarUnidadesEnPedido(int productoId, int cantidad)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == productoId);
            productoInDb.UnidadesEnPedido += cantidad;
            _context.Entry(productoInDb).State = EntityState.Modified;
        }

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
        }

        public void Borrar(int id)
        {
            var productoInDb=_context.Productos.SingleOrDefault(p=>p.ProductoId == id);
            if (productoInDb==null)
            {
                throw new Exception("Producto borrado por otro usuario");
            }
            _context.Entry(productoInDb).State =EntityState.Deleted;
        }

        public void Editar(Producto producto)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == producto.ProductoId);
            if (productoInDb == null)
            {
                throw new Exception("Producto borrado por otro usuario");
            }
            productoInDb.NombreProducto=producto.NombreProducto;
            productoInDb.CategoriaId=producto.CategoriaId;
            productoInDb.ProveedorId=producto.ProveedorId;
            productoInDb.StockMinimo=producto.StockMinimo;
            productoInDb.Stock=producto.Stock;
            productoInDb.StockMinimo=producto.StockMinimo;
            productoInDb.PrecioUnitario=producto.PrecioUnitario;
            productoInDb.Imagen=producto.Imagen;
            productoInDb.Suspendido=producto.Suspendido;
        }

        public bool EstaRelacionado(Producto producto)
        {
            return false;
        }

        public bool Existe(Producto producto)
        {
            if (producto.ProductoId==0)
            {
                return _context.Productos.Any(p => p.NombreProducto == producto.NombreProducto &&
                p.CategoriaId == producto.CategoriaId);
            }
            return _context.Productos.Any(p => p.NombreProducto == producto.NombreProducto &&
                p.CategoriaId == producto.CategoriaId && p.ProductoId!=producto.ProductoId);

        }

        public List<ProductoListDto> Filtrar(Func<Producto, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public Producto GetProductoPorId(int id)
        {
            return _context.Productos.Include(p=>p.Categoria)
                .Include(p=>p.Proveedor).SingleOrDefault(p=>p.ProductoId==id);
        }

        public List<ProductoListDto> GetProductos()
        {
            return _context.Productos.Include(p=>p.Categoria)
                .Select(p=>new ProductoListDto()
                {
                    ProductoId=p.ProductoId,
                    NombreProducto=p.NombreProducto,
                    Categoria=p.Categoria.NombreCategoria,
                    PrecioUnitario=p.PrecioUnitario,
                    UnidadesDisponibles=p.Stock-p.UnidadesEnPedido,
                    Suspendido=p.Suspendido,
                }).ToList();
        }

        public List<ProductoListDto> GetProductos(int categoriaId)
        {
            return _context.Productos.Include(p => p.Categoria)
                .Where(p=>p.CategoriaId==categoriaId)
                .Select(p => new ProductoListDto()
                {
                    ProductoId = p.ProductoId,
                    NombreProducto = p.NombreProducto,
                    Categoria = p.Categoria.NombreCategoria,
                    PrecioUnitario = p.PrecioUnitario,
                    UnidadesDisponibles = p.Stock-p.UnidadesEnPedido,
                    Suspendido = p.Suspendido,
                }).ToList();

        }
    }
}
