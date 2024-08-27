using ReserveAqui.Models;

namespace ReserveAqui.Dto.Administrador
{
    public class AdministradorCriacaoDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public InstituicaoModel? Instituicao { get; set; }
    }
}
