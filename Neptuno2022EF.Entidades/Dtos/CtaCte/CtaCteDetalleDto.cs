using Neptuno2022EF.Entidades.Entidades;
using NuevaAppComercial2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Entidades.Dtos.CtaCte
{
    public class DetalleCtaCteListDto
    {
        public DateTime FechaMovimiento { get; set; }
        public string Movimiento { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public CtaCteListDto ctaCteListDto { get; set; }

        public Persona cliente;

    }
}
