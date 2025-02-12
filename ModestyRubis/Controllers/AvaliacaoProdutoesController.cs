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
    public class AvaliacaoProdutoesController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public AvaliacaoProdutoesController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/AvaliacaoProdutoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoProduto>>> GetAvaliacaoProduto()
        {
            return await _context.AvaliacaoProduto.ToListAsync();
        }

        // GET: api/AvaliacaoProdutoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoProduto>> GetAvaliacaoProduto(long id)
        {
            var avaliacaoProduto = await _context.AvaliacaoProduto.FindAsync(id);

            if (avaliacaoProduto == null)
            {
                return NotFound();
            }

            return avaliacaoProduto;
        }

        // PUT: api/AvaliacaoProdutoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacaoProduto(long id, AvaliacaoProduto avaliacaoProduto)
        {
            if (id != avaliacaoProduto.Id)
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

        // POST: api/AvaliacaoProdutoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AvaliacaoProduto>> PostAvaliacaoProduto(AvaliacaoProduto avaliacaoProduto)
        {
            _context.AvaliacaoProduto.Add(avaliacaoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacaoProduto", new { id = avaliacaoProduto.Id }, avaliacaoProduto);
        }

        // DELETE: api/AvaliacaoProdutoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacaoProduto(long id)
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

        private bool AvaliacaoProdutoExists(long id)
        {
            return _context.AvaliacaoProduto.Any(e => e.Id == id);
        }
    }
}
