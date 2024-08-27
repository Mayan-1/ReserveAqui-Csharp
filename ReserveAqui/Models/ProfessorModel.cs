using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models
{
    public class ProfessorModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string? Cpf { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string? Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string? Senha { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string? Materia { get; set; } = string.Empty;
        public InstituicaoModel? Instituicao { get; set; }

    }
}
