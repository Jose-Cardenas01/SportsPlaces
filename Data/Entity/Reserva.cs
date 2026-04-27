using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Reserva : AuditBase
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public DateOnly Fecha { get; set; }

    public string Hora { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public Guid UsuarioId { get; set; }

    public Guid EspacioId { get; set; }

    public Guid SedesId { get; set; }

    public virtual Escenario Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
