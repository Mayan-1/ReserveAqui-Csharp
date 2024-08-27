using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ReserveAqui.Models
{
    public class ReservaSalaModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; } 
        public SalaModel Sala { get; set; }
        public ProfessorModel Professor { get; set; }
    }
}
