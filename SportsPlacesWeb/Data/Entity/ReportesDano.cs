using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class ReportesDano
{
    public int Id { get; set; }

    public string Estado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public byte[]? Evidencia { get; set; }

    public int EspacioId { get; set; }

    public int UsuarioId { get; set; }

    public virtual Escenarios Espacio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
