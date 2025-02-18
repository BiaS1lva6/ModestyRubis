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
    public class EnderecoEntregasController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public EnderecoEntregasController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/EnderecoEntregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoEntrega>>> GetEnderecoEntrega()
        {
            return await _context.EnderecoEntrega.ToListAsync();
        }

        // GET: api/EnderecoEntregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoEntrega>> GetEnderecoEntrega(Guid id)
        {
            var enderecoEntrega = await _context.EnderecoEntrega.FindAsync(id);

            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            return enderecoEntrega;
        }

        // PUT: api/EnderecoEntregas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoEntrega(Guid id, EnderecoEntrega enderecoEntrega)
        {
            if (id != enderecoEntrega.EnderecoEntregaId)
            {
                return BadRequest();
            }

            _context.Entry(enderecoEntrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoEntregaExists(id))
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

        // POST: api/EnderecoEntregas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoEntrega>> PostEnderecoEntrega(EnderecoEntrega enderecoEntrega)
        {
            _context.EnderecoEntrega.Add(enderecoEntrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoEntrega", new { id = enderecoEntrega.EnderecoEntregaId }, enderecoEntrega);
        }

        // DELETE: api/EnderecoEntregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoEntrega(Guid id)
        {
            var enderecoEntrega = await _context.EnderecoEntrega.FindAsync(id);
            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            _context.EnderecoEntrega.Remove(enderecoEntrega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoEntregaExists(Guid id)
        {
            return _context.EnderecoEntrega.Any(e => e.EnderecoEntregaId == id);
        }
    }
}
