using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;

namespace Fornecedor.Domain.Specifications.Fornecedores
{
    class FornecedorPessoaFisicaDeveTerRgValidoSpecification : ISpecification<Fornecedor>
    {
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            if (fornecedor.TipoFornecedor == TipoPessoa.JURIDICA) return true;
            return fornecedor.RegistroGeral != null &&
                fornecedor.RegistroGeral.Length > 3 &&
                fornecedor.DataAniversario != null &&
                fornecedor.DataAniversario.HasValue;
       }
    }
}
