using System;
using System.Collections.Generic;
using System.Linq;
using Fornecedor.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fornecedor.Domain.Tests.Entity
{
    [TestClass]
    public class FornecedorTest
    {
        public Empresa Empresa { get; set; }
        public Fornecedor Fornecedor { get; set; }

        [TestMethod]
        public void EmpresaConsistente_Valid_True()
        {
            Empresa = new Empresa
            {
                NomeFantasia = "Teste empresa",
                Uf = "SC",
                CNPJ = "51465555000140",
            };

            Fornecedor = new Fornecedor
            {
                CpfOuCnpj = "30390600822",
                Nome = "Fulano de tal",
                DataAniversario = new DateTime(1982, 01, 01),
                EmpresaId = Empresa.EmpresaId,
                Empresa = Empresa,
                RegistroGeral = "12313123",
                TipoFornecedor = TipoPessoa.FISICA,
            };

            Fornecedor.Telefones.Add(new Telefone
            {
                FornecedorId = Fornecedor.FornecedorId,
                Numero = "4785555888",
            });
            Assert.IsTrue(Fornecedor.IsValid());

        }

        [TestMethod]
        public void EmpresaConsistente_Valid_False()
        {
            Empresa = new Empresa
            {
                NomeFantasia = "Teste empresa",
                Uf = "SC",
                CNPJ = "51465555000140",
            };

            Fornecedor = new Fornecedor
            {
                CpfOuCnpj = "30390600822",
                Nome = "Fulano de tal",
                DataAniversario = new DateTime(1982, 01, 01),
                EmpresaId = Empresa.EmpresaId,
                Empresa = Empresa,
                RegistroGeral = "12313123",
                TipoFornecedor = TipoPessoa.JURIDICA,
            };

            Fornecedor.Telefones.Add(new Telefone
            {
                FornecedorId = Fornecedor.FornecedorId,
                Numero = "4785555888",
            });
            Assert.IsFalse(Fornecedor.IsValid());
            Assert.IsTrue(Fornecedor.ValidationResult.Errors.Any(e => e.ErrorMessage == "CPF/CNPJ inválido!"));
        }
    }
}
