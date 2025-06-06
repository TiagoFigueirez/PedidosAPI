using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id  { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
