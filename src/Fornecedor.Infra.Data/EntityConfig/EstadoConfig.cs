using System.Data.Entity.ModelConfiguration;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Infra.Data.EntityConfig
{
    public class EstadoConfig : EntityTypeConfiguration<Estado>
    {
        public EstadoConfig()
        {
            HasKey(e => e.Uf);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150);

            ToTable("Estados", "Fornecedor");
        }
    }
}