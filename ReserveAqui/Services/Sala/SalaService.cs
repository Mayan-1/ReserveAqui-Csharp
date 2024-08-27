using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.Professor;
using ReserveAqui.Dto.Sala;
using ReserveAqui.Models;
using ReserveAqui.Services.Instituicao;

namespace ReserveAqui.Services.Sala
{
    public class SalaService : ISalaService
    {
        private readonly AppDbContext _context;

        public SalaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<SalaModel>>> Create(SalaCriacaoDto salaDto)
        {
            ResponseModel<List<SalaModel>> resposta = new ResponseModel<List<SalaModel>>();
            try
            { 

                var sala = new SalaModel()
                {
                    Nome = salaDto.Nome,
                };

                _context.Add(sala);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Salas.ToListAsync();
                resposta.Mensagem = "Sala adicionada com sucesso";
                return resposta;




            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<SalaModel>>> Delete(int id)
        {
            ResponseModel<List<SalaModel>> resposta = new ResponseModel<List<SalaModel>>();
            try
            {
                var sala = await _context.Salas.FirstOrDefaultAsync(x => x.Id == id);

                if (sala == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(sala);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Salas.ToListAsync();
                resposta.Mensagem = "Sala deletada com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<SalaModel>> Get(int id)
        {
            ResponseModel<SalaModel> resposta = new ResponseModel<SalaModel>();
            try
            {
                var sala = await _context.Salas.FirstOrDefaultAsync(x => x.Id == id);

                if (sala == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = sala;
                resposta.Mensagem = "Sala localizada";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<SalaModel>>> GetAll()
        {
            ResponseModel<List<SalaModel>> resposta = new ResponseModel<List<SalaModel>>();
            try
            {
                var salas = await _context.Salas.ToListAsync();
                resposta.Dados = salas;
                resposta.Mensagem = "Todos os registros foram coletados com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<SalaModel>>> Update(SalaEdicaoDto salaDto)
        {
            ResponseModel<List<SalaModel>> resposta = new ResponseModel<List<SalaModel>>();
            try
            {
                var sala = await _context.Salas.FirstOrDefaultAsync(x => x.Id == salaDto.Id);

                if (sala == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                sala.Nome = salaDto.Nome;
                _context.Update(sala);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Salas.ToListAsync();
                resposta.Mensagem = "Sala atualizada com sucesso";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        

       
    }
}
