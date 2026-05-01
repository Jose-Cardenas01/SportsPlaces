using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Sedes : AuditBase
{
    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Escenarios> Escenarios { get; set; } = new List<Escenarios>();
}
