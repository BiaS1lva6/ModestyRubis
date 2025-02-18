
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
    public class CarrinhosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public CarrinhosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/Carrinhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrinho>>> GetCarrinho()
        {
            return await _context.Carrinho.ToListAsync();
        }

        // GET: api/Carrinhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrinho>> GetCarrinho(Guid id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);

            if (carrinho == null)
            {
                return NotFound();
            }

            return carrinho;
        }

        // PUT: api/Carrinhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrinho(Guid id, Carrinho carrinho)
        {
            if (id != carrinho.CarrinhoId)
            {
                return BadRequest();
            }

            _context.Entry(carrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrinhoExists(id))
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

        // POST: api/Carrinhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrinho>> PostCarrinho(Carrinho carrinho)
        {
            _context.Carrinho.Add(carrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrinho", new { id = carrinho.CarrinhoId }, carrinho);
        }

        // DELETE: api/Carrinhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrinho(Guid id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }

            _context.Carrinho.Remove(carrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Novo endpoint para adicionar produto ao carrinho
        [HttpPost("add-produto")]
        public async Task<IActionResult> AddProductToCarrinho([FromBody] Carrinho carrinho)
        {
            var existingCarrinho = await _context.Carrinho
                .FirstOrDefaultAsync(c => c.ClienteId == carrinho.ClienteId && c.ProdutoId == carrinho.ProdutoId);

            if (existingCarrinho != null)
            {
                existingCarrinho.Quantidade += carrinho.Quantidade;
                _context.Entry(existingCarrinho).State = EntityState.Modified;
            }
            else
            {
                _context.Carrinho.Add(carrinho);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Novo endpoint para remover produto do carrinho
        [HttpPost("remove-produto")]
        public async Task<IActionResult> RemoveProductFromCarrinho([FromBody] Carrinho carrinho)
        {
            var existingCarrinho = await _context.Carrinho
                .FirstOrDefaultAsync(c => c.ClienteId == carrinho.ClienteId && c.ProdutoId == carrinho.ProdutoId);

            if (existingCarrinho == null)
            {
                return NotFound("Produto não encontrado no carrinho.");
            }

            if (existingCarrinho.Quantidade > carrinho.Quantidade)
            {
                existingCarrinho.Quantidade -= carrinho.Quantidade;
                _context.Entry(existingCarrinho).State = EntityState.Modified;
            }
            else
            {
                _context.Carrinho.Remove(existingCarrinho);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Novo endpoint para calcular o valor total do carrinho
        [HttpGet("valor-total/{clienteId}")]
        public async Task<ActionResult<decimal>> GetValorTotalCarrinho(Guid clienteId)
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

            return Ok(valorTotal);
        }

        private bool CarrinhoExists(Guid id)
        {
            return _context.Carrinho.Any(e => e.CarrinhoId == id);
        }
    }
}
