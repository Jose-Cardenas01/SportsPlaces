using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class CrearReporteDanoModel
    {
        [Required]
        public string Estado { get; set; } = null!;

        [Required]
        public string Descripcion { get; set; } = null!;

        public string Evidencia { get; set; } = null!;

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int EspacioId { get; set; }

        [Required]
        public int SedeId { get; set; }
    }
}
