using SportsPlacesWeb.Enums;

namespace SportsPlacesWeb.DTOs
{
    public class EscenarioDTO
    {
        public string Nombre { get; set; } = null!;
        public EscenarioStatus Estado { get; set; } = EscenarioStatus.Disponible;

        //Foreign Key
        public Guid SedesId { get; set; }
    }
}
