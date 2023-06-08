using Neptuno2022EF.Entidades.Dtos.CtaCte;
using Neptuno2022EF.Entidades.Dtos.Venta;
using Neptuno2022EF.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Datos.Interfaces
{
    public interface IRepositorioCtasCtes
    {
        List<CtaCteListDto> GetCtasCtes();
        List<DetalleCtaCteListDto> GetDetalleCtasCtes(int clienteId);
        void Agregar(CtaCte ctaCte);
        CtaCte GetCtaCtePorId(int id);
        decimal GetSaldo(int clienteId);
        //decimal GetSaldo();
    }
}
