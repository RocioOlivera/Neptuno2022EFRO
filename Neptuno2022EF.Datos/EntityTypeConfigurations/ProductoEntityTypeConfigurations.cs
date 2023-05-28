using Neptuno2022EF.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class ProductoEntityTypeConfigurations:EntityTypeConfiguration<Producto>
    {
        public ProductoEntityTypeConfigurations()
        {
            ToTable("Productos");
            Property(p=>p.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
