using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class ReservaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly Hora { get; set; }      // CORREGIDO: TimeOnly, no string
        public string Estado { get; set; } = string.Empty;
        public string UsuarioNombre { get; set; } = string.Empty;
        public string EspacioNombre { get; set; } = string.Empty;
        public string SedeNombre { get; set; } = string.Empty;
    }
}
