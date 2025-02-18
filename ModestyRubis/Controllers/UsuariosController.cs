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
    public class UsuariosController : ControllerBase
    {
        private readonly ModestyRubisContext _context;

        public UsuariosController(ModestyRubisContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Novo endpoint para login
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario loginUsuario)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.NomeUsuario == loginUsuario.NomeUsuario && u.Senha == loginUsuario.Senha);

            if (usuario == null)
            {
                return Unauthorized("Nome de usuário ou senha incorretos.");
            }

            usuario.UltimoLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        // Novo endpoint para registrar novo usuário
        [HttpPost("registrar")]
        public async Task<ActionResult<Usuario>> Registrar([FromBody] Usuario novoUsuario)
        {
            if (_context.Usuario.Any(u => u.NomeUsuario == novoUsuario.NomeUsuario))
            {
                return BadRequest("Nome de usuário já está em uso.");
            }

            novoUsuario.UsuarioId = Guid.NewGuid();
            novoUsuario.DataCriacao = DateTime.UtcNow;
            _context.Usuario.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = novoUsuario.UsuarioId }, novoUsuario);
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
