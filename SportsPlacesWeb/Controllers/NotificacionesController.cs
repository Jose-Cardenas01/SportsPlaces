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
    public class NotificacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificacionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/notificaciones
        [HttpGet]
        public IActionResult GetNotificaciones()
        {
            var notificaciones = _context.Notificaciones
                .Include(n => n.Usuario)
                .Select(n => new NotificacionViewModel
                {
                    Id = n.Id,
                    Mensaje = n.Mensaje,
                    Fecha = n.FechaEnvio.ToDateTime(TimeOnly.MinValue),
                    UsuarioNombre = n.Usuario.Nombre
                })
                .ToList();

            return Ok(notificaciones);
        }

        // GET: api/notificaciones/{id}
        [HttpGet("{id}")]
        public IActionResult GetNotificacion(Guid id)
        {
            var notificacion = _context.Notificaciones
                .Include(n => n.Usuario)
                .Where(n => n.Id == id)
                .Select(n => new NotificacionViewModel
                {
                    Id = n.Id,
                    Mensaje = n.Mensaje,
                    Fecha = n.FechaEnvio.ToDateTime(TimeOnly.MinValue),
                    UsuarioNombre = n.Usuario.Nombre
                })
                .FirstOrDefault();

            if (notificacion == null)
                return NotFound();

            return Ok(notificacion);
        }

        // POST: api/notificaciones
        [HttpPost]
        public IActionResult CrearNotificacion([FromBody] CrearNotificacionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Notificaciones noty = new Notificaciones
            {
                Id = Guid.NewGuid(),
                Mensaje = model.Mensaje,
                FechaEnvio = DateOnly.FromDateTime(model.Fecha),
                TipoNotificacion = "correo",
                UsuarioId = model.UsuarioId
            };


            _context.Set<Notificaciones>().Add(noty);
            _context.SaveChanges();

            var notificacionViewModel = _context.Notificaciones
                .Include(n => n.Usuario)
                .Where(n => n.Id == noty.Id)
                .Select(n => new NotificacionViewModel
                {
                    Id = n.Id,
                    Mensaje = n.Mensaje,
                    Fecha = n.FechaEnvio.ToDateTime(TimeOnly.MinValue),
                    UsuarioNombre = n.Usuario.Nombre
                })
                .FirstOrDefault();

            return CreatedAtAction(nameof(GetNotificacion), new { id = noty.Id }, notificacionViewModel);
        }

        // PUT: api/notificaciones/{id}
        [HttpPut("{id}")]
        public IActionResult EditarNotificacion(Guid id, [FromBody] CrearNotificacionModel model)
        {
            var notificacion = _context.Notificaciones.Find(id);
            if (notificacion == null)
                return NotFound();

            notificacion.Mensaje = model.Mensaje;
            notificacion.FechaEnvio = DateOnly.FromDateTime(model.Fecha);
            notificacion.UsuarioId = model.UsuarioId;

            _context.SaveChanges();

            var notificacionViewModel = _context.Notificaciones
                .Include(n => n.Usuario)
                .Where(n => n.Id == notificacion.Id)
                .Select(n => new NotificacionViewModel
                {
                    Id = n.Id,
                    Mensaje = n.Mensaje,
                    Fecha = n.FechaEnvio.ToDateTime(TimeOnly.MinValue),
                    UsuarioNombre = n.Usuario.Nombre
                })
                .FirstOrDefault();

            return Ok(notificacionViewModel);
        }

        // DELETE: api/notificaciones/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarNotificacion(Guid id)
        {
            var notificacion = _context.Notificaciones.Find(id);
            if (notificacion == null)
                return NotFound();

            _context.Notificaciones.Remove(notificacion);
            _context.SaveChanges();

            return NoContent();
        }
    }
}


