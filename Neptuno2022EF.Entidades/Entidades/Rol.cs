using NuevaAppComercial2022.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2022EF.Entidades.Entidades
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Descripcion { get; set; }
        public List<Permiso> Permisos { get; set; }
        public byte[] RowVersion { get; set; }

        public Rol()
        {
            Permisos = new List<Permiso>();
        }
    }
}
