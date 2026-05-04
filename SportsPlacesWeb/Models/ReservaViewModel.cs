using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        [Required]
        public string Hora { get; set; }

        [Required]
        public string Estado { get; set; }

        public string UsuarioNombre { get; set; }
        public string EspacioNombre { get; set; }
        public string SedeNombre { get; set; }
    }
}
