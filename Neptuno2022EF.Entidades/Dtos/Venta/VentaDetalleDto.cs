using Neptuno2022EF.Entidades.Dtos.DetalleVenta;
using System.Collections.Generic;

namespace Neptuno2022EF.Entidades.Dtos.Venta
{
    public class VentaDetalleDto
    {
        public VentaListDto venta { get; set; }
        public List<DetalleVentaListDto> detalleVenta { get; set; }
    }
}
