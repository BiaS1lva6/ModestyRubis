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
    public class HistoricoCarrinhosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public HistoricoCarrinhosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoCarrinhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoCarrinho>>> GetHistoricoCarrinho()
        {
            return await _context.HistoricoCarrinho.ToListAsync();
        }

        // GET: api/HistoricoCarrinhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoCarrinho>> GetHistoricoCarrinho(Guid id)
        {
            var historicoCarrinho = await _context.HistoricoCarrinho.FindAsync(id);

            if (historicoCarrinho == null)
            {
                return NotFound();
            }

            return historicoCarrinho;
        }

        // PUT: api/HistoricoCarrinhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoCarrinho(Guid id, HistoricoCarrinho historicoCarrinho)
        {
            if (id != historicoCarrinho.HistoricoCarrinhoId)
            {
                return BadRequest();
            }

            _context.Entry(historicoCarrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoCarrinhoExists(id))
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

        // POST: api/HistoricoCarrinhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricoCarrinho>> PostHistoricoCarrinho(HistoricoCarrinho historicoCarrinho)
        {
            _context.HistoricoCarrinho.Add(historicoCarrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricoCarrinho", new { id = historicoCarrinho.HistoricoCarrinhoId }, historicoCarrinho);
        }

        // DELETE: api/HistoricoCarrinhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoCarrinho(Guid id)
        {
            var historicoCarrinho = await _context.HistoricoCarrinho.FindAsync(id);
            if (historicoCarrinho == null)
            {
                return NotFound();
            }

            _context.HistoricoCarrinho.Remove(historicoCarrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoCarrinhoExists(Guid id)
        {
            return _context.HistoricoCarrinho.Any(e => e.HistoricoCarrinhoId == id);
        }
    }
}
