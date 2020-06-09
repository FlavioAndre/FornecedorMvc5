using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fornecedor.Application.ViewModels
{
    public class EstadoViewModel
    {
        [Key] [DisplayName("UF")] public string Uf { get; set; }

        [DisplayName("Nome")] public string Nome { get; set; }
    }
}