using ReserveAqui.Dto.Sala;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Instituicao
{
    public interface ISalaService
    {
        Task<ResponseModel<List<SalaModel>>> GetAll();
        Task<ResponseModel<SalaModel>> Get(int id);
        Task<ResponseModel<List<SalaModel>>> Create(SalaCriacaoDto salaDto);
        Task<ResponseModel<List<SalaModel>>> Update(SalaEdicaoDto salaDto);
        Task<ResponseModel<List<SalaModel>>> Delete(int id);


    }
}
