using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Models;

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

        public IActionResult Index()
        {
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
                   
                    if (reserva is null)
                    {
                        eventos.Add(new
                        {
                            id = 0,
                            title = "Disponible",
                            start = startblock,
                            end = endblock,
                        });
                    }
                    else
                    {
                        eventos.Add(new
                        {
                            id = reserva.Id,
                            title = reserva.Status,
                            start = startblock,
                            end = endblock,
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
