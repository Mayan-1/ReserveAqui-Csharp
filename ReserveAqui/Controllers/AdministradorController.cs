using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Dto.Administrador;
using ReserveAqui.Models;
using ReserveAqui.Services.Administrador;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;
        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<AdministradorModel>>>> GetAll()
        {
            var administradores = await _administradorService.GetAll();
            return Ok(administradores);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<AdministradorModel>>> Get(int id)
        {
            var administrador = await _administradorService.Get(id);
            return Ok(administrador);
              
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<AdministradorModel>>>> Create(AdministradorCriacaoDto administradorDto)
        {
            var administradores = await _administradorService.Create(administradorDto);
            return Ok(administradores);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<List<AdministradorModel>>>> Update(AdministradorEdicaoDto administradorDto)
        {
            var administradores = await _administradorService.Update(administradorDto);
            return Ok(administradores);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<AdministradorModel>>>> Delete(int id)
        {
            var administradores = await _administradorService.Delete(id);
            return Ok(administradores);
        } 
    }
}
