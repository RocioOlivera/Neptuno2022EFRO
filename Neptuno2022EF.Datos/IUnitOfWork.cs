using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2022EF.Datos
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
