using ReserveAqui.Dto.ReservaSala;
using ReserveAqui.Dto.Sala;
using ReserveAqui.Models;

namespace ReserveAqui.Services.ReservaSala
{
    public interface IReservaSalaService 
    {
        Task<ResponseModel<List<ReservaSalaModel>>> GetAll();
        Task<ResponseModel<ReservaSalaModel>> Get(int id);
        Task<ResponseModel<List<ReservaSalaModel>>> Create(ReservaSalaCriacaoDto reservaSalaDto);
        Task<ResponseModel<List<ReservaSalaModel>>> Update(ReservaSalaEdicaoDto reservaSalaDto);
        Task<ResponseModel<List<ReservaSalaModel>>> Delete(int id);
    }
}
