using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Dto.Professor;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Professor
{
    public interface IProfessorService
    {
        Task<ResponseModel<List<ProfessorModel>>> GetAll();
        Task<ResponseModel<ProfessorModel>> Get(int id);
        Task<ResponseModel<List<ProfessorModel>>> Create(ProfessorCriacaoDto professorDto);
        Task<ResponseModel<List<ProfessorModel>>> Update(ProfessorEdicaoDto professorDto);
        Task<ResponseModel<List<ProfessorModel>>> Delete(int id);
    }
}
