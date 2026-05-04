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
    public class SedesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SedesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/sedes
        [HttpGet]
        public IActionResult GetSedes()
        {
            var sedes = _context.Sedes
                .Select(s => new SedeViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion
                })
                .ToList();

            return Ok(sedes);
        }

        // GET: api/sedes/5
        [HttpGet("{id}")]
        public IActionResult GetSede(int id)
        {
            var sede = _context.Sedes
                .Where(s => s.Id == id)
                .Select(s => new SedeViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion
                })
                .FirstOrDefault();

            if (sede == null)
                return NotFound();

            return Ok(sede);
        }

        // POST: api/sedes
        [HttpPost]
        public IActionResult CrearSede([FromBody] SedeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sede = new Sede
            {
                Nombre = model.Nombre,
                Direccion = model.Direccion
            };

            _context.Sedes.Add(sede);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSede), new { id = sede.Id }, model);
        }

        // PUT: api/sedes/5
        [HttpPut("{id}")]
        public IActionResult EditarSede(int id, [FromBody] SedeViewModel model)
        {
            var sede = _context.Sedes.Find(id);
            if (sede == null)
                return NotFound();

            sede.Nombre = model.Nombre;
            sede.Direccion = model.Direccion;

            _context.SaveChanges();

            return Ok(model);
        }

        // DELETE: api/sedes/5
        [HttpDelete("{id}")]
        public IActionResult EliminarSede(int id)
        {
            var sede = _context.Sedes.Find(id);
            if (sede == null)
                return NotFound();

            _context.Sedes.Remove(sede);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
