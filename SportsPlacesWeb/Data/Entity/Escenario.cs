using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Escenario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int SedesId { get; set; }

    public virtual ICollection<ReportesDano> ReportesDanos { get; set; } = new List<ReportesDano>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual Sede Sedes { get; set; } = null!;
}
