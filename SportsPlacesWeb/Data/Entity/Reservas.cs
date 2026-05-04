using SportsPlacesWeb.Enums;
using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Reservas : AuditBase
{

    public DateOnly Fecha { get; set; } = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

    public TimeOnly HoraInicio { get; set; } = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
    public TimeOnly HoraFin { get; set; } = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
    public ReservasStatus Status { get; set; } = ReservasStatus.PracticaLibre;

    //FOREIGN KEY
    public Guid EspacioId { get; set; }
    public Guid UsuarioId { get; set; }

    //Navigation properties
    public virtual Escenarios Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
