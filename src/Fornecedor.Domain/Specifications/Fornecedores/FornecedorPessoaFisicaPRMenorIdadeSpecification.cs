using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;
using System;

namespace Fornecedor.Domain.Specifications.Fornecedores
{

    class FornecedorPessoaFisicaPRMenorIdadeSpecification : ISpecification<Fornecedor>
    {
        private static readonly string UF_PARANA = "PR";
        private static readonly int IDADE_LIMITE = 18;

        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            if (fornecedor.TipoFornecedor == TipoPessoa.JURIDICA) return true;
            if( fornecedor.Empresa != null && 
                fornecedor.Empresa.Uf == UF_PARANA &&
                fornecedor.DataAniversario.HasValue)
            {
                return DateTime.Now.Year - fornecedor.DataAniversario.Value.Year >= IDADE_LIMITE;
            }
            return true;
                
        }
    }
}
