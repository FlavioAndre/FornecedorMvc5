using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Specifications.Empresas;
using Fornecedor.Domain.Specifications.Fornecedores;
using FluentValidation;

namespace Fornecedor.Domain.Validations.Fornecedores
{
    public class FornecedorEstaConsistenteValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorEstaConsistenteValidation()
        {
            var cpfOuCnpjValido = new FornecedorDeveTerCpfOuCnpjValidoSpecification();
            var pessoaFisicaDataNascimentoValido = new FornecedorPessoaFisicaDeveTerDataNasctoValidoSpecification();
            var pessoaFisicaRGValido = new FornecedorPessoaFisicaDeveTerRgValidoSpecification();
            var pessoaFisicaPRMenorIdadeValido = new FornecedorPessoaFisicaPRMenorIdadeSpecification();
            var fornecedorTemTelefone = new FornecedorDeveTerUmTelefoneSpecification();

            RuleFor(x => x).Must(cpfOuCnpjValido.IsSatisfiedBy).WithMessage("CPF/CNPJ inválido!");
            RuleFor(x => x).Must(pessoaFisicaDataNascimentoValido.IsSatisfiedBy).WithMessage("Informe uma data de nascimento válida!");
            RuleFor(x => x).Must(pessoaFisicaRGValido.IsSatisfiedBy).WithMessage("Informe um RG válido!");
            RuleFor(x => x).Must(pessoaFisicaPRMenorIdadeValido.IsSatisfiedBy).WithMessage("Este fornecedor não permite pessoa menor de idade!");
            RuleFor(x => x).Must(fornecedorTemTelefone.IsSatisfiedBy).WithMessage("O Fornecedor tem que ter ao menos um telefone cadastrado!");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome do Fornecedor")
                .Length(3, 100).WithMessage("O nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            RuleFor(x => x.TipoFornecedor)
            .NotEmpty().WithMessage("Informe o tipo do Fornecedor")
            .IsInEnum().WithMessage("Tipo do Fornecedor inválido");
            
            

        }
    }
}