using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class ReportesDano : AuditBase
{
    public string Estado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public byte[]? Evidencia { get; set; }

    //FK
    public Guid EspacioId { get; set; }

    public Guid UsuarioId { get; set; }

    //Navigator Propierty
    public virtual Escenarios Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
