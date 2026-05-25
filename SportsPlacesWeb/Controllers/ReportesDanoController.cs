using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Models;

namespace SportsPlacesWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesDanoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportesDanoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/reportesdano
        [HttpGet]
        public IActionResult GetReportes()
        {
            var reportes = _context.ReportesDano
                .Include(r => r.Usuario)
                .Include(r => r.Escenario)          // CORREGIDO: era Espacio
                .Include(r => r.Sede)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Descripcion = r.Descripcion,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EscenarioNombre = r.Escenario.Nombre,   // CORREGIDO: era EspacioNombre
                    SedeNombre = r.Sede.Nombre
                })
                .ToList();

            return Ok(reportes);
        }

        // GET: api/reportesdano/{id}
        [HttpGet("{id:guid}")]                      // CORREGIDO: era int
        public IActionResult GetReporte(Guid id)
        {
            var reporte = _context.ReportesDano
                .Include(r => r.Usuario)
                .Include(r => r.Escenario)
                .Include(r => r.Sede)
                .Where(r => r.Id == id)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Descripcion = r.Descripcion,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EscenarioNombre = r.Escenario.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            if (reporte == null)
                return NotFound();

            return Ok(reporte);
        }

        // POST: api/reportesdano
        [HttpPost]
        public IActionResult CrearReporte([FromBody] CrearReporteDanoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reporte = new ReportesDano
            {
                Descripcion = model.Descripcion,
                Fecha = DateOnly.FromDateTime(model.Fecha),
                Evidencia = model.Evidencia,
                UsuarioId = model.UsuarioId,
                EscenarioId = model.EscenarioId,    // CORREGIDO: era EspacioId
                SedeId = model.SedeId
            };

            _context.ReportesDano.Add(reporte);
            _context.SaveChanges();

            var reporteViewModel = _context.ReportesDano
                .Include(r => r.Usuario)
                .Include(r => r.Escenario)
                .Include(r => r.Sede)
                .Where(r => r.Id == reporte.Id)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Descripcion = r.Descripcion,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EscenarioNombre = r.Escenario.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            return CreatedAtAction(nameof(GetReporte), new { id = reporte.Id }, reporteViewModel);
        }

        // PUT: api/reportesdano/{id}
        [HttpPut("{id:guid}")]                      // CORREGIDO: era int
        public IActionResult EditarReporte(Guid id, [FromBody] CrearReporteDanoModel model)
        {
            var reporte = _context.ReportesDano.Find(id);
            if (reporte == null)
                return NotFound();

            reporte.Descripcion = model.Descripcion;
            reporte.Fecha = DateOnly.FromDateTime(model.Fecha);
            reporte.Evidencia = model.Evidencia;
            reporte.UsuarioId = model.UsuarioId;
            reporte.EscenarioId = model.EscenarioId;
            reporte.SedeId = model.SedeId;

            _context.SaveChanges();

            var reporteViewModel = _context.ReportesDano
                .Include(r => r.Usuario)
                .Include(r => r.Escenario)
                .Include(r => r.Sede)
                .Where(r => r.Id == reporte.Id)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Descripcion = r.Descripcion,
                    Fecha = r.Fecha.ToDateTime(TimeOnly.MinValue),
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EscenarioNombre = r.Escenario.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            return Ok(reporteViewModel);
        }

        // DELETE: api/reportesdano/{id}
        [HttpDelete("{id:guid}")]                   // CORREGIDO: era int
        public IActionResult EliminarReporte(Guid id)
        {
            var reporte = _context.ReportesDano.Find(id);
            if (reporte == null)
                return NotFound();

            _context.ReportesDano.Remove(reporte);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
