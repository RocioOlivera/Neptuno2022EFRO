using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using System;
using System.Collections.Generic;

namespace Neptuno2022EF.Datos.Interfaces
{
    public interface IRepositorioVentas
    {
        List<VentaListDto> GetVentas();
        List<VentaListDto> GetVentas(int clienteId);
        void Agregar(Venta venta);
        List<VentaListDto> Filtrar(Func<Venta, bool> predicado, int cantidad, int pagina);
        Venta GetVentaPorId(int id);
        int GetCantidad();
        List<VentaListDto> GetVentasPorPagina(int cantidad, int pagina);

        int GetCantidad(Func<Venta, bool> predicado);
        //List<VentaListDto> FiltrarFecha(DateTime fechaSeleccionada);
        List<VentaListDto> FiltrarFecha(Func<Venta, bool> predicado, int cantidad, int pagina);
        void Editar(Venta venta);
        void AnularVenta(Venta venta);
    }
}
