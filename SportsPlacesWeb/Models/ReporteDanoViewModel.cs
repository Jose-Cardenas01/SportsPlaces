using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class ReporteDanoViewModel
    {
        public int Id { get; set; }
        public string Estado { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Evidencia { get; set; } = null!;  // <-- igual aquí

        public string UsuarioNombre { get; set; } = null!;
        public string EspacioNombre { get; set; } = null!;
        public string SedeNombre { get; set; } = null!;
    }
}
