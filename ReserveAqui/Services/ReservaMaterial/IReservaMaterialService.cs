using ReserveAqui.Dto.ReservaMaterial;
using ReserveAqui.Dto.ReservaSala;
using ReserveAqui.Models;

namespace ReserveAqui.Services.ReservaMaterial
{
    public interface IReservaMaterialService
    {
        Task<ResponseModel<List<ReservaMaterialModel>>> GetAll();
        Task<ResponseModel<ReservaMaterialModel>> Get(int id);
        Task<ResponseModel<List<ReservaMaterialModel>>> Create(ReservaMaterialCriacaoDto reservaDto);
        Task<ResponseModel<List<ReservaMaterialModel>>> Update(ReservaMaterialEdicaoDto reservaDto);
        Task<ResponseModel<List<ReservaMaterialModel>>> Delete(int id);
    }
}
