using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity
{
    public partial class Sede
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        // Relación con Escenarios
        public virtual ICollection<Escenario> Escenarios { get; set; } = new List<Escenario>();

        // Relación con ReportesDano
        public virtual ICollection<ReporteDano> ReportesDano { get; set; } = new List<ReporteDano>();
    }
}
