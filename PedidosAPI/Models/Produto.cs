using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosAPI.Models
{
    public class Produto:BaseEntity
    {
        [Required(ErrorMessage = "Informe o codigo do produto")]
        [MaxLength(60, ErrorMessage = "O codigo do produto não pode passar de 60 caracteres")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        [MaxLength(100, ErrorMessage = "a Descrição do produto não pode passar de 100 caracteres")]
        public string? Descricao { get; set; }

        [ForeignKey("SubCategoria")]
        public int SubcategoriaId {  get; set; }

        public SubCategoria? SubCategoria { get; set; }


    }
}
