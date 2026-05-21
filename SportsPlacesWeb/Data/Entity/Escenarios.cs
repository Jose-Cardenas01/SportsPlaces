using SportsPlacesWeb.Enums;
using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Escenario : AuditBase
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public EscenarioStatus Estado { get; set; } = EscenarioStatus.Disponible;

    //Foreign Key
    public Guid SedesId { get; set; }
    public Guid CalendarioId { get; set; }

    //Navigator Propierty
    public virtual ICollection<ReporteDano> ReportesDanos { get; set; } = new List<ReporteDano>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Sede Sede { get; set; } = null!;
    public virtual Calendarios Calendario { get; set; } = null!;
}
