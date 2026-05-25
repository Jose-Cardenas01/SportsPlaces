using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class ReportesDano : AuditBase
{
    public string Estado { get; set; } = null!;

    public string? Descripcion { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public byte[]? Evidencia { get; set; }

    //FK
    public Guid EscenarioId { get; set; }
    public Guid SedeId { get; set; }
    public Guid UsuarioId { get; set; }

    //Navigator Propierty
    public virtual Escenario Escenario { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Sede Sede { get; set; } = null!;
}
