using System;
using System.Collections.Generic;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Interfaces.Service;

namespace Fornecedor.Domain.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public IEnumerable<Estado> ObterTodos()
        {
            return _estadoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _estadoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}