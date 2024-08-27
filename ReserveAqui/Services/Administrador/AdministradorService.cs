using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.Administrador;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Administrador
{
    public class AdministradorService : IAdministradorService
    {
        private readonly AppDbContext _context;
        public AdministradorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<AdministradorModel>>> Create(AdministradorCriacaoDto administradorDto)
        {
            ResponseModel<List<AdministradorModel>> resposta = new ResponseModel<List<AdministradorModel>>();
            try
            {
                var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(i => i.Id == administradorDto.Instituicao.Id);

                if(instituicao == null)
                {
                    resposta.Mensagem = "Nenhum registro de instituição localizada";
                    return resposta;
                }

                var administradorModel = new AdministradorModel()
                {
                    Nome = administradorDto.Nome,
                    Email = administradorDto.Email,
                    Senha = administradorDto.Senha,
                    Instituicao = instituicao
                };
                _context.Add(administradorModel);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Administradores.Include(i => i.Instituicao).ToListAsync();
                resposta.Mensagem = "Administrador criado com sucesso";
                return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AdministradorModel>>> Delete(int id)
        {
            ResponseModel<List<AdministradorModel>> resposta = new ResponseModel<List<AdministradorModel>>();
            try
            {
                var administrador = await _context.Administradores.FirstOrDefaultAsync(x => x.Id == id);
                if (administrador == null) 
                {
                    resposta.Mensagem = "Nenhum administrador localizado";
                    return resposta;
                }

                _context.Remove(administrador);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Administradores.Include(i => i.Instituicao).ToListAsync();
                resposta.Mensagem = "Administrador removido com sucessor";
                return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AdministradorModel>> Get(int id)
        {
            ResponseModel<AdministradorModel> resposta = new ResponseModel<AdministradorModel>();
            try
            {
                var administrador = await _context.Administradores.Include(i => i.Instituicao).FirstOrDefaultAsync(x => x.Id == id);

                if(administrador == null)
                {
                    resposta.Mensagem = "Nenhum administrador localizado";
                    return resposta;
                }

                resposta.Dados = administrador;
                resposta.Mensagem = "Administrador localizado";
                return resposta;
                
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AdministradorModel>>> GetAll()
        {
            ResponseModel<List<AdministradorModel>> resposta = new ResponseModel<List<AdministradorModel>>();
            try
            {
                var administradores = await _context.Administradores.Include(i => i.Instituicao).ToListAsync();
                resposta.Dados = administradores;
                resposta.Mensagem = "Todos os administradores foram coletados";
                return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AdministradorModel>>> Update(AdministradorEdicaoDto administradorDto)
        {
            ResponseModel<List<AdministradorModel>> resposta = new ResponseModel<List<AdministradorModel>>();
            try
            {
                var administrador = await _context.Administradores.FirstOrDefaultAsync(x => x.Id == administradorDto.Id);

                if (administrador == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                administrador.Nome = administradorDto.Nome;
                administrador.Email = administradorDto.Email;
                administrador.Senha = administradorDto.Senha;
                administrador.Instituicao = administradorDto.Instituicao;

                _context.Update(administrador);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Administradores.Include(i => i.Instituicao).ToListAsync();
                resposta.Mensagem = "Administrador editado";
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
