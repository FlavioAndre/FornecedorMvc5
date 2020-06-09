using System;
using System.Linq;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Validations.Fornecedores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Fornecedor.Domain.Tests.Validation
{
    [TestClass]
    public class FornecedorEstaConsistenteTest
    {
        public Empresa Empresa { get; set; }
        public Fornecedor Fornecedor { get; set; }

        [TestMethod]
        public void FornecedorApto_Validation_True()
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

            var stubRepoEmp = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepoEmp.Stub(s => s.ObterPorId(Empresa.EmpresaId)).Return(Empresa);

            var stubRepoFor = MockRepository.GenerateStub<IFornecedorRepository>();
            stubRepoFor.Stub(s => s.ObterPorCpfOuCnpj(Fornecedor.CpfOuCnpj)).Return(null);

            
            var empValidation = new FornecedorAptoParaCadastroValidation(stubRepoFor, stubRepoEmp);
            var result = empValidation.Validate(Fornecedor);

            Assert.IsTrue(empValidation.Validate(Fornecedor).IsValid);

        }

        [TestMethod]
        public void FornecedorApto_Validation_Empresa_False()
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

            var stubRepoEmp = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepoEmp.Stub(s => s.ObterPorId(Empresa.EmpresaId)).Return(null);

            var stubRepoFor = MockRepository.GenerateStub<IFornecedorRepository>();
            stubRepoFor.Stub(s => s.ObterPorCpfOuCnpj(Fornecedor.CpfOuCnpj)).Return(null);


            var empValidation = new FornecedorAptoParaCadastroValidation(stubRepoFor, stubRepoEmp);
            var result = empValidation.Validate(Fornecedor);

            Assert.IsFalse(empValidation.Validate(Fornecedor).IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "Empresa não foi localizada!"));
            
        }

        [TestMethod]
        public void FornecedorApto_Validation_CNPJ_False()
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

            var stubRepoEmp = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepoEmp.Stub(s => s.ObterPorId(Empresa.EmpresaId)).Return(Empresa);

            var stubRepoFor = MockRepository.GenerateStub<IFornecedorRepository>();
            stubRepoFor.Stub(s => s.ObterPorCpfOuCnpj(Fornecedor.CpfOuCnpj)).Return(Fornecedor);


            var empValidation = new FornecedorAptoParaCadastroValidation(stubRepoFor, stubRepoEmp);
            var result = empValidation.Validate(Fornecedor);

            Assert.IsFalse(empValidation.Validate(Fornecedor).IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "CPF/CNPJ já cadastrado!"));

        }
    }
}
