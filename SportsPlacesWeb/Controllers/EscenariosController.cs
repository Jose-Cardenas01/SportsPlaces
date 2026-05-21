using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Models;

namespace SportsPlacesWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscenariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EscenariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/escenarios
        [HttpGet]
        public IActionResult GetEscenarios()
        {
            var escenarios = _context.Escenarios
                .Include(e => e.Sede)
                .Select(e => new EscenarioViewModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Estado = e.Estado.ToString(),   // Enum → string
                    SedesId = e.SedesId,
                    SedeNombre = e.Sede.Nombre
                })
                .ToList();

            return Ok(escenarios);
        }

        // GET: api/escenarios/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetEscenario(Guid id)
        {
            var escenario = _context.Escenarios
                .Include(e => e.Sede)
                .Where(e => e.Id == id)
                .Select(e => new EscenarioViewModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Estado = e.Estado.ToString(),
                    SedesId = e.SedesId,
                    SedeNombre = e.Sede.Nombre
                })
                .FirstOrDefault();

            if (escenario == null)
                return NotFound();

            return Ok(escenario);
        }

        // POST: api/escenarios
        [HttpPost]
        public IActionResult CrearEscenario([FromBody] EscenarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var escenario = new Escenario              // CORREGIDO: era Escenarios (plural)
            {
                Nombre = model.Nombre,
                SedesId = model.SedesId                // CORREGIDO: era SedeId
            };

            _context.Escenarios.Add(escenario);
            _context.SaveChanges();

            var escenarioViewModel = _context.Escenarios
                .Include(e => e.Sede)
                .Where(e => e.Id == escenario.Id)
                .Select(e => new EscenarioViewModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Estado = e.Estado.ToString(),
                    SedesId = e.SedesId,
                    SedeNombre = e.Sede.Nombre
                })
                .FirstOrDefault();

            return CreatedAtAction(nameof(GetEscenario), new { id = escenario.Id }, escenarioViewModel);
        }

        // PUT: api/escenarios/{id}
        [HttpPut("{id:guid}")]                         // CORREGIDO: era int
        public IActionResult EditarEscenario(Guid id, [FromBody] EscenarioViewModel model)
        {
            var escenario = _context.Escenarios.Find(id);
            if (escenario == null)
                return NotFound();

            escenario.Nombre = model.Nombre;
            escenario.SedesId = model.SedesId;         // CORREGIDO: era SedeId

            _context.SaveChanges();

            var escenarioViewModel = _context.Escenarios
                .Include(e => e.Sede)
                .Where(e => e.Id == escenario.Id)
                .Select(e => new EscenarioViewModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Estado = e.Estado.ToString(),
                    SedesId = e.SedesId,
                    SedeNombre = e.Sede.Nombre
                })
                .FirstOrDefault();

            return Ok(escenarioViewModel);
        }

        // DELETE: api/escenarios/{id}
        [HttpDelete("{id:guid}")]                      // CORREGIDO: era int
        public IActionResult EliminarEscenario(Guid id)
        {
            var escenario = _context.Escenarios.Find(id);
            if (escenario == null)
                return NotFound();

            _context.Escenarios.Remove(escenario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
