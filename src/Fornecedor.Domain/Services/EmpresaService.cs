using System;
using System.Collections.Generic;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Interfaces.Service;
using Fornecedor.Domain.Validations.Empresas;

namespace Fornecedor.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Empresa Adicionar(Empresa empresa)
        {
            if(!empresa.IsValid())
            {
                return empresa;
            }

            empresa.ValidationResult = new EmpresaAptoParaCadastroValidation(_empresaRepository).Validate(empresa);
            if (!empresa.ValidationResult.IsValid)
            {
                return empresa;
            }

            return _empresaRepository.Adicionar(empresa);
        }

        public Empresa Atualizar(Empresa empresa)
        {
            if (!empresa.IsValid())
            {
                return empresa;
            }
            return _empresaRepository.Atualizar(empresa);
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Empresa ObterPorId(Guid id)
        {
            return _empresaRepository.ObterPorId(id);
        }

        public Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return _empresaRepository.ObterTodos(nome, pageSize, pageNumber);
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            return _empresaRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _empresaRepository.Remover(id);
        }
    }
}