using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaReuniao_WebAPI.Data;
using SalaReuniao_WebAPI.Models;

namespace SalaReuniao_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {
        public readonly IRepository Repo;
        public AgendaController(IRepository repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Repo.GetAllAgendasAsync(true);
            
            return Ok(result);
        }        
        
        [HttpGet("{AgendaId}")]
        public async Task<IActionResult> GetByAgendaId(int AgendaId)
        {
            var result = await Repo.GetAgendaAsyncById(AgendaId, true);
            
            return Ok(result);
        }

        [HttpGet("BySala/{salaId}")]
        public async Task<IActionResult> GetAgendaAsyncBySalaId(int salaId)
        {
            var result = await Repo.GetAgendaAsyncBySalaId(salaId);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> post(Agenda model)
        {
            Repo.Add(model);
            
            if (await Repo.SaveChangesAsync()){
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPut("{agendaId}")]
        public async Task<IActionResult> put(int agendaId, Agenda model)
        {
            var agenda = await Repo.GetAgendaAsyncById(agendaId, false);
            if (agenda == null) return NotFound();

            Repo.Update(model);
            
            if (await Repo.SaveChangesAsync()){
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete("{agendaId}")]
        public async Task<IActionResult> delete(int agendaId)
        {
            var agenda = await Repo.GetAgendaAsyncById(agendaId, false);
            if (agenda == null) return NotFound();

            Repo.Delete(agenda);
            
            if (await Repo.SaveChangesAsync()){
                return Ok(new { message = "Deletado" });
            }
            return BadRequest();
        }
    }
}