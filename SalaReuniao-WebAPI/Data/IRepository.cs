using System.Threading.Tasks;
using SalaReuniao_WebAPI.Models;

namespace SalaReuniao_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //AGENDA
        Task<Agenda[]> GetAllAgendasAsync(bool includeSala);        
        Task<Agenda[]> GetAgendaAsyncBySalaId(int agendaId);
        Task<Agenda> GetAgendaAsyncById(int agendaId, bool includeSala);
        
        //SALA
        Task<Sala[]> GetAllSalasAsync(bool includeAgenda);
        Task<Sala> GetSalasAsyncById(int salaId, bool includeAgenda);
        Task<Sala[]> GetSalasAsyncByAgendaId(bool includeAgenda);
    }
}