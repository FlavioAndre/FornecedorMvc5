using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Infra.Data.Context;

namespace Fornecedor.Infra.Data.Repository
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(FornecedorContext context)
            : base(context)
        {
        }
    }
}