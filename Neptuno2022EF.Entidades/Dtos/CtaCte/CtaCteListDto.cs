using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Entidades.Dtos.CtaCte
{
    public class CtaCteListDto
    {
        public int CtaCteId { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public decimal Saldo { get; set; }
    }
}
