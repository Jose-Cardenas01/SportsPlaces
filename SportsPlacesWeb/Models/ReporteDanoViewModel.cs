using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class ReporteDanoViewModel
    {
        public Guid Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public byte[]? Evidencia { get; set; }      // CORREGIDO: byte[], no string
        public string UsuarioNombre { get; set; } = string.Empty;
        public string EscenarioNombre { get; set; } = string.Empty;  // CORREGIDO: era EspacioNombre
        public string SedeNombre { get; set; } = string.Empty;
    }



}
