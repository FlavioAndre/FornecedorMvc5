using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Application.ViewModels
{
    public class TelefoneViewModel
    {
        public TelefoneViewModel()
        {
            TelefoneId = Guid.NewGuid();
        }

        [Key] public Guid TelefoneId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Telefone")]
        public string Numero { get; set; }

        public Guid FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}