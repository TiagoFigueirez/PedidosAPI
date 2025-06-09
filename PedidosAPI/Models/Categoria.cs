using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PedidosAPI.Models
{
    public class Categoria : BaseEntity
    {
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [StringLength(60, ErrorMessage ="O tamanho máximo deve ser 60 caracteres para categoria")]
        public string? Nome  { get; set; }

        [JsonIgnore]
        public List<SubCategoria>? SubCategorias { get; set; }

    }
}
