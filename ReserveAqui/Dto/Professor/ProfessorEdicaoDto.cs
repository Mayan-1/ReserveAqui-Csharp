using ReserveAqui.Models;
using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Dto.Professor
{
    public class ProfessorEdicaoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Cpf { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Senha { get; set; } = string.Empty;
        public string? Materia { get; set; } = string.Empty;
        public InstituicaoModel? Instituicao { get; set; }
    }
}
