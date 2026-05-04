using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Enums;
using SportsPlacesWeb.Models;
using SportsPlacesWeb.Services.Implementation;

namespace SportsPlacesWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var escenarios = await _context.Escenarios
                .OrderBy(e => e.Nombre)
                .Select(e => new { e.Id, e.Nombre })
                .ToListAsync();

            ViewBag.Escenarios = escenarios;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusScene(Guid id, DateTime? start, DateTime? end)
        {
            DateOnly startDate = DateOnly.FromDateTime(start.Value);
            DateOnly endDate = DateOnly.FromDateTime(end.Value);

            var reservas = await _context.Set<Reservas>().Include(r => r.Espacio)
                           .Where(r => r.EspacioId == id && r.Fecha >= startDate && r.Fecha <= endDate).ToListAsync();

            TimeOnly startTime = new(6, 0);
            TimeOnly endTime = new(22, 0);

            List<object> eventos = new();

            for (DateOnly date = startDate; date < endDate; date = date.AddDays(1))
            {
                for (TimeOnly time = startTime; time < endTime; time = time.AddMinutes(60))
                {
                    TimeOnly startblock = time;
                    TimeOnly endblock = time.AddMinutes(60);

                    Reservas? reserva = reservas.FirstOrDefault(r => r.Fecha == date && r.HoraInicio >= startblock && r.HoraFin <= endblock);

                    var startDateTime = date.ToDateTime(startblock).ToString("yyyy-MM-ddTHH:mm:ss");
                    var endDateTime = date.ToDateTime(endblock).ToString("yyyy-MM-ddTHH:mm:ss");

                    if (reserva is null)
                    {
                        eventos.Add(new
                        {
                            id = 0,
                            title = EscenarioStatus.Disponible.ToString(),
                            start = startDateTime,
                            end = endDateTime,
                            color = StatusColor.GetColorByStatus(1)
                        });
                    }
                    else
                    {
                        eventos.Add(new
                        {
                            id = reserva.Id,
                            title = reserva.Status.ToString(),
                            start = startDateTime,
                            end = endDateTime,
                            color = StatusColor.GetColorByStatus((int)reserva.Status)
                        });
                    }

                }
            }

            return Json(eventos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
