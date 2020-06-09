using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fornecedor.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public EmpresaViewModel()
        {
            EmpresaId = Guid.NewGuid();
            Fornecedores = new List<FornecedorViewModel>();
        }

        [Key] public Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        [MaxLength(255, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [DisplayName("CNPJ")]
        [MaxLength(18, ErrorMessage = "Máximo {0} caracteres")]
        public string CNPJ { get; set; }


        [Required(ErrorMessage = "Selecione o campo UF")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("UF")]
        public string Uf { get; set; }

        public virtual ICollection<FornecedorViewModel> Fornecedores { get; set; }

        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }


    }
}