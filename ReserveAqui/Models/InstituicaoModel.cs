using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models
{
    public class InstituicaoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string? Endereco { get; set; } = string.Empty;
    }
}
