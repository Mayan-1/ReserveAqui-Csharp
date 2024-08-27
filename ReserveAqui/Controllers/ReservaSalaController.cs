using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Dto.Professor;
using ReserveAqui.Dto.ReservaSala;
using ReserveAqui.Models;
using ReserveAqui.Services.ReservaSala;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaSalaController : ControllerBase
    {
        private readonly IReservaSalaService _reservaSalaService;

        public ReservaSalaController(IReservaSalaService reservaSalaService)
        {
            _reservaSalaService = reservaSalaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<ReservaSalaModel>>>> GetAll()
        {
            var reservas = await _reservaSalaService.GetAll();
            return Ok(reservas);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<ReservaSalaModel>>> Get(int id)
        {
            var reserva = await _reservaSalaService.Get(id);
            return Ok(reserva);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<ReservaSalaModel>>>> Create(ReservaSalaCriacaoDto reservaDto)
        {
            var reservas = await _reservaSalaService.Create(reservaDto);
            return Ok(reservas);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<ReservaSalaModel>>>> Delete(int id)
        {
            var reservas = await _reservaSalaService.Delete(id);
            return Ok(reservas);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<List<ReservaSalaModel>>>> Update(ReservaSalaEdicaoDto reservaDto)
        {
            var reservas = await _reservaSalaService.Update(reservaDto);
            return Ok(reservas);
        }
    }
}
