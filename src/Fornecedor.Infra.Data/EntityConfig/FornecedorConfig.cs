using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Infra.Data.EntityConfig
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            HasKey(c => c.FornecedorId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataAniversario)
                .IsOptional();

            Property(c => c.TipoFornecedor)
                .IsRequired();

            Property(c => c.RegistroGeral)
                .HasMaxLength(20)
                .IsOptional();

            Property(c => c.CpfOuCnpj)
                .IsRequired()
                .HasMaxLength(18)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute {IsUnique = true}));

            HasRequired(e => e.Empresa)
                .WithMany(c => c.Fornecedores)
                .HasForeignKey(e => e.EmpresaId);

            Ignore(c => c.ValidationResult);

            ToTable("Fornecedores", "Fornecedor");
        }
    }
}