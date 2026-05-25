using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Enums;
using SportsPlacesWeb.Models;

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

        // GET: api/reservas
        [HttpGet]
        public IActionResult GetReservas()
        {
            var reservas = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    HoraInicio = r.HoraInicio,
                    HoraFin = r.HoraFin,
                    Estado = r.Status,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = string.Empty   // Sede no tiene navegación en la entidad
                })
                .ToList();

            return Ok(reservas);
        }

        // GET: api/reservas/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetReserva(Guid id)
        {
            var reserva = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Where(r => r.Id == id)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    HoraInicio = r.HoraInicio,
                    HoraFin = r.HoraFin,
                    Estado = r.Status,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = string.Empty
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

            var reserva = new Reservas
            {
                Fecha = DateOnly.FromDateTime(model.Fecha),
                HoraInicio = model.HoraInicio,
                HoraFin = model.HoraFin,
                Status = model.Status,
                UsuarioId = model.UsuarioId,
                EspacioId = model.EspacioId,
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            var reservaViewModel = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Where(r => r.Id == reserva.Id)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    HoraInicio = r.HoraInicio,
                    HoraFin = r.HoraFin,
                    Estado = r.Status,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = string.Empty
                })
                .FirstOrDefault();

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reservaViewModel);
        }

        // PUT: api/reservas/{id}
        [HttpPut("{id:guid}")]
        public IActionResult EditarReserva(Guid id, [FromBody] CrearReservaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
                return NotFound();

            reserva.Fecha = DateOnly.FromDateTime(model.Fecha);
            reserva.HoraInicio = model.HoraInicio;
            reserva.HoraFin = model.HoraFin;
            reserva.Status = model.Status;
            reserva.UsuarioId = model.UsuarioId;
            reserva.EspacioId = model.EspacioId;

            _context.SaveChanges();

            var reservaViewModel = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Where(r => r.Id == reserva.Id)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    HoraInicio = r.HoraInicio,
                    HoraFin = r.HoraFin,
                    Estado = r.Status,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = string.Empty
                })
                .FirstOrDefault();

            return Ok(reservaViewModel);
        }

        // PATCH: api/reservas/{id}/estado
        [HttpPatch("{id:guid}/estado")]
        public IActionResult CambiarEstado(Guid id, [FromBody] ReservasStatus nuevoEstado)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
                return NotFound();

            reserva.Status = nuevoEstado;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/reservas/{id}
        [HttpDelete("{id:guid}")]
        public IActionResult EliminarReserva(Guid id)
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