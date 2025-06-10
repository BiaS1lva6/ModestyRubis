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
    public class InformacaoCEPsController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public InformacaoCEPsController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/InformacaoCEPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformacaoCEP>>> GetInformacaoCEP()
        {
            return await _context.InformacaoCEP.ToListAsync();
        }

        // GET: api/InformacaoCEPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformacaoCEP>> GetInformacaoCEP(string id)
        {
            var informacaoCEP = await _context.InformacaoCEP.FindAsync(id);

            if (informacaoCEP == null)
            {
                return NotFound();
            }

            return informacaoCEP;
        }

        // PUT: api/InformacaoCEPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformacaoCEP(string id, InformacaoCEP informacaoCEP)
        {
            if (id != informacaoCEP.CEP)
            {
                return BadRequest();
            }

            _context.Entry(informacaoCEP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacaoCEPExists(id))
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

        // POST: api/InformacaoCEPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InformacaoCEP>> PostInformacaoCEP(InformacaoCEP informacaoCEP)
        {
            _context.InformacaoCEP.Add(informacaoCEP);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InformacaoCEPExists(informacaoCEP.CEP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInformacaoCEP", new { id = informacaoCEP.CEP }, informacaoCEP);
        }

        // DELETE: api/InformacaoCEPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformacaoCEP(string id)
        {
            var informacaoCEP = await _context.InformacaoCEP.FindAsync(id);
            if (informacaoCEP == null)
            {
                return NotFound();
            }

            _context.InformacaoCEP.Remove(informacaoCEP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformacaoCEPExists(string id)
        {
            return _context.InformacaoCEP.Any(e => e.CEP == id);
        }
    }
}
