using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Instituicao
{
    public interface IInstituicaoService
    {
        Task<ResponseModel<List<InstituicaoModel>>> GetAll();
        Task<ResponseModel<InstituicaoModel>> Get(int id);
        Task<ResponseModel<List<InstituicaoModel>>> Create(InstituicaoCriacaoDto instituicaoDto);
        Task<ResponseModel<List<InstituicaoModel>>> Update(InstituicaoEdicaoDto instituicaoDto);
        Task<ResponseModel<List<InstituicaoModel>>> Delete(int id);


    }
}
