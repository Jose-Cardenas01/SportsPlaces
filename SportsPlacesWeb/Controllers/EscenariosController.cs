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
            var reportes = _context.ReportesDanos
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Include(r => r.Sede)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Estado = r.Estado,
                    Descripcion = r.Descripcion,
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .ToList();

            return Ok(reportes);
        }

        // GET: api/reportesdano/5
        [HttpGet("{id}")]
        public IActionResult GetReporte(int id)
        {
            var reporte = _context.ReportesDanos
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Include(r => r.Sede)
                .Where(r => r.Id == id)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Estado = r.Estado,
                    Descripcion = r.Descripcion,
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
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

            var reporte = new ReporteDano
            {
                Estado = model.Estado,
                Descripcion = model.Descripcion,
                Evidencia = model.Evidencia,
                UsuarioId = model.UsuarioId,
                EspacioId = model.EspacioId,
                SedeId = model.SedeId
            };

            _context.ReportesDanos.Add(reporte);
            _context.SaveChanges();

            // Proyección a ViewModel para devolver datos enriquecidos
            var reporteViewModel = _context.ReportesDanos
                .Include(r => r.Usuario)
                .Include(r => r.Espacio)
                .Include(r => r.Sede)
                .Where(r => r.Id == reporte.Id)
                .Select(r => new ReporteDanoViewModel
                {
                    Id = r.Id,
                    Estado = r.Estado,
                    Descripcion = r.Descripcion,
                    Evidencia = r.Evidencia,
                    UsuarioNombre = r.Usuario.Nombre,
                    EspacioNombre = r.Espacio.Nombre,
                    SedeNombre = r.Sede.Nombre
                })
                .FirstOrDefault();

            return CreatedAtAction(nameof(GetReporte), new { id = reporte.Id }, reporteViewModel);
        }

        // PUT: api/reportesdano/5
        [HttpPut("{id}")]
        public IActionResult EditarReporte(int id, [FromBody] ReporteDanoViewModel model)
        {
            var reporte = _context.ReportesDanos.Find(id);
            if (reporte == null)
                return NotFound();

            reporte.Estado = model.Estado;
            reporte.Descripcion = model.Descripcion;
            reporte.Evidencia = model.Evidencia;

            _context.SaveChanges();

            return Ok(model);
        }

        // DELETE: api/reportesdano/5
        [HttpDelete("{id}")]
        public IActionResult EliminarReporte(int id)
        {
            var reporte = _context.ReportesDanos.Find(id);
            if (reporte == null)
                return NotFound();

            _context.ReportesDanos.Remove(reporte);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
