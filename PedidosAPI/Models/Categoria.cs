using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Models
{
    public class Categoria : BaseEntity
    {
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [StringLength(60, ErrorMessage ="O tamanho máximo deve ser 60 caracteres para categoria")]
        public string? Nome  { get; set; }
        public List<SubCategoria>? SubCategorias { get; set; }

    }
}
