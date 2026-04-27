using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class ReportesDano : AuditBase
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string Estado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public byte[]? Evidencia { get; set; }

    public Guid EspacioId { get; set; }

    public Guid UsuarioId { get; set; }

    public virtual Escenario Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
