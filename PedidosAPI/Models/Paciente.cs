using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Models
{
    public class Paciente : BaseEntity
    {
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(45, ErrorMessage = "O tamanho máximo deve ser 45 caracteres para o nome do Paciente")]
        public string? Nome { get; set; }
    }
}
