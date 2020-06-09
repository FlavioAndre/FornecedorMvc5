using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Specifications.Empresas;
using FluentValidation;

namespace Fornecedor.Domain.Validations.Empresas
{
    class EmpresaEstaConsistenteValidation : AbstractValidator<Empresa>
    {
        public EmpresaEstaConsistenteValidation()
        {
            var cnpjEmpresa = new EmpresaDeveTerCnpjValidoSpecification();

            RuleFor(x => x).Must(cnpjEmpresa.IsSatisfiedBy).WithMessage("CNPJ inválido");

            RuleFor(x => x.NomeFantasia)
                .NotEmpty().WithMessage("Informe o nome Fantasia")
                .Length(3, 255).WithMessage("O nome Fantasia deve ter no mínimo 3 caracteres e no máximo 255 caracteres");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("Informe um CNPJ");

            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("Informe um Estado");

        }
    }
}
