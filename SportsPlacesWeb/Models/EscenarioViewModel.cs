using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class EscenarioViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;  // EscenarioStatus como string
        public Guid SedesId { get; set; }                   // FK para crear/editar
        public string SedeNombre { get; set; } = string.Empty;
    }
}