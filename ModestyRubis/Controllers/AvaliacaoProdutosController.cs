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
    public class AvaliacaoProdutosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public AvaliacaoProdutosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/AvaliacaoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoProduto>>> GetAvaliacaoProduto()
        {
            return await _context.AvaliacaoProduto.ToListAsync();
        }

        // GET: api/AvaliacaoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoProduto>> GetAvaliacaoProduto(Guid id)
        {
            var avaliacaoProduto = await _context.AvaliacaoProduto.FindAsync(id);

            if (avaliacaoProduto == null)
            {
                return NotFound();
            }

            return avaliacaoProduto;
        }

        // PUT: api/AvaliacaoProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacaoProduto(Guid id, AvaliacaoProduto avaliacaoProduto)
        {
            if (id != avaliacaoProduto.AvaliacaoProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(avaliacaoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoProdutoExists(id))
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

        // POST: api/AvaliacaoProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AvaliacaoProduto>> PostAvaliacaoProduto(AvaliacaoProduto avaliacaoProduto)
        {
            _context.AvaliacaoProduto.Add(avaliacaoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacaoProduto", new { id = avaliacaoProduto.AvaliacaoProdutoId }, avaliacaoProduto);
        }

        // DELETE: api/AvaliacaoProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacaoProduto(Guid id)
        {
            var avaliacaoProduto = await _context.AvaliacaoProduto.FindAsync(id);
            if (avaliacaoProduto == null)
            {
                return NotFound();
            }

            _context.AvaliacaoProduto.Remove(avaliacaoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacaoProdutoExists(Guid id)
        {
            return _context.AvaliacaoProduto.Any(e => e.AvaliacaoProdutoId == id);
        }
    }
}
