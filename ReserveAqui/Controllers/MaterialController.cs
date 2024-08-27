using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Dto.Material;
using ReserveAqui.Models;
using ReserveAqui.Services.Material;

namespace ReserveAqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService) 
        { 
            _materialService = materialService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<MaterialModel>>>> GetAll()
        {
            var materiais = await _materialService.GetAll();
            return Ok(materiais);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ResponseModel<MaterialModel>>> Get(int id)
        {
            var material = await _materialService.Get(id);
            return Ok(material);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<MaterialModel>>>> Create(MaterialCriacaoDto materialDto)
        {
            var materiais = await _materialService.Create(materialDto);
            return Ok(materiais);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseModel<List<MaterialModel>>>> Update(MaterialEdicaoDto materialDto)
        {
            var materiais = await _materialService.Update(materialDto);
            return Ok(materiais);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<MaterialModel>>>> Delete(int id)
        {
            var materiais = await _materialService.Delete(id);
            return Ok(materiais);
        }
    }
}
