using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using DatiCondivisi.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IscrizioniController : ControllerBase
    {
        private readonly ScuolaDbContext _context;

        public IscrizioniController(ScuolaDbContext context)
        {
            _context = context;
        }

        // GET: api/Iscrizioni
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iscrizioni>>> GetIscrizioni()
        {
            return await _context.Iscrizioni.ToListAsync();
        }

        // GET: api/Iscrizioni/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iscrizioni>> GetIscrizioni(int id)
        {
            var iscrizioni = await _context.Iscrizioni.FindAsync(id);

            if (iscrizioni == null)
            {
                return NotFound();
            }

            return iscrizioni;
        }

        // PUT: api/Iscrizioni/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIscrizioni(int id, Iscrizioni iscrizioni)
        {
            if (id != iscrizioni.IscrizioneId)
            {
                return BadRequest();
            }

            _context.Entry(iscrizioni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IscrizioniExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Iscrizioni
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Iscrizioni>> PostIscrizioni(Iscrizioni iscrizioni)
        {
            _context.Iscrizioni.Add(iscrizioni);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIscrizioni", new { id = iscrizioni.IscrizioneId }, iscrizioni);
        }

        // DELETE: api/Iscrizioni/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIscrizioni(int id)
        {
            var iscrizioni = await _context.Iscrizioni.FindAsync(id);
            if (iscrizioni == null)
            {
                return NotFound();
            }

            _context.Iscrizioni.Remove(iscrizioni);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IscrizioniExists(int id)
        {
            return _context.Iscrizioni.Any(e => e.IscrizioneId == id);
        }
    }
}
