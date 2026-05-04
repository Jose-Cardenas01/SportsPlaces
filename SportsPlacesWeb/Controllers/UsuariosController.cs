using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Models;
using System.Linq;

namespace SportsPlacesWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _context.Usuarios
                .Select(u => new UsuarioViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    TipoUsuario = u.TipoUsuario,
                    CorreoInstitucional = u.CorreoInstitucional
                })
                .ToList();

            return Ok(usuarios);
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _context.Usuarios
                .Where(u => u.Id == id)
                .Select(u => new UsuarioViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    TipoUsuario = u.TipoUsuario,
                    CorreoInstitucional = u.CorreoInstitucional
                })
                .FirstOrDefault();

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nombre = model.Nombre,
                TipoUsuario = model.TipoUsuario,
                CorreoInstitucional = model.CorreoInstitucional
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, model);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public IActionResult EditarUsuario(int id, [FromBody] UsuarioViewModel model)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            usuario.Nombre = model.Nombre;
            usuario.TipoUsuario = model.TipoUsuario;
            usuario.CorreoInstitucional = model.CorreoInstitucional;

            _context.SaveChanges();

            return Ok(model);
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
