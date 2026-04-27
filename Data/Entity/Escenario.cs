using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Escenario : AuditBase
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public Guid SedesId { get; set; }
    public Guid CalendarioId { get; set; }
    public Calendario Calendario { get; set; } 
    public virtual Sede Sedes { get; set; } = null!;

    public virtual ICollection<ReportesDano> ReportesDanos { get; set; } = new List<ReportesDano>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

}
