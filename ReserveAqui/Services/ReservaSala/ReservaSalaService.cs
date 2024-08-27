using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.ReservaSala;
using ReserveAqui.Models;

namespace ReserveAqui.Services.ReservaSala
{
    public class ReservaSalaService : IReservaSalaService
    {
        private readonly AppDbContext _context;

        public ReservaSalaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ReservaSalaModel>>> Create(ReservaSalaCriacaoDto reservaDto)
        {
            ResponseModel<List<ReservaSalaModel>> resposta = new ResponseModel<List<ReservaSalaModel>>();
            try
            {
                var sala = await _context.Salas.FirstOrDefaultAsync(s => s.Id == reservaDto.IdSala);
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == reservaDto.IdProfessor);

                if (sala == null)
                {
                    resposta.Mensagem = "Sala não encontrada";
                    return resposta;

                }

                if (professor == null)
                {
                    resposta.Mensagem = "Professor não encontrado";
                    return resposta;
                }

                bool existeConflito = await _context.ReservaSalas
                .AnyAsync(r => r.Sala.Id == reservaDto.IdSala &&
                           ((reservaDto.HoraInicio >= r.HoraInicio && reservaDto.HoraInicio < r.HoraFim) ||
                            (reservaDto.HoraFim > r.HoraInicio && reservaDto.HoraFim <= r.HoraFim) ||
                            (reservaDto.HoraInicio < r.HoraInicio && reservaDto.HoraFim > r.HoraFim)));

                if (existeConflito)
                {
                    resposta.Mensagem = "Não será possível agendar pois já existe reserva para este horário";
                    return resposta;
                }



                var reserva = new ReservaSalaModel()
                {
                    HoraInicio = reservaDto.HoraInicio,
                    HoraFim = reservaDto.HoraFim,
                    Sala = sala,
                    Professor = professor,
                };

                sala.Disponivel = false;

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Reserva criada com sucesso";
                resposta.Dados = await _context.ReservaSalas.Include(s => s.Sala).Include(p => p.Professor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReservaSalaModel>>> Delete(int id)
        {
            ResponseModel<List<ReservaSalaModel>> resposta = new ResponseModel<List<ReservaSalaModel>>();
            try
            {
                var reserva = await _context.ReservaSalas.FirstOrDefaultAsync(r => r.Id == id);

                if(reserva == null)
                {
                    resposta.Mensagem = "Reserva não localizada";
                    return resposta;
                }

                _context.Remove(reserva);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Reserva deletada com sucesso";
                resposta.Dados = await _context.ReservaSalas.Include(s => s.Sala).Include(p => p.Professor).ToListAsync();
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ReservaSalaModel>> Get(int id)
        {
            ResponseModel<ReservaSalaModel> resposta = new ResponseModel<ReservaSalaModel>();

            try
            {
                var reserva = await _context.ReservaSalas.FirstOrDefaultAsync(r => r.Id == id);

                if(reserva == null)
                {
                    resposta.Mensagem = "Reserva não localizada";
                    return resposta;
                }

                resposta.Mensagem = "Reserva localizada com sucesso";
                resposta.Dados = reserva;
                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReservaSalaModel>>> GetAll()
        {
            ResponseModel<List<ReservaSalaModel>> resposta = new ResponseModel<List<ReservaSalaModel>>();
            try
            {
                var reservas = await _context.ReservaSalas.Include(s => s.Sala).Include(p => p.Professor).ToListAsync();

                if(reservas == null)
                {
                    resposta.Mensagem = "Nenhuma reserva localizada";
                    return resposta;
                }

                resposta.Mensagem = "Reservas localizadas com sucesso";
                resposta.Dados = reservas;
                return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReservaSalaModel>>> Update(ReservaSalaEdicaoDto reservaDto)
        {
            ResponseModel<List<ReservaSalaModel>> resposta = new ResponseModel<List<ReservaSalaModel>>();
            try
            {
                var reserva = await _context.ReservaSalas.FirstOrDefaultAsync(r => r.Id == reservaDto.Id);

                if(reserva == null)
                {
                    resposta.Mensagem = "Nenhuma reserva localizada";
                    return resposta;
                }

                reserva.HoraInicio = reservaDto.HoraInicio;
                reserva.HoraFim = reservaDto.HoraFim;

                _context.Update(reserva);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Reserva atualizada com sucesso";
                resposta.Dados = await _context.ReservaSalas.Include(s => s.Sala).Include(p => p.Professor).ToListAsync();
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
