using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models
{
    public class AdministradorModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; } 

        [Required]
        [StringLength(80)]
        public string? Email { get; set; } 

        [Required]
        [StringLength(20)]
        public string? Senha { get; set; } 
        public InstituicaoModel? Instituicao { get; set; }
    }
}
