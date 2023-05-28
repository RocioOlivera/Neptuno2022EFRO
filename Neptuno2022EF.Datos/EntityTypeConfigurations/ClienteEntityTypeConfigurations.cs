using NuevaAppComercial2022.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Neptuno2022EF.Datos.EntityTypeConfigurations
{
    public class ClienteEntityTypeConfigurations:EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityTypeConfigurations()
        {
            ToTable("Clientes");
            Property(c => c.Id).HasColumnName("ClienteId");
            Property(c => c.Nombre).HasColumnName("NombreCliente");
            Property(c => c.TelefonoFijo).HasColumnName("TelFijo");
            Property(c => c.TelefonoMovil).HasColumnName("TelMovil");
            Property(c=>c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
