using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Infra.Data.EntityConfig
{
    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            HasKey(c => c.EmpresaId);

            Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Uf)
                .IsRequired()
                .HasMaxLength(2);


            Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute {IsUnique = true}));

            Ignore(c => c.ValidationResult);

            ToTable("Empresas", "Fornecedor");
        }
    }
}