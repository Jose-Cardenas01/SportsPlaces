using SportsPlacesWeb.Enums;
using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Escenarios : AuditBase
{
    public string Nombre { get; set; } = null!;

    public EscenarioStatus Estado { get; set; } = EscenarioStatus.Disponible;

    //Foreign Key
    public Guid SedesId { get; set; }

    //Navigator Propierty
    public virtual ICollection<ReportesDano> ReportesDanos { get; set; } = new List<ReportesDano>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Sedes Sede { get; set; } = null!;
    public virtual Calendarios Calendario { get; set; } = null!;
}
