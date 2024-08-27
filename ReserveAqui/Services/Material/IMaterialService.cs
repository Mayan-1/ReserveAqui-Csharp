using ReserveAqui.Dto.Material;
using ReserveAqui.Dto.Professor;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Material
{
    public interface IMaterialService
    {
        Task<ResponseModel<List<MaterialModel>>> GetAll();
        Task<ResponseModel<MaterialModel>> Get(int id);
        Task<ResponseModel<List<MaterialModel>>> Create(MaterialCriacaoDto materialDto);
        Task<ResponseModel<List<MaterialModel>>> Update(MaterialEdicaoDto materialDto);
        Task<ResponseModel<List<MaterialModel>>> Delete(int id);
    }
}
