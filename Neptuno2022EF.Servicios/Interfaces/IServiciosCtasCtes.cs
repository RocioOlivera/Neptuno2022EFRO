using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Servicios.Interfaces
{
    public interface IServiciosCtasCtes
    {
        List<CtaCteListDto> GetCtasCtes();
        List<DetalleCtaCteListDto> GetDetalleCtasCtes(int clienteId);
        void Guardar(CtaCte ctaCte);
        decimal GetSaldo(int clienteId);
        void Agregar(CtaCte ctaCte);
        CtaCte GetCtaCtePorId(int id);
    }
}
