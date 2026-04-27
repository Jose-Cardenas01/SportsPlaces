
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Data.Entity
{
    public class Calendario : AuditBase
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public required DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        public required TimeOnly Hora { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        //Navigator Propierty
        public Guid IdEscenario { get; set; }
        public Escenario Escenario { get; set; } = new Escenario();
    }
}
