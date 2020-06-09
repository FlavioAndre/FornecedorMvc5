using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Specifications.Empresas;
using FluentValidation;

namespace Fornecedor.Domain.Validations.Empresas
{
    public class EmpresaAptoParaCadastroValidation : AbstractValidator<Empresa>
    {
        public EmpresaAptoParaCadastroValidation(IEmpresaRepository empresaRepository)
        {
            var cnpjEmpresa = new EmpresaDeveTerCnpjUnicoSpecification(empresaRepository);
            RuleFor(x => x).Must(cnpjEmpresa.IsSatisfiedBy).WithMessage("CNPJ já cadastrado!");
        }
    }
}
