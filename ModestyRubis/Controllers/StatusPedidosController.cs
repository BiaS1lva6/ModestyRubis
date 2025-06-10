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
    public class StatusPedidosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public StatusPedidosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/StatusPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusPedido>>> GetStatusPedido()
        {
            return await _context.StatusPedido.ToListAsync();
        }

        // GET: api/StatusPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusPedido>> GetStatusPedido(int id)
        {
            var statusPedido = await _context.StatusPedido.FindAsync(id);

            if (statusPedido == null)
            {
                return NotFound();
            }

            return statusPedido;
        }

        // PUT: api/StatusPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusPedido(int id, StatusPedido statusPedido)
        {
            if (id != statusPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusPedidoExists(id))
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

        // POST: api/StatusPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusPedido>> PostStatusPedido(StatusPedido statusPedido)
        {
            _context.StatusPedido.Add(statusPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusPedido", new { id = statusPedido.Id }, statusPedido);
        }

        // DELETE: api/StatusPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusPedido(int id)
        {
            var statusPedido = await _context.StatusPedido.FindAsync(id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            _context.StatusPedido.Remove(statusPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusPedidoExists(int id)
        {
            return _context.StatusPedido.Any(e => e.Id == id);
        }
    }
}
