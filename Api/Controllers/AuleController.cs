using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using DatiCondivisi.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuleController : ControllerBase
    {
        private readonly ScuolaDbContext _context;

        public AuleController(ScuolaDbContext context)
        {
            _context = context;
        }

        // GET: api/Aule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aule>>> GetAules()
        {
            return await _context.Aule.ToListAsync();
        }

        // GET: api/Aule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aule>> GetAule(int id)
        {
            var aule = await _context.Aule.FindAsync(id);

            if (aule == null)
            {
                return NotFound();
            }

            return aule;
        }

        // PUT: api/Aule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAule(int id, Aule aule)
        {
            if (id != aule.AulaId)
            {
                return BadRequest();
            }

            _context.Entry(aule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuleExists(id))
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

        // POST: api/Aule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aule>> PostAule(Aule aule)
        {
            _context.Aule.Add(aule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAule", new { id = aule.AulaId }, aule);
        }

        // DELETE: api/Aule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAule(int id)
        {
            var aule = await _context.Aule.FindAsync(id);
            if (aule == null)
            {
                return NotFound();
            }

            _context.Aule.Remove(aule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuleExists(int id)
        {
            return _context.Aule.Any(e => e.AulaId == id);
        }
    }
}
