namespace ReserveAqui.Dto.ReservaMaterial
{
    public class ReservaMaterialCriacaoDto
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int IdMaterial { get; set; }
        public int IdProfessor { get; set; }
    }
}
