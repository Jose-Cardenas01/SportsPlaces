using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class ReporteDanoViewModel
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string UsuarioNombre { get; set; } = null!;
        public string EscenarioNombre { get; set; } = null!;
        public string SedeNombre { get; set; } = null!;
    }

}
