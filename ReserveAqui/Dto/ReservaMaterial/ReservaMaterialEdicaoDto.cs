using ReserveAqui.Models;

namespace ReserveAqui.Dto.ReservaMaterial
{
    public class ReservaMaterialEdicaoDto
    {
        public int Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public MaterialModel Material { get; set; }
    }
}
