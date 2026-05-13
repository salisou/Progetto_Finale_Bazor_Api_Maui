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
    public class DocentiController : ControllerBase
    {
        private readonly ScuolaDbContext _context;

        public DocentiController(ScuolaDbContext context)
        {
            _context = context;
        }

        // GET: api/Docenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docenti>>> GetDocenti()
        {
            return await _context.Docenti.ToListAsync();
        }

        // GET: api/Docenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Docenti>> GetDocenti(int id)
        {
            var docenti = await _context.Docenti.FindAsync(id);

            if (docenti == null)
            {
                return NotFound();
            }

            return docenti;
        }

        // PUT: api/Docenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocenti(int id, Docenti docenti)
        {
            if (id != docenti.DocenteId)
            {
                return BadRequest();
            }

            _context.Entry(docenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocentiExists(id))
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

        // POST: api/Docenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Docenti>> PostDocenti(Docenti docenti)
        {
            _context.Docenti.Add(docenti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocenti", new { id = docenti.DocenteId }, docenti);
        }

        // DELETE: api/Docenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocenti(int id)
        {
            var docenti = await _context.Docenti.FindAsync(id);
            if (docenti == null)
            {
                return NotFound();
            }

            _context.Docenti.Remove(docenti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocentiExists(int id)
        {
            return _context.Docenti.Any(e => e.DocenteId == id);
        }
    }
}
