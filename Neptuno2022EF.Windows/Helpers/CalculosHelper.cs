using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Windows.Helpers
{
    public static class CalculosHelper
    {
        public static int CalcularCantidadPaginas(int registros, int cantidadPorPagina)
        {
            if (registros <cantidadPorPagina)
            {
                return 1;
            }else if (registros % cantidadPorPagina != 0) {
            
                return registros / cantidadPorPagina +1;
            }else { return registros / (cantidadPorPagina); }
        }
    }
}
