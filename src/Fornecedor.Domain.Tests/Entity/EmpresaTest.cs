using System;
using System.Linq;
using Fornecedor.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fornecedor.Domain.Tests.Entity
{
    [TestClass]
    public class EmpresaTest
    {
        public Empresa Empresa { get; set; }

        [TestMethod]
        public void EmpresaConsistente_Valid_True()
        {
            Empresa = new Empresa
            {
                NomeFantasia = "Teste empresa",
                Uf = "SC",
                CNPJ = "51465555000140",
            };

            Assert.IsTrue(Empresa.IsValid());
        
        }

        [TestMethod]
        public void EmpresaConsistente_Valid_False()
        {
            Empresa = new Empresa
            {
                NomeFantasia = "Teste empresa",
                Uf = "SC",
                CNPJ = "5146555500014",
            };

            Assert.IsFalse(Empresa.IsValid());
            Assert.IsTrue(Empresa.ValidationResult.Errors.Any(e => e.ErrorMessage == "CNPJ inválido"));
        }
    }
}
