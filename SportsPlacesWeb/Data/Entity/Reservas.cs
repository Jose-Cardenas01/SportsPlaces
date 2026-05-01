using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Reservas : AuditBase
{

    public DateOnly Fecha { get; set; } = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

    public TimeOnly Hora { get; set; } = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);

    //FOREIGN KEY
    public Guid EspacioId { get; set; }
    public Guid UsuarioId { get; set; }

    //Navigation properties
    public virtual Escenarios Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
