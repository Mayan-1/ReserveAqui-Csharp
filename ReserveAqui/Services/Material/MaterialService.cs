using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.Material;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Material
{
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext _context;

        public MaterialService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<MaterialModel>>> Create(MaterialCriacaoDto materialDto)
        {
            ResponseModel<List<MaterialModel>> resposta = new ResponseModel<List<MaterialModel>>();
            try
            {
                var material = new MaterialModel()
                {
                    Nome = materialDto.Nome,    
                };

                _context.Add(material);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Materiais.ToListAsync();
                resposta.Mensagem = "Material criado";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<MaterialModel>>> Delete(int id)
        {
            ResponseModel<List<MaterialModel>> resposta = new ResponseModel<List<MaterialModel>>();
            try
            {
                var material = await _context.Materiais.FirstOrDefaultAsync(x => x.Id == id);
                if (material == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(material);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Materiais.ToListAsync();
                resposta.Mensagem = "Material removido";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<MaterialModel>> Get(int id)
        {
            ResponseModel<MaterialModel> resposta = new ResponseModel<MaterialModel>();
            try
            {
                var material = await _context.Materiais.FirstOrDefaultAsync(x => x.Id == id);

                if(material == null)
                {
                    resposta.Mensagem = "Registro não localizado";
                    return resposta;
                }

                resposta.Dados = material;
                resposta.Mensagem = "Material localizado";
                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }    
        }

        public async Task<ResponseModel<List<MaterialModel>>> GetAll()
        {
            ResponseModel<List<MaterialModel>> resposta = new ResponseModel<List<MaterialModel>>();
            try
            {
                var materiais = await _context.Materiais.ToListAsync();
                resposta.Dados = materiais;
                resposta.Mensagem = "Todos os materiais foram coletados";
                return resposta;
                
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<MaterialModel>>> Update(MaterialEdicaoDto materialDto)
        {
            ResponseModel<List<MaterialModel>> resposta = new ResponseModel<List<MaterialModel>>();
            try
            {
                var material = await _context.Materiais.FirstOrDefaultAsync(x => x.Id == materialDto.Id);

                if (material == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                material.Nome = materialDto.Nome;
                _context.Update(material);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Materiais.ToListAsync();
                resposta.Mensagem = "Material atualizado";
                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
