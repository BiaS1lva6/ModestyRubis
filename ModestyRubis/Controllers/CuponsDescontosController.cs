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
    public class CuponsDescontosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public CuponsDescontosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/CuponsDescontos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CupomDesconto>>> GetCupomDesconto()
        {
            return await _context.CupomDesconto.ToListAsync();
        }

        // GET: api/CuponsDescontos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CupomDesconto>> GetCupomDesconto(long id)
        {
            var cupomDesconto = await _context.CupomDesconto.FindAsync(id);

            if (cupomDesconto == null)
            {
                return NotFound();
            }

            return cupomDesconto;
        }

        // PUT: api/CuponsDescontos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupomDesconto(long id, CupomDesconto cupomDesconto)
        {
            if (id != cupomDesconto.Id)
            {
                return BadRequest();
            }

            _context.Entry(cupomDesconto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CupomDescontoExists(id))
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

        // POST: api/CuponsDescontos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CupomDesconto>> PostCupomDesconto(CupomDesconto cupomDesconto)
        {
            _context.CupomDesconto.Add(cupomDesconto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCupomDesconto", new { id = cupomDesconto.Id }, cupomDesconto);
        }

        // DELETE: api/CuponsDescontos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupomDesconto(long id)
        {
            var cupomDesconto = await _context.CupomDesconto.FindAsync(id);
            if (cupomDesconto == null)
            {
                return NotFound();
            }

            _context.CupomDesconto.Remove(cupomDesconto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CupomDescontoExists(long id)
        {
            return _context.CupomDesconto.Any(e => e.Id == id);
        }
    }
}
