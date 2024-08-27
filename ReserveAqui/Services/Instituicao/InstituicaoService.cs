using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Models;
using ReserveAqui.Services.Instituicao;

namespace ReserveAqui.Services.Instituicao
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly AppDbContext _context;

        public InstituicaoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<InstituicaoModel>>> Create(InstituicaoCriacaoDto instituicaoDto)
        {
            ResponseModel<List<InstituicaoModel>> resposta = new ResponseModel<List<InstituicaoModel>>();
            try
            {
                var instituicao = new InstituicaoModel()
                {
                    Nome = instituicaoDto.Nome,
                    Endereco = instituicaoDto.Endereco
                };

                _context.Add(instituicao);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Instituicoes.ToListAsync();
                resposta.Mensagem = "Instituição criada com sucesso!";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InstituicaoModel>>> Delete(int id)
        {
            ResponseModel<List<InstituicaoModel>> resposta = new ResponseModel<List<InstituicaoModel>>();
            try
            {
                var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(x => x.Id == id);

                if(instituicao == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(instituicao);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Instituicoes.ToListAsync();
                resposta.Mensagem = "Instituição removida com sucesso";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<InstituicaoModel>> Get(int id)
        {
            ResponseModel<InstituicaoModel> resposta = new ResponseModel<InstituicaoModel>();
            try
            {
                var insituicao = await _context.Instituicoes.FirstOrDefaultAsync(x => x.Id == id);

                if(insituicao == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = insituicao;
                resposta.Mensagem = "Instituição localizada";
                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InstituicaoModel>>> GetAll()
        {
            ResponseModel<List<InstituicaoModel>> resposta = new ResponseModel<List<InstituicaoModel>>();
            try
            {
                var instituicoes = await _context.Instituicoes.ToListAsync();
                resposta.Dados = instituicoes;
                resposta.Mensagem = "Todas as instituições foram coletadas";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InstituicaoModel>>> Update(InstituicaoEdicaoDto instituicaoDto)
        {
            ResponseModel<List<InstituicaoModel>> resposta = new ResponseModel<List<InstituicaoModel>>();
            try
            {
                var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(x => x.Id == instituicaoDto.Id);

                if (instituicao == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                instituicao.Nome = instituicaoDto.Nome;
                instituicao.Endereco = instituicaoDto.Endereco;
                _context.Update(instituicao);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Instituicoes.ToListAsync();
                resposta.Mensagem = "Instituição atualizada";
                return resposta;


            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
