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
    public class HistoricoStatusPedidosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public HistoricoStatusPedidosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoStatusPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoStatusPedido>>> GetHistoricoStatusPedido()
        {
            return await _context.HistoricoStatusPedido.ToListAsync();
        }

        // GET: api/HistoricoStatusPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoStatusPedido>> GetHistoricoStatusPedido(int id)
        {
            var historicoStatusPedido = await _context.HistoricoStatusPedido.FindAsync(id);

            if (historicoStatusPedido == null)
            {
                return NotFound();
            }

            return historicoStatusPedido;
        }

        // PUT: api/HistoricoStatusPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoStatusPedido(int id, HistoricoStatusPedido historicoStatusPedido)
        {
            if (id != historicoStatusPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(historicoStatusPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoStatusPedidoExists(id))
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

        // POST: api/HistoricoStatusPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricoStatusPedido>> PostHistoricoStatusPedido(HistoricoStatusPedido historicoStatusPedido)
        {
            _context.HistoricoStatusPedido.Add(historicoStatusPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricoStatusPedido", new { id = historicoStatusPedido.Id }, historicoStatusPedido);
        }

        // DELETE: api/HistoricoStatusPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoStatusPedido(int id)
        {
            var historicoStatusPedido = await _context.HistoricoStatusPedido.FindAsync(id);
            if (historicoStatusPedido == null)
            {
                return NotFound();
            }

            _context.HistoricoStatusPedido.Remove(historicoStatusPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoStatusPedidoExists(int id)
        {
            return _context.HistoricoStatusPedido.Any(e => e.Id == id);
        }
    }
}
