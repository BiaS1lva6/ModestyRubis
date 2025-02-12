using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModestyRubis.Data;
using YourNamespace.Models;

namespace ModestyRubis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosEntregasController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public EnderecosEntregasController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/EnderecosEntregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoEntrega>>> GetEnderecoEntrega()
        {
            return await _context.EnderecoEntrega.ToListAsync();
        }

        // GET: api/EnderecosEntregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoEntrega>> GetEnderecoEntrega(long id)
        {
            var enderecoEntrega = await _context.EnderecoEntrega.FindAsync(id);

            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            return enderecoEntrega;
        }

        // PUT: api/EnderecosEntregas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoEntrega(long id, EnderecoEntrega enderecoEntrega)
        {
            if (id != enderecoEntrega.Id)
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

        // POST: api/EnderecosEntregas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoEntrega>> PostEnderecoEntrega(EnderecoEntrega enderecoEntrega)
        {
            _context.EnderecoEntrega.Add(enderecoEntrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoEntrega", new { id = enderecoEntrega.Id }, enderecoEntrega);
        }

        // DELETE: api/EnderecosEntregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoEntrega(long id)
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

        private bool EnderecoEntregaExists(long id)
        {
            return _context.EnderecoEntrega.Any(e => e.Id == id);
        }
    }
}
