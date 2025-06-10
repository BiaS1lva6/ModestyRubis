using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModestyRubis.Data;
using ModestyRubis.Models;

namespace ModestyRubis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAtividadesController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public LogAtividadesController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/LogAtividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAtividade>>> GetLogAtividades()
        {
            return await _context.LogAtividades.ToListAsync();
        }

        // GET: api/LogAtividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogAtividade>> GetLogAtividade(int id)
        {
            var logAtividade = await _context.LogAtividades.FindAsync(id);

            if (logAtividade == null)
            {
                return NotFound();
            }

            return logAtividade;
        }

        // PUT: api/LogAtividades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAtividade(int id, LogAtividade logAtividade)
        {
            if (id != logAtividade.Id)
            {
                return BadRequest();
            }

            _context.Entry(logAtividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAtividadeExists(id))
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

        // POST: api/LogAtividades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogAtividade>> PostLogAtividade(LogAtividade logAtividade)
        {
            _context.LogAtividades.Add(logAtividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogAtividade", new { id = logAtividade.Id }, logAtividade);
        }

        // DELETE: api/LogAtividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAtividade(int id)
        {
            var logAtividade = await _context.LogAtividades.FindAsync(id);
            if (logAtividade == null)
            {
                return NotFound();
            }

            _context.LogAtividades.Remove(logAtividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogAtividadeExists(int id)
        {
            return _context.LogAtividades.Any(e => e.Id == id);
        }
    }
}
