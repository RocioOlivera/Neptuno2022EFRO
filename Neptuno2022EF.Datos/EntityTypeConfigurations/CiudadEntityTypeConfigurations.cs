using Neptuno2022EF.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class CiudadEntityTypeConfigurations:EntityTypeConfiguration<Ciudad>
    {
        public CiudadEntityTypeConfigurations()
        {
            ToTable("Ciudades");
            Property(c=>c.RowVersion).IsRowVersion().IsConcurrencyToken();
            
        }
    }
}
