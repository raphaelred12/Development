using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaReuniao_WebAPI.Models;

namespace SalaReuniao_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Agenda[]> GetAllAgendasAsync(bool includeSala = false)
        {
            IQueryable<Agenda> query = _context.Agendas;

            if (includeSala)
            {
                query = query.Include(pe => pe.Sala);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Agenda> GetAgendaAsyncById(int agendaId, bool includeSala)
        {
            IQueryable<Agenda> query = _context.Agendas;

            if (includeSala)
            {
                query = query.Include(pe => pe.Sala);
            }

            query = query.AsNoTracking()
                         .OrderBy(agenda => agenda.Id)
                         .Where(agenda => agenda.Id == agendaId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Agenda[]> GetAgendaAsyncBySalaId(int salaId)
        {
            IQueryable<Agenda> query = _context.Agendas;

            query = query.AsNoTracking()
                         .OrderBy(agenda => agenda.Id)
                         .Where(agenda => agenda.SalaId == salaId);

            return await query.ToArrayAsync();
        }

        public async Task<Sala[]> GetSalasAsyncByAgendaId(bool includeAgenda)
        {
            IQueryable<Sala> query = _context.Salas;

            if (includeAgenda)
            {
                query = query.Include(p => p.Agenda);
            }

            query = query.AsNoTracking()
                         .OrderBy(sala => sala.id);

            return await query.ToArrayAsync();
        }

        public async Task<Sala[]> GetAllSalasAsync(bool includeAgenda = true)
        {
            IQueryable<Sala> query = _context.Salas;

            if (includeAgenda)
            {
                query = query.Include(c => c.Agenda);
            }

            query = query.AsNoTracking()
                         .OrderBy(sala => sala.id);

            return await query.ToArrayAsync();
        }
        public async Task<Sala> GetSalasAsyncById(int salaId, bool includeAgenda = true)
        {
            IQueryable<Sala> query = _context.Salas;

            if (includeAgenda)
            {
                query = query.Include(pe => pe.Agenda);
            }

            query = query.AsNoTracking()
                         .OrderBy(sala => sala.id)
                         .Where(sala => sala.id == salaId);

            return await query.FirstOrDefaultAsync();
        }
    }
}