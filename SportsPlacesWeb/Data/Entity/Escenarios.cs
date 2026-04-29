using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Escenarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int SedesId { get; set; }

    public virtual ICollection<ReportesDano> ReportesDanos { get; set; } = new List<ReportesDano>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Sedes Sedes { get; set; } = null!;
}
