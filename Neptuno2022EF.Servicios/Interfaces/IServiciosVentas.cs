using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Entidades.Enums;
using System;
using System.Collections.Generic;

namespace Neptuno2022EF.Servicios.Interfaces
{
    public interface IServiciosVentas
    {
        List<VentaListDto> GetVentas();
        List<VentaListDto> GetVentas(int clienteId);
        List<VentaListDto> Filtrar(Func<Venta, bool> predicado, int cantidad, int pagina);
        int GetCantidad();
        List<VentaListDto> GetVentasPorPagina(int cantidad, int pagina);
        int GetCantidad(Func<Venta, bool> predicado);

        List<DetalleVentaListDto> GetDetalleVenta(int ventaId);

        void Guardar(Venta venta);
        //List<VentaListDto> FiltrarFecha(DateTime fechaSeleccionada);
        List<VentaListDto> FiltrarFecha(Func<Venta, bool>predicado, int cantidad, int pagina);
        void Pagar(Venta venta, FormaPago forma, decimal importe);
        void Editar(Venta venta);
        Venta GetVentaPorId(int id);
        void CambiarEstado(Venta venta);
    }
}
