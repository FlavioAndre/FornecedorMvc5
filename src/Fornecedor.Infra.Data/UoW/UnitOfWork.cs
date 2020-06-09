using System;
using Fornecedor.Infra.Data.Context;
using Fornecedor.Infra.Data.Interfaces;

namespace Fornecedor.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FornecedorContext _context;
        private bool _disposed;

        public UnitOfWork(FornecedorContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}