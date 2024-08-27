using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Dto.ReservaMaterial;
using ReserveAqui.Models;

namespace ReserveAqui.Services.ReservaMaterial
{
    public class ReservaMaterialService : IReservaMaterialService
    { 
        private readonly AppDbContext _context;

        public ReservaMaterialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ReservaMaterialModel>>> Create(ReservaMaterialCriacaoDto reservaDto)
        {
            var resposta = new ResponseModel<List<ReservaMaterialModel>>();
            try
            {
                var material = await _context.Materiais.FirstOrDefaultAsync(m => m.Id == reservaDto.IdMaterial);
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == reservaDto.IdProfessor);

                if (material == null)
                {
                    resposta.Mensagem = "Material não encontrado";
                    return resposta;
                }

                if(professor == null)
                {
                    resposta.Mensagem = "Professor não encontrado";
                    return resposta;
                }

                bool existeConflito = await _context.ReservaMateriais
               .AnyAsync(r => r.Material.Id == reservaDto.IdMaterial &&
                          ((reservaDto.HoraInicio >= r.HoraInicio && reservaDto.HoraInicio < r.HoraFim) ||
                           (reservaDto.HoraFim > r.HoraInicio && reservaDto.HoraFim <= r.HoraFim) ||
                           (reservaDto.HoraInicio < r.HoraInicio && reservaDto.HoraFim > r.HoraFim)));


                if (existeConflito)
                {
                    resposta.Mensagem = "Não será possível agendar pois já existe reserva para este horário";
                    return resposta;
                }

                var reserva = new ReservaMaterialModel()
                {
                    HoraInicio = reservaDto.HoraInicio,
                    HoraFim = reservaDto.HoraFim,
                    Material = material,
                    Professor = professor,
                };


                _context.Add(reserva);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Reserva criada com sucesso";
                resposta.Dados = await _context.ReservaMateriais.Include(m => m.Material).Include(p => p.Professor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReservaMaterialModel>>> Delete(int id)
        {
            var resposta = new ResponseModel<List<ReservaMaterialModel>>();

            try
            {
                var reserva = await _context.ReservaMateriais.FirstOrDefaultAsync(r => r.Id == id);

                if (reserva == null)
                {
                    resposta.Mensagem = "Reserva não localizada";
                    return resposta; 
                }

                _context.Remove(reserva);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Reserva removida com sucesso";
                resposta.Dados = await _context.ReservaMateriais.Include(m => m.Material).Include(p => p.Professor).ToListAsync();
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ReservaMaterialModel>> Get(int id)
        {
            var resposta = new ResponseModel<ReservaMaterialModel>();

            try
            {
                var reserva = await _context.ReservaMateriais.FirstOrDefaultAsync(r => r.Id == id);

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

        public async Task<ResponseModel<List<ReservaMaterialModel>>> GetAll()
        {
            var resposta = new ResponseModel<List<ReservaMaterialModel>>();
            try
            {
                var reservas = await _context.ReservaMateriais.Include(m => m.Material).Include(p => p.Professor).ToListAsync();

                resposta.Mensagem = "Registros coletados com sucesso";
                resposta.Dados = reservas;
                return resposta;

                
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReservaMaterialModel>>> Update(ReservaMaterialEdicaoDto reservaDto)
        {
            var resposta = new ResponseModel<List<ReservaMaterialModel>>();
            try
            {
                var reserva = await _context.ReservaMateriais.FirstOrDefaultAsync(r => r.Id == reservaDto.Id);

                if (reserva == null)
                {
                    resposta.Mensagem = "Reserva não encontrada";
                    return resposta;
                }

                reserva.HoraInicio = reservaDto.HoraInicio;
                reserva.HoraFim = reservaDto.HoraFim;
                reserva.Material = reservaDto.Material;

                _context.Update(reserva);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Reserva atualizada com sucesso";
                resposta.Dados = await _context.ReservaMateriais.Include(m => m.Material).Include(p => p.Professor).ToListAsync();
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
