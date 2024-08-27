using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Dto.ReservaMaterial;
using ReserveAqui.Models;
using ReserveAqui.Services.ReservaMaterial;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaMaterialController : ControllerBase
    {
        private readonly IReservaMaterialService _reservaMaterialService;

        public ReservaMaterialController(IReservaMaterialService reservaMaterialService)
        {
            _reservaMaterialService = reservaMaterialService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<ReservaMaterialModel>>>> GetAll()
        {
            var reservas = await _reservaMaterialService.GetAll();
            return Ok(reservas);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<ReservaMaterialModel>>> Get(int id)
        {
            var reserva = await _reservaMaterialService.Get(id);
            return Ok(reserva);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<ReservaMaterialModel>>> Create(ReservaMaterialCriacaoDto reservaDto)
        {
            var reservas = await _reservaMaterialService.Create(reservaDto);
            return Ok(reservas);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<ReservaMaterialModel>>> Update(ReservaMaterialEdicaoDto reservaDto)
        {
            var reservas = await _reservaMaterialService.Update(reservaDto);
            return Ok(reservas);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<ReservaMaterialModel>>>> Delete(int id)
        {
            var reservas = await _reservaMaterialService.Delete(id);
            return Ok(reservas);
        }
    }
}
