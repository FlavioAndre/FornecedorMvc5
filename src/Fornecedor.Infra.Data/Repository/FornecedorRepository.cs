using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces;
using Fornecedor.Infra.Data.Context;

namespace Fornecedor.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(FornecedorContext context)
            : base(context)
        {
        }

        public Paged<Fornecedor> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Fornecedor.Fornecedores " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') " +
                      "ORDER BY [Nome] " +
                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +
                      "SELECT COUNT(FornecedorId) FROM Fornecedor.Fornecedores " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new {Nome = nome});
            var fornecedores = multi.Read<Fornecedor>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Fornecedor>
            {
                List = fornecedores,
                Count = total
            };

            return pagedList;
        }

        public override Fornecedor ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Fornecedor.Fornecedores c " +
                      "LEFT JOIN Fornecedor.Telefones e " +
                      "ON c.FornecedorId = e.FornecedorId " +
                      "LEFT JOIN Fornecedor.Empresas em " +
                      "ON c.EmpresaId = em.EmpresaId " +
                      "WHERE c.FornecedorId = @sid";

            var fornecedor = new List<Fornecedor>();
            cn.Query<Fornecedor, Telefone, Empresa, Fornecedor>(sql,
                (c, e, em) =>
                {
                    
                    c.Empresa = em;
                    fornecedor.Add(c);
                    if (e != null)
                        fornecedor[0].Telefones.Add(e);

                    return fornecedor.FirstOrDefault();
                }, new {sid = id}, splitOn: "FornecedorId, TelefoneId, EmpresaId");

            return fornecedor.FirstOrDefault();
        }

        public Fornecedor ObterPorCpfOuCnpj(string cpfOuCnpj)
        {
            return Buscar(c => c.CpfOuCnpj == cpfOuCnpj).FirstOrDefault();
        }

        public Fornecedor AtualizaFornecedorEndereco(Fornecedor fornecedor)
        {
            var entry = Db.Entry(fornecedor);

            var old = base.ObterPorId(fornecedor.FornecedorId);
            if(old != null)
            {
                Db.Entry(old).State = EntityState.Detached;
            }

            DbSet.Attach(fornecedor);
            entry.State = EntityState.Modified;

            return fornecedor;
        }
    }
}