using ReserveAqui.Dto.Administrador;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Administrador
{
    public interface IAdministradorService
    {
        Task<ResponseModel<List<AdministradorModel>>> GetAll();
        Task<ResponseModel<AdministradorModel>> Get(int id);
        Task<ResponseModel<List<AdministradorModel>>> Create(AdministradorCriacaoDto administradorDto);
        Task<ResponseModel<List<AdministradorModel>>> Update(AdministradorEdicaoDto administradorDto);
        Task<ResponseModel<List<AdministradorModel>>> Delete(int id);


    }
}
