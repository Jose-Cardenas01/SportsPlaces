using SportsPlacesWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class ReservaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }    // CORREGIDO: TimeOnly, no string
        public TimeOnly HoraFin { get; set; }    // CORREGIDO: TimeOnly, no string
        public ReservasStatus Estado { get; set; } = ReservasStatus.PracticaDeportiva;
        public string UsuarioNombre { get; set; } = string.Empty;
        public string EspacioNombre { get; set; } = string.Empty;
        public string SedeNombre { get; set; } = string.Empty;
    }
}
