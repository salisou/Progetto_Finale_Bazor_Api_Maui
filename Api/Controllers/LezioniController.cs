using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LezioniController : ControllerBase
    {
        private readonly ScuolaDbContext _context;

        public LezioniController(ScuolaDbContext context)
        {
            _context = context;
        }

        // GET: api/Lezioni
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lezioni>>> GetLezionis()
        {
            return await _context.Lezionis.ToListAsync();
        }

        // GET: api/Lezioni/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lezioni>> GetLezioni(int id)
        {
            var lezioni = await _context.Lezionis.FindAsync(id);

            if (lezioni == null)
            {
                return NotFound();
            }

            return lezioni;
        }

        // PUT: api/Lezioni/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLezioni(int id, Lezioni lezioni)
        {
            if (id != lezioni.LezioneId)
            {
                return BadRequest();
            }

            _context.Entry(lezioni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LezioniExists(id))
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

        // POST: api/Lezioni
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lezioni>> PostLezioni(Lezioni lezioni)
        {
            _context.Lezionis.Add(lezioni);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLezioni", new { id = lezioni.LezioneId }, lezioni);
        }

        // DELETE: api/Lezioni/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLezioni(int id)
        {
            var lezioni = await _context.Lezionis.FindAsync(id);
            if (lezioni == null)
            {
                return NotFound();
            }

            _context.Lezionis.Remove(lezioni);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LezioniExists(int id)
        {
            return _context.Lezionis.Any(e => e.LezioneId == id);
        }
    }
}
