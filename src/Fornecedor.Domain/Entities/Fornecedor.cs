using Fornecedor.Domain.Validations.Fornecedores;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Fornecedor.Domain.Entities
{
    public enum TipoPessoa
    {
        [Description("Pessoa Física")]
        FISICA = 1,
        [Description("Pessoa Jurídica")]
        JURIDICA = 2,
    }

    public class Fornecedor
    {
        public Fornecedor()
        {
            FornecedorId = Guid.NewGuid();
            Telefones = new List<Telefone>();
        }

        public Fornecedor(Guid id, string nome, string cpfOuCnpj)
        {
            FornecedorId = id;
            Nome = nome;
            CpfOuCnpj = cpfOuCnpj;
            DataCadastro = DateTime.Now;
            Telefones = new List<Telefone>();
        }

        public TipoPessoa TipoFornecedor { get; set; }

        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }

        public string CpfOuCnpj { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAniversario { get; set; }

        public string RegistroGeral { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }

        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
           ValidationResult = new FornecedorEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;

        }
    }
}