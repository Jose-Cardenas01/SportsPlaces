using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Reservas : AuditBase
{
    public Guid Id { get; set; }

    public DateOnly Fecha { get; set; } = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

    public TimeOnly Hora { get; set; } = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);

    public string Estado { get; set; } = null!;

    public int UsuarioId { get; set; }

    public int EspacioId { get; set; }

    public int SedesId { get; set; }

    public virtual Escenarios Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
