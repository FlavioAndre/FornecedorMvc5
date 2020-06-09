using Fornecedor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fornecedor.Application.ViewModels
{
    public class FornecedorTelefoneViewModel
    {
        public FornecedorTelefoneViewModel()
        {
            FornecedorId = Guid.NewGuid();
            Telefones = new List<TelefoneViewModel>();
        }

        [Key] public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo Pessoa")]
        public TipoPessoaViewModel TipoFornecedor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("CPF/CNPJ")]
        [Required(ErrorMessage = "Preencha o campo CPF/CNPJ")]
        [MaxLength(18, ErrorMessage = "Máximo {0} caracteres")]
        public string CpfOuCnpj { get; set; }

        [DisplayName("Data do Cadastro")] public DateTime DataCadastro { get; set; }

        public EmpresaViewModel Empresa { get; set; }

        public Guid EmpresaId { get; set; }

        [DisplayName("RG")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        public string RegistroGeral { get; set; }

        [DisplayName("Telefone")]
        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        public string Numero { get; set; }

        [DisplayName("Data do Aniversário")] public DateTime? DataAniversario { get; set; }

        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        [ScaffoldColumn(false)]
        public List<TelefoneViewModel> Telefones { get; set; }
    }
}