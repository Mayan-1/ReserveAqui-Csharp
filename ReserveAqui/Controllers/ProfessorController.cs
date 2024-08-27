using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Dto.Professor;
using ReserveAqui.Models;
using ReserveAqui.Services.Instituicao;
using ReserveAqui.Services.Professor;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> GetAll()
        {
            var professores = await _professorService.GetAll();
            return Ok(professores);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<ProfessorModel>>> Get(int id)
        {
            var professor = await _professorService.Get(id);
            return Ok(professor);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> Create(ProfessorCriacaoDto professorDto)
        {
            var professores = await _professorService.Create(professorDto);
            return Ok(professores);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> Update(ProfessorEdicaoDto professorDto)
        {
            var professores = await _professorService.Update(professorDto);
            return Ok(professores);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> Delete(int id)
        {
            var professores = await _professorService.Delete(id);
            return Ok(professores);
        }
    }
}
