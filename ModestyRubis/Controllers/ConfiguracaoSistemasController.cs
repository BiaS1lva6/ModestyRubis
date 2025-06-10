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
    public class ConfiguracaoSistemasController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public ConfiguracaoSistemasController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/ConfiguracaoSistemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracaoSistema>>> GetConfiguracaoSistemas()
        {
            return await _context.ConfiguracaoSistemas.ToListAsync();
        }

        // GET: api/ConfiguracaoSistemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracaoSistema>> GetConfiguracaoSistema(int id)
        {
            var configuracaoSistema = await _context.ConfiguracaoSistemas.FindAsync(id);

            if (configuracaoSistema == null)
            {
                return NotFound();
            }

            return configuracaoSistema;
        }

        // PUT: api/ConfiguracaoSistemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracaoSistema(int id, ConfiguracaoSistema configuracaoSistema)
        {
            if (id != configuracaoSistema.Id)
            {
                return BadRequest();
            }

            _context.Entry(configuracaoSistema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracaoSistemaExists(id))
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

        // POST: api/ConfiguracaoSistemas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfiguracaoSistema>> PostConfiguracaoSistema(ConfiguracaoSistema configuracaoSistema)
        {
            _context.ConfiguracaoSistemas.Add(configuracaoSistema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfiguracaoSistema", new { id = configuracaoSistema.Id }, configuracaoSistema);
        }

        // DELETE: api/ConfiguracaoSistemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracaoSistema(int id)
        {
            var configuracaoSistema = await _context.ConfiguracaoSistemas.FindAsync(id);
            if (configuracaoSistema == null)
            {
                return NotFound();
            }

            _context.ConfiguracaoSistemas.Remove(configuracaoSistema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfiguracaoSistemaExists(int id)
        {
            return _context.ConfiguracaoSistemas.Any(e => e.Id == id);
        }
    }
}
