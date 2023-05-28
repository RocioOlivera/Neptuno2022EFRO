using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using Neptuno2022EF.Entidades.Entidades;
using NuevaAppComercial2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Datos.Interfaces
{
    public interface IRepositorioDetalleVentas
    {
        void Agregar(DetalleVenta detalle);
        void Borrar(int id);
        void Editar(DetalleVenta detalle);
        bool EstaRelacionado(DetalleVenta detalle);
        bool Existe(DetalleVenta detalle);
        DetalleVenta GetDetalleVentaPorId(int id);
        List<DetalleVentaListDto> GetDetalleVentas(int ventaId);

    }
}
