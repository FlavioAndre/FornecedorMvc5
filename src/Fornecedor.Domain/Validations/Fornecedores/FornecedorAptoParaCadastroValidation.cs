using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Specifications.Empresas;
using Fornecedor.Domain.Specifications.Fornecedores;
using FluentValidation;

namespace Fornecedor.Domain.Validations.Fornecedores
{
    public class FornecedorAptoParaCadastroValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorAptoParaCadastroValidation(IFornecedorRepository fornecedorRepository,
            IEmpresaRepository empresaRepository)
        {
            var cpfOuCnpjEmpresa = new FornecedorDeveTerCnpjUnicoSpecification(fornecedorRepository);
            var empresaCadastrada = new FornecedorDeveTerEmpresaCadastradaSpecification(empresaRepository);
            RuleFor(x => x).Must(cpfOuCnpjEmpresa.IsSatisfiedBy).WithMessage("CPF/CNPJ já cadastrado!");
            RuleFor(x => x).Must(empresaCadastrada.IsSatisfiedBy).WithMessage("Empresa não foi localizada!");
        }
    }
}