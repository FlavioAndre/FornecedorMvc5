using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;

namespace Fornecedor.Domain.Specifications.Fornecedores
{
    class FornecedorPessoaFisicaDeveTerDataNasctoValidoSpecification : ISpecification<Fornecedor>
    {
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            if (fornecedor.TipoFornecedor == TipoPessoa.JURIDICA) return true;
            return fornecedor.DataAniversario != null &&
                fornecedor.DataAniversario.HasValue;
       }
    }
}
