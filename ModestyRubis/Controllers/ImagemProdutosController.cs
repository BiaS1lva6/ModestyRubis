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
    public class ImagemProdutosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public ImagemProdutosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/ImagemProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagemProduto>>> GetImagemProduto()
        {
            return await _context.ImagemProduto.ToListAsync();
        }

        // GET: api/ImagemProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImagemProduto>> GetImagemProduto(int id)
        {
            var imagemProduto = await _context.ImagemProduto.FindAsync(id);

            if (imagemProduto == null)
            {
                return NotFound();
            }

            return imagemProduto;
        }

        // PUT: api/ImagemProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagemProduto(int id, ImagemProduto imagemProduto)
        {
            if (id != imagemProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagemProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagemProdutoExists(id))
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

        // POST: api/ImagemProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImagemProduto>> PostImagemProduto(ImagemProduto imagemProduto)
        {
            _context.ImagemProduto.Add(imagemProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagemProduto", new { id = imagemProduto.Id }, imagemProduto);
        }

        // DELETE: api/ImagemProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagemProduto(int id)
        {
            var imagemProduto = await _context.ImagemProduto.FindAsync(id);
            if (imagemProduto == null)
            {
                return NotFound();
            }

            _context.ImagemProduto.Remove(imagemProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagemProdutoExists(int id)
        {
            return _context.ImagemProduto.Any(e => e.Id == id);
        }
    }
}
