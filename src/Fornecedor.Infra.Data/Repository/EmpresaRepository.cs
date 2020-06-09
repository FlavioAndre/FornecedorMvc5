using System.Linq;
using Dapper;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Infra.Data.Context;

namespace Fornecedor.Infra.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(FornecedorContext context)
            : base(context)
        {
        }

        public Empresa ObterPorCnpj(string cnpj)
        {
            return Buscar(c => c.CNPJ == cnpj).FirstOrDefault();
        }

        public Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Fornecedor.Empresas " +
                      "WHERE (@Nome IS NULL OR NomeFantasia LIKE @Nome + '%') " +
                      "ORDER BY [NomeFantasia] " +
                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +
                      "SELECT COUNT(EmpresaId) FROM Fornecedor.Empresas " +
                      "WHERE (@Nome IS NULL OR NomeFantasia LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new {Nome = nome});
            var empresas = multi.Read<Empresa>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Empresa>
            {
                List = empresas,
                Count = total
            };

            return pagedList;
        }
    }
}