using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models
{
    public class MaterialModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; } = string.Empty;

    }
}
