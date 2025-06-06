using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Models
{
    public class SubCategoria : BaseEntity
    {
        [Required(ErrorMessage = "Informe o nome da subcategoria")]
        [StringLength(60, ErrorMessage = "O tamanho máximo deve ser 60 caracteres para subcategoria")]
        public string? Nome { get; set; }

        public Categoria? Categoria { get; set; }
        public List<Produto>? Produtos  { get; set; }
    }
}
