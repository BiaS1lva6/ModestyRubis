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
    public class ComprasController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public ComprasController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompra()
        {
            return await _context.Compra.ToListAsync();
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(Guid id)
        {
            var compra = await _context.Compra.FindAsync(id);

            if (compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        // PUT: api/Compras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(Guid id, Compra compra)
        {
            if (id != compra.CompraId)
            {
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // POST: api/Compras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            _context.Compra.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompra", new { id = compra.CompraId }, compra);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(Guid id)
        {
            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            _context.Compra.Remove(compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Novo endpoint para finalizar o pedido
        [HttpPost("finalizar-pedido")]
        public async Task<IActionResult> FinalizarPedido([FromBody] Guid clienteId)
        {
            var carrinhos = await _context.Carrinho
                .Include(c => c.Produto)
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();

            if (carrinhos == null || !carrinhos.Any())
            {
                return NotFound("Carrinho vazio ou não encontrado.");
            }

            var valorTotal = carrinhos.Sum(c => c.Produto.Preco * c.Quantidade);

            var compra = new Compra
            {
                CompraId = Guid.NewGuid(),
                ClienteId = clienteId,
                DataCompra = DateTime.UtcNow,
                ValorTotal = valorTotal
            };

            _context.Compra.Add(compra);

            foreach (var item in carrinhos)
            {
                item.Produto.Estoque -= item.Quantidade;
                _context.Entry(item.Produto).State = EntityState.Modified;
                _context.Carrinho.Remove(item);
            }

            await _context.SaveChangesAsync();
            return Ok(compra);
        }

        // Novo endpoint para atualizar o status da compra
        [HttpPut("atualizar-status")]
        public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] string status)
        {
            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            compra.Status = status;
            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // Novo endpoint para acompanhar a entrega
        [HttpGet("acompanhar-entrega/{id}")]
        public async Task<ActionResult<string>> AcompanharEntrega(Guid id)
        {
            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra.Status);
        }

        private bool CompraExists(Guid id)
        {
            return _context.Compra.Any(e => e.CompraId == id);
        }
    }
}
