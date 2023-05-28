using Neptuno2022EF.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class VentaEntityTypeConfigurations:EntityTypeConfiguration<Venta>
    {
        public VentaEntityTypeConfigurations()
        {
            ToTable("Ventas");
            Property(v=>v.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
