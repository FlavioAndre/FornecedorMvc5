using System.Data.Entity.ModelConfiguration;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Infra.Data.EntityConfig
{
    public class TelefoneConfig : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfig()
        {
            HasKey(e => e.TelefoneId);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            HasRequired(e => e.Fornecedor)
                .WithMany(c => c.Telefones)
                .HasForeignKey(e => e.FornecedorId);

            ToTable("Telefones", "Fornecedor");
        }
    }
}