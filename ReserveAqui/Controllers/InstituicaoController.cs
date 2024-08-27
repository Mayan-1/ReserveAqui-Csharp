using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Models;
using ReserveAqui.Services.Instituicao;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _instituicaoService;

        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<InstituicaoModel>>>> GetAll()
        {
            var instituicoes = await _instituicaoService.GetAll();
            return Ok(instituicoes);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<InstituicaoModel>>> Get(int id)
        {
            var instituicao = await _instituicaoService.Get(id);
            return Ok(instituicao);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<InstituicaoModel>>>> Create(InstituicaoCriacaoDto instituicaoCriacaoDto)
        {
            var instituicoes = await _instituicaoService.Create(instituicaoCriacaoDto);
            return Ok(instituicoes);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<List<InstituicaoModel>>>> Update(InstituicaoEdicaoDto instituicaoEdicaoDto)
        {
            var instituicoes = await _instituicaoService.Update(instituicaoEdicaoDto);
            return Ok(instituicoes);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<InstituicaoModel>>>> Delete(int id)
        {
            var instituicoes = await _instituicaoService.Delete(id);
            return Ok(instituicoes);
        }
    }
}
