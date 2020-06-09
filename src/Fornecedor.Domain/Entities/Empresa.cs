using Fornecedor.Domain.Validations.Empresas;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Fornecedor.Domain.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            EmpresaId = Guid.NewGuid();
        }

        public Empresa(Guid id, string nomeFantasia, string cnpj, string uf)
        {
            EmpresaId = id;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            Uf = uf;
        }

        public Guid EmpresaId { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Uf { get; set; }

        public virtual ICollection<Fornecedor> Fornecedores { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new EmpresaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;

        }
    }
}