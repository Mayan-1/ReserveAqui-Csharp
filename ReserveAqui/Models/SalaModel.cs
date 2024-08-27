using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReserveAqui.Models
{
    public class SalaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; } = string.Empty;

        [JsonIgnore]
        public bool Disponivel { get; set; }
        
        [JsonIgnore]
        public ICollection<ReservaSalaModel> Reservas { get; set; }

    }
}
