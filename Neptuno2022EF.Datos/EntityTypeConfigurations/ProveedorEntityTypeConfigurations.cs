using Neptuno2022EF.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class ProveedorEntityTypeConfigurations:EntityTypeConfiguration<Proveedor>
    {
        public ProveedorEntityTypeConfigurations()
        {
            ToTable("Proveedores");
            Property(c => c.Id).HasColumnName("ProveedorId");
            Property(c => c.Nombre).HasColumnName("RazonSocial");
            Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();

        }
    }
}
