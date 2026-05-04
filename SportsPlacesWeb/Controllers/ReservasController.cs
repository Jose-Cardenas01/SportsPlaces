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
    public class ReservasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public IActionResult GetReservas()
        {
            var reservas = _context.Reservas
            .Include(r => r.Usuario)
            .Include(r => r.Espacio)
            .Include(r => r.Sede)
            .Select(r => new ReservaViewModel
            {
                Id = r.Id,
                Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue), // convertir DateOnly a DateTime
                Hora = r.Hora,
                Estado = r.Estado,
                UsuarioNombre = r.Usuario.Nombre,
                EspacioNombre = r.Espacio.Nombre,
                SedeNombre = r.Sede.Nombre
            })
            .ToList(); ;

            return Ok(reservas);
        }

        // GET: api/reservas/5
        [HttpGet("{id}")]
        public IActionResult GetReserva(int id)
        {
            var reserva = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Include(r => r.Sede)
                .Where(r => r.Id == id)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue), // convertir DateOnly a DateTime
                    Hora = r.Hora,
                    Estado = r.Estado,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        // POST: api/reservas
        [HttpPost]
        public IActionResult CrearReserva([FromBody] CrearReservaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reserva = new Reserva
            {
                Fecha = DateOnly.FromDateTime(model.Fecha), // convertir DateTime a DateOnly
                Hora = model.Hora,
                Estado = "Pendiente",
                UsuarioId = model.UsuarioId,
                EspacioId = model.EspacioId,
                SedesId = model.SedeId
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            // Proyección a ViewModel para devolver datos enriquecidos
            var reservaViewModel = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Include(r => r.Sede)
                .Where(r => r.Id == reserva.Id)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    Hora = r.Hora,
                    Estado = r.Estado,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reservaViewModel);
        }

        // PUT: api/reservas/5
        [HttpPut("{id}")]
        public IActionResult EditarReserva(int id, [FromBody] ReservaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
                return NotFound();

            // Actualizar propiedades
            reserva.Estado = model.Estado;
            reserva.Hora = model.Hora;
            reserva.Fecha = DateOnly.FromDateTime(model.Fecha); // convertir DateTime a DateOnly

            _context.SaveChanges();

            // Proyección a ViewModel para devolver datos actualizados
            var reservaViewModel = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Include(r => r.Sede)
                .Where(r => r.Id == reserva.Id)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    Hora = r.Hora,
                    Estado = r.Estado,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            return Ok(reservaViewModel);
        }

        // DELETE: api/reservas/5
        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
                return NotFound();

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
