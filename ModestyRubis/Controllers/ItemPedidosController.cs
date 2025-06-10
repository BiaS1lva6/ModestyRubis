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
    public class ItemPedidosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public ItemPedidosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/ItemPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItemPedido()
        {
            return await _context.ItemPedido.ToListAsync();
        }

        // POST: api/ItemPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPedido>> PostItemPedido(ItemPedido itemPedido)
        {
            _context.ItemPedido.Add(itemPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPedido", new { id = itemPedido.Id }, itemPedido);
        }

        // DELETE: api/ItemPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            _context.ItemPedido.Remove(itemPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
