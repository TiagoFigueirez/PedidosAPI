using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Models
{
    public class Medico : BaseEntity
    {
        [Required(ErrorMessage = "Informe o CRM")]
        [StringLength(12, ErrorMessage = "O tamanho máximo deve ser 12 Caracteres para o CRM")]
        public string? CRM { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(45, ErrorMessage = "O tamanho máximo deve ser 45 caracteres para o nome do Médico")]
        public string? Nome { get; set; }
    }
}
