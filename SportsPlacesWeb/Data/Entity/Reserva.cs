using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Reserva
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public string Hora { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int UsuarioId { get; set; }

    public int EspacioId { get; set; }

    public int SedesId { get; set; }

    public virtual Escenario Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
