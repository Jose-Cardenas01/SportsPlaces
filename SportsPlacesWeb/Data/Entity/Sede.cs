using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Sede
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Escenario> Escenarios { get; set; } = new List<Escenario>();
}
