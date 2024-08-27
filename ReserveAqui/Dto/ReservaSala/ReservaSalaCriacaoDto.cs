using ReserveAqui.Models;

namespace ReserveAqui.Dto.ReservaSala
{
    public class ReservaSalaCriacaoDto
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int IdSala { get; set; }
        public int IdProfessor { get; set; }
    }
}
