using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class EscenarioViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Estado { get; set; } // Disponible, Mantenimiento, Ocupado

        [Required]
        public string SedeNombre { get; set; }
    }
}