using System;
using System.Linq;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Validations.Empresas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Fornecedor.Domain.Tests.Validation
{
    [TestClass]
    public class EmpresaAptoParaCadastroTest
    {
        public Empresa Empresa { get; set; }

        [TestMethod]
        public void EmpresaApto_Validation_True()
        {
            Empresa = new Empresa
            {
                NomeFantasia = "Teste empresa",
                Uf = "SC",
                CNPJ = "51465555000140",
            };


            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.ObterPorCnpj(Empresa.CNPJ)).Return(null);
            var empValidation = new EmpresaAptoParaCadastroValidation(stubRepo);
            Assert.IsTrue(empValidation.Validate(Empresa).IsValid);
        }


        [TestMethod]
        public void EmpresaApto_Validation_False()
        {
            Empresa = new Empresa
            {
                NomeFantasia = "Teste empresa",
                Uf = "SC",
                CNPJ = "51465555000140",
            };


            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.ObterPorCnpj(Empresa.CNPJ)).Return(Empresa);
            var empValidation = new EmpresaAptoParaCadastroValidation(stubRepo);

            var result = empValidation.Validate(Empresa);
            Assert.IsFalse(empValidation.Validate(Empresa).IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "CNPJ já cadastrado!"));
        }
    }
}
