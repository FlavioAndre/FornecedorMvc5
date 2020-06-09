using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Infra.Data.Context;

namespace Fornecedor.Infra.Data.Repository
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(FornecedorContext context)
            : base(context)
        {
        }
    }
}