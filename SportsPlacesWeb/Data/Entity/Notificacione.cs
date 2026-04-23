using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Notificacione
{
    public int Id { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public int UsuarioId { get; set; }

    public string? TipoNotificacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
