using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModestyRubis.Data;
using ModestyRubis.Models;
using ModestyRubis.Services;

namespace ModestyRubis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FretesController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public FretesController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/Fretes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frete>>> GetFrete()
        {
            return await _context.Frete.ToListAsync();
        }

        // GET: api/Fretes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Frete>> GetFrete(int id)
        {
            var frete = await _context.Frete.FindAsync(id);

            if (frete == null)
            {
                return NotFound();
            }

            return frete;
        }

        // PUT: api/Fretes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrete(int id, Frete frete)
        {
            if (id != frete.Id)
            {
                return BadRequest();
            }

            _context.Entry(frete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreteExists(id))
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

        // POST: api/Fretes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Frete>> PostFrete(Frete frete)
        {
            var freteService = new CorreiosFreteService();
            try
            {
                var resultado = await freteService.CalcularFreteAsync(frete);
                frete.Valor = resultado.valor;
                frete.PrazoEntrega = resultado.prazo;
            }
            catch
            {
                return StatusCode(500, "Erro ao calcular o frete com os Correios");
            }

            _context.Frete.Add(frete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrete", new { id = frete.Id }, frete);
        }


        // DELETE: api/Fretes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrete(int id)
        {
            var frete = await _context.Frete.FindAsync(id);
            if (frete == null)
            {
                return NotFound();
            }

            _context.Frete.Remove(frete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public class CalculoFreteRequest
        {
            public decimal ValorTotal { get; set; }
        }

        [HttpPost("CalcularFrete")]
        public ActionResult<decimal> CalcularFrete([FromBody] CalculoFreteRequest request)
        {
            if (request.ValorTotal < 0)
                return BadRequest("O valor total deve ser maior ou igual a zero.");

            decimal resultado = request.ValorTotal * 0.20m;
            return Ok(resultado);
        }


        private bool FreteExists(int id)
        {
            return _context.Frete.Any(e => e.Id == id);
        }
    }
}
