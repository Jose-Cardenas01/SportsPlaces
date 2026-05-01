using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Data.Entity
{
    public class Calendarios : AuditBase
    {
        [Required]
        public required DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        public required TimeOnly Hora { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        //Foreign Key
        public Guid IdEscenario { get; set; }

        //Navigator Propierty
        public Escenarios Escenario { get; set; } = new Escenarios();
    }}