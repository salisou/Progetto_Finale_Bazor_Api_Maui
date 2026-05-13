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
    public class DocentiCorsoeController : ControllerBase
    {
        private readonly ScuolaDbContext _context;

        public DocentiCorsoeController(ScuolaDbContext context)
        {
            _context = context;
        }

        // GET: api/DocentiCorsoe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocentiCorso>>> GetDocentiCorso()
        {
            return await _context.DocentiCorso.ToListAsync();
        }

        // GET: api/DocentiCorsoe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocentiCorso>> GetDocentiCorso(int id)
        {
            var docentiCorso = await _context.DocentiCorso.FindAsync(id);

            if (docentiCorso == null)
            {
                return NotFound();
            }

            return docentiCorso;
        }

        // PUT: api/DocentiCorsoe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocentiCorso(int id, DocentiCorso docentiCorso)
        {
            if (id != docentiCorso.Id)
            {
                return BadRequest();
            }

            _context.Entry(docentiCorso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocentiCorsoExists(id))
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

        // POST: api/DocentiCorsoe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocentiCorso>> PostDocentiCorso(DocentiCorso docentiCorso)
        {
            _context.DocentiCorso.Add(docentiCorso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocentiCorso", new { id = docentiCorso.Id }, docentiCorso);
        }

        // DELETE: api/DocentiCorsoe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocentiCorso(int id)
        {
            var docentiCorso = await _context.DocentiCorso.FindAsync(id);
            if (docentiCorso == null)
            {
                return NotFound();
            }

            _context.DocentiCorso.Remove(docentiCorso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocentiCorsoExists(int id)
        {
            return _context.DocentiCorso.Any(e => e.Id == id);
        }
    }
}
