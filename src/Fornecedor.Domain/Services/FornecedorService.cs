using System;
using System.Collections.Generic;
using System.Linq;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Interfaces.Service;
using Fornecedor.Domain.Validations.Fornecedores;

namespace Fornecedor.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
            ITelefoneRepository telefoneRepository,
            IEmpresaRepository empresaRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _telefoneRepository = telefoneRepository;
            _empresaRepository = empresaRepository;
        }

        public Telefone AdicionarTelefone(Telefone telefone)
        {
            return _telefoneRepository.Adicionar(telefone);
        }

        public Telefone AtualizarTelefone(Telefone telefone)
        {
            return _telefoneRepository.Atualizar(telefone);
        }

        public Telefone ObterTelefonePorId(Guid id)
        {
            return _telefoneRepository.ObterPorId(id);
        }

        public void RemoverTelefone(Guid id)
        {
            _telefoneRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository.Dispose();
            _telefoneRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            if(fornecedor.Empresa == null)
            {
                fornecedor.Empresa = _empresaRepository.ObterPorId(fornecedor.EmpresaId);
            }

            if (!fornecedor.IsValid())
            {
                return fornecedor;
            }

            fornecedor.ValidationResult = new FornecedorAptoParaCadastroValidation(_fornecedorRepository ,_empresaRepository).Validate(fornecedor);
            if (!fornecedor.ValidationResult.IsValid)
            {
                return fornecedor;
            }

            return _fornecedorRepository.Adicionar(fornecedor);
        }

        public Fornecedor ObterPorId(Guid id)
        {
            return _fornecedorRepository.ObterPorId(id);
        }

        public Paged<Fornecedor> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            var fornecedores = _fornecedorRepository.ObterTodos().ToList();
            var pagedList = new Paged<Fornecedor>
            {
                List = fornecedores,
                Count = fornecedores.Count
            };

            return pagedList;
        }

        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            if (fornecedor.Empresa == null)
            {
                fornecedor.Empresa = _empresaRepository.ObterPorId(fornecedor.EmpresaId);
            }

            if (!fornecedor.IsValid())
            {
                return fornecedor;
            }
            
            return _fornecedorRepository.AtualizaFornecedorEndereco(fornecedor);
        }

        public void Remover(Guid id)
        {
            _fornecedorRepository.Remover(id);
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return _fornecedorRepository.ObterTodos();
        }
    }
}