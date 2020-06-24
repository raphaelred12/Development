using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaReuniao_WebAPI.Data;
using SalaReuniao_WebAPI.Models;

namespace SalaReuniao_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        public readonly IRepository Repo;
        public SalaController(IRepository repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Repo.GetAllSalasAsync(true);
            
            return Ok(result);
        } 

        [HttpGet("{salaId}")]
        public async Task<IActionResult> GetSalasAsyncById(int salaId)
        {
            var result = await Repo.GetSalasAsyncById(salaId, true);
            
            return Ok(result);
        }

        [HttpGet("BySala/{salaId}")]
        public async Task<IActionResult> GetSalasAsyncByAgendaId()
        {
            var result = await Repo.GetSalasAsyncByAgendaId(false);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> post(Sala model)
        {
            Repo.Add(model);
            
            if (await Repo.SaveChangesAsync()){
                return Ok(model);
            }
            return BadRequest();
        } 

        [HttpPut("{salaId}")]
        public async Task<IActionResult> put(int salaId, Sala model)
        {
            var sala = await Repo.GetSalasAsyncById(salaId, false);
            if (sala == null) return NotFound();

            Repo.Update(model);
            
            if (await Repo.SaveChangesAsync()){
                return Ok(model);
            }
            return BadRequest();
        } 

        [HttpDelete("{salaId}")]
        public async Task<IActionResult> delete(int salaId)
        {
            var sala = await Repo.GetSalasAsyncById(salaId, false);
            if (sala == null) return NotFound();

            Repo.Delete(sala);
            
            if (await Repo.SaveChangesAsync()){
                return Ok("Deletado.");
            }
            return BadRequest();
        }
    }
}