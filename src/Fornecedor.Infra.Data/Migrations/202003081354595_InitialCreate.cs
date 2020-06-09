namespace Fornecedor.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Fornecedor.Empresas",
                c => new
                    {
                        EmpresaId = c.Guid(nullable: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 255, unicode: false),
                        CNPJ = c.String(nullable: false, maxLength: 18, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.EmpresaId)
                .Index(t => t.CNPJ, unique: true);
            
            CreateTable(
                "Fornecedor.Fornecedores",
                c => new
                    {
                        FornecedorId = c.Guid(nullable: false),
                        TipoFornecedor = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CpfOuCnpj = c.String(nullable: false, maxLength: 18, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAniversario = c.DateTime(),
                        RegistroGeral = c.String(maxLength: 20, unicode: false),
                        EmpresaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorId)
                .ForeignKey("Fornecedor.Empresas", t => t.EmpresaId)
                .Index(t => t.CpfOuCnpj, unique: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "Fornecedor.Telefones",
                c => new
                    {
                        TelefoneId = c.Guid(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 20, unicode: false),
                        FornecedorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("Fornecedor.Fornecedores", t => t.FornecedorId)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "Fornecedor.Estados",
                c => new
                    {
                        Uf = c.String(nullable: false, maxLength: 100, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Uf);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Fornecedor.Telefones", "FornecedorId", "Fornecedor.Fornecedores");
            DropForeignKey("Fornecedor.Fornecedores", "EmpresaId", "Fornecedor.Empresas");
            DropIndex("Fornecedor.Telefones", new[] { "FornecedorId" });
            DropIndex("Fornecedor.Fornecedores", new[] { "EmpresaId" });
            DropIndex("Fornecedor.Fornecedores", new[] { "CpfOuCnpj" });
            DropIndex("Fornecedor.Empresas", new[] { "CNPJ" });
            DropTable("Fornecedor.Estados");
            DropTable("Fornecedor.Telefones");
            DropTable("Fornecedor.Fornecedores");
            DropTable("Fornecedor.Empresas");
        }
    }
}
