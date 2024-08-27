using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReserveAqui.Models
{
    public class ReservaMaterialModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        [JsonIgnore]
        public MaterialModel Material { get; set; }
        public ProfessorModel Professor { get; set; }
    }
}
