using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Notificacione : AuditBase
{

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public Guid UsuarioId { get; set; }

    public string? TipoNotificacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
