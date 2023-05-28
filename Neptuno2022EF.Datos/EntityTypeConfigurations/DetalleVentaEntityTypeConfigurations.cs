using Neptuno2022EF.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class DetalleVentaEntityTypeConfigurations : EntityTypeConfiguration<DetalleVenta>
    {
        public DetalleVentaEntityTypeConfigurations()
        {
            ToTable("DetalleVentas");
            Property(d=>d.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
