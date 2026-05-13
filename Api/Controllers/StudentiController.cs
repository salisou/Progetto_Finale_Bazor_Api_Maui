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
    public class StudentiController : ControllerBase
    {
        private readonly ScuolaDbContext _context;

        public StudentiController(ScuolaDbContext context)
        {
            _context = context;
        }

        // GET: api/Studenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studenti>>> GetStudentis()
        {
            return await _context.Studentis.ToListAsync();
        }

        // GET: api/Studenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studenti>> GetStudenti(int id)
        {
            var studenti = await _context.Studentis.FindAsync(id);

            if (studenti == null)
            {
                return NotFound();
            }

            return studenti;
        }

        // PUT: api/Studenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudenti(int id, Studenti studenti)
        {
            if (id != studenti.StudenteId)
            {
                return BadRequest();
            }

            _context.Entry(studenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentiExists(id))
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

        // POST: api/Studenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studenti>> PostStudenti(Studenti studenti)
        {
            _context.Studentis.Add(studenti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudenti", new { id = studenti.StudenteId }, studenti);
        }

        // DELETE: api/Studenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudenti(int id)
        {
            var studenti = await _context.Studentis.FindAsync(id);
            if (studenti == null)
            {
                return NotFound();
            }

            _context.Studentis.Remove(studenti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentiExists(int id)
        {
            return _context.Studentis.Any(e => e.StudenteId == id);
        }
    }
}
