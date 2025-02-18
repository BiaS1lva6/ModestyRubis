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
    public class DevolucaosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public DevolucaosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/Devolucaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devolucao>>> GetDevolucao()
        {
            return await _context.Devolucao.ToListAsync();
        }

        // GET: api/Devolucaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucao>> GetDevolucao(Guid id)
        {
            var devolucao = await _context.Devolucao.FindAsync(id);

            if (devolucao == null)
            {
                return NotFound();
            }

            return devolucao;
        }

        // PUT: api/Devolucaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevolucao(Guid id, Devolucao devolucao)
        {
            if (id != devolucao.DevolucaoId)
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

        // POST: api/Devolucaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Devolucao>> PostDevolucao(Devolucao devolucao)
        {
            _context.Devolucao.Add(devolucao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevolucao", new { id = devolucao.DevolucaoId }, devolucao);
        }

        // DELETE: api/Devolucaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevolucao(Guid id)
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

        private bool DevolucaoExists(Guid id)
        {
            return _context.Devolucao.Any(e => e.DevolucaoId == id);
        }
    }
}
