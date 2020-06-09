using System.ComponentModel;

namespace Fornecedor.Application.ViewModels
{

    public enum TipoPessoaViewModel
    {
        [Description("Pessoa Física")]
        FISICA = 1,
        [Description("Pessoa Jurídica")]
        JURIDICA = 2,
    }
}