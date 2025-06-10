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
    public class TamanhoProdutosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public TamanhoProdutosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/TamanhoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TamanhoProduto>>> GetTamanhoProduto()
        {
            return await _context.TamanhoProduto.ToListAsync();
        }

        // GET: api/TamanhoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TamanhoProduto>> GetTamanhoProduto(int id)
        {
            var tamanhoProduto = await _context.TamanhoProduto.FindAsync(id);

            if (tamanhoProduto == null)
            {
                return NotFound();
            }

            return tamanhoProduto;
        }

        // PUT: api/TamanhoProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTamanhoProduto(int id, TamanhoProduto tamanhoProduto)
        {
            if (id != tamanhoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tamanhoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamanhoProdutoExists(id))
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

        // POST: api/TamanhoProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TamanhoProduto>> PostTamanhoProduto(TamanhoProduto tamanhoProduto)
        {
            _context.TamanhoProduto.Add(tamanhoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTamanhoProduto", new { id = tamanhoProduto.Id }, tamanhoProduto);
        }

        // DELETE: api/TamanhoProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTamanhoProduto(int id)
        {
            var tamanhoProduto = await _context.TamanhoProduto.FindAsync(id);
            if (tamanhoProduto == null)
            {
                return NotFound();
            }

            _context.TamanhoProduto.Remove(tamanhoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TamanhoProdutoExists(int id)
        {
            return _context.TamanhoProduto.Any(e => e.Id == id);
        }
    }
}
