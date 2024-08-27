using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.Instituicao;
using ReserveAqui.Dto.Professor;
using ReserveAqui.Models;

namespace ReserveAqui.Services.Professor
{
    public class ProfessorService : IProfessorService
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProfessorModel>>> Create(ProfessorCriacaoDto professorDto)
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(i => i.Id == professorDto.Instituicao.Id);

                if (instituicao == null)
                {
                    resposta.Mensagem = "Nenhum registro de instituição localizada";
                    return resposta;
                }

                var professor = new ProfessorModel()
                {
                    Nome = professorDto.Nome,
                    Cpf = professorDto.Cpf,
                    Email = professorDto.Email,
                    Senha = professorDto.Senha,
                    Materia = professorDto.Materia,
                    Instituicao = instituicao,
                };

                _context.Add(professor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professores.Include(i => i.Instituicao).ToListAsync();
                resposta.Mensagem = "Professor adicionado com sucesso";
                return resposta;




            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> Delete(int id)
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Id == id);
                
                if(professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(professor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Professores.Include(i => i.Instituicao).ToListAsync();
                resposta.Mensagem = "Professor deletado com sucesso";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProfessorModel>> Get(int id)
        {
            ResponseModel<ProfessorModel> resposta = new ResponseModel<ProfessorModel>();
            try
            {
                var professor = await _context.Professores.Include(i => i.Instituicao).FirstOrDefaultAsync(x => x.Id == id);

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = professor;
                resposta.Mensagem = "Professor localizado";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> GetAll()
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var administradores = await _context.Professores.Include(i => i.Instituicao).ToListAsync();
                resposta.Dados = administradores;
                resposta.Mensagem = "Todos os registros foram coletados com sucesso";
                return resposta;
            }catch(Exception ex )
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> Update(ProfessorEdicaoDto professorDto)
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Id == professorDto.Id);

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                professor.Nome = professorDto.Nome;
                professor.Cpf = professorDto.Cpf;
                professor.Email = professorDto.Email;
                professor.Senha = professorDto.Senha;
                professor.Materia = professorDto.Materia;
                _context.Update(professor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professores.Include(i => i.Instituicao).ToListAsync();
                resposta.Mensagem = "Professor atualizado com sucesso";
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
