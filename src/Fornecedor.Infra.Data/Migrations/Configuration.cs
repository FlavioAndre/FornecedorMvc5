using System.Data.Entity.Migrations;
using Fornecedor.Domain.Entities;
using Fornecedor.Infra.Data.Context;

namespace Fornecedor.Infra.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<FornecedorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FornecedorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Estados.AddOrUpdate(
                new Estado("AC", "Acre"),
                new Estado("AL", "Alagoas"),
                new Estado("AP", "Amapá"),
                new Estado("AM", "Amazonas"),
                new Estado("BA", "Bahia"),
                new Estado("CE", "Ceará"),
                new Estado("DF", "Distrito Federal"),
                new Estado("ES", "Espírito Santo"),
                new Estado("GO", "Goiás"),
                new Estado("MA", "Maranhão"),
                new Estado("MT", "Mato Grosso"),
                new Estado("MS", "Mato Grosso do Sul"),
                new Estado("MG", "Minas Gerais"),
                new Estado("PA", "Pará"),
                new Estado("PB", "Paraíba"),
                new Estado("PR", "Paraná"),
                new Estado("PE", "Pernambuco"),
                new Estado("PI", "Piauí"),
                new Estado("RJ", "Rio de Janeiro"),
                new Estado("RN", "Rio Grande do Norte"),
                new Estado("RS", "Rio Grande do Sul"),
                new Estado("RO", "Rondônia"),
                new Estado("RR", "Roraima"),
                new Estado("SC", "Santa Catarina"),
                new Estado("SP", "São Paulo"),
                new Estado("SE", "Sergipe"),
                new Estado("TO", "Tocantins")
            );
        }
    }
}