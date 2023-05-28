using Neptuno2022EF.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class CategoriaEntityTypeConfigurations:EntityTypeConfiguration<Categoria>
    {
        public CategoriaEntityTypeConfigurations()
        {
            ToTable("Categorias");
            Property(c=>c.RowVersion).IsRowVersion().IsConcurrencyToken();

        }
    }
}
