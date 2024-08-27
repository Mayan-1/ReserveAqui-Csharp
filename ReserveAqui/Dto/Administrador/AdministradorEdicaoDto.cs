using ReserveAqui.Models;

namespace ReserveAqui.Dto.Administrador
{
    public class AdministradorEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public InstituicaoModel? Instituicao { get; set; }
    }
}
