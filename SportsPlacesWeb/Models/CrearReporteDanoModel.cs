using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class CrearReporteDanoModel
    {
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public byte[]? Evidencia { get; set; }      // CORREGIDO: byte[], no string
        public Guid UsuarioId { get; set; }
        public Guid EscenarioId { get; set; }       // CORREGIDO: era EspacioId
        public Guid SedeId { get; set; }
    }


}
