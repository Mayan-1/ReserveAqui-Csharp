using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Dto.Administrador;
using ReserveAqui.Dto.Sala;
using ReserveAqui.Models;
using ReserveAqui.Services.Instituicao;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<SalaModel>>>> GetAll()
        {
            var salas = await _salaService.GetAll();
            return Ok(salas);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<SalaModel>>> Get(int id)
        {
            var sala = await _salaService.Get(id);
            return Ok(sala);

        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<SalaModel>>>> Create(SalaCriacaoDto salaDto)
        {
            var salas = await _salaService.Create(salaDto);
            return Ok(salas);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<List<SalaModel>>>> Update(SalaEdicaoDto salaDto)
        {
            var salas = await _salaService.Update(salaDto);
            return Ok(salas);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<SalaModel>>>> Delete(int id)
        {
            var salas = await _salaService.Delete(id);
            return Ok(salas);
        }
    }
}
