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
    public class DevolucoesController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public DevolucoesController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/Devolucoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devolucao>>> GetDevolucao()
        {
            return await _context.Devolucao.ToListAsync();
        }

        // GET: api/Devolucoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucao>> GetDevolucao(long id)
        {
            var devolucao = await _context.Devolucao.FindAsync(id);

            if (devolucao == null)
            {
                return NotFound();
            }

            return devolucao;
        }

        // PUT: api/Devolucoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevolucao(long id, Devolucao devolucao)
        {
            if (id != devolucao.Id)
            {
                return BadRequest();
            }

            _context.Entry(devolucao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevolucaoExists(id))
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

        // POST: api/Devolucoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Devolucao>> PostDevolucao(Devolucao devolucao)
        {
            _context.Devolucao.Add(devolucao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevolucao", new { id = devolucao.Id }, devolucao);
        }

        // DELETE: api/Devolucoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevolucao(long id)
        {
            var devolucao = await _context.Devolucao.FindAsync(id);
            if (devolucao == null)
            {
                return NotFound();
            }

            _context.Devolucao.Remove(devolucao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DevolucaoExists(long id)
        {
            return _context.Devolucao.Any(e => e.Id == id);
        }
    }
}
