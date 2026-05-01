using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Usuario : AuditBase
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string CorreoInstitucional { get; set; } = null!;

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<ReportesDano> ReportesDanos { get; set; } = new List<ReportesDano>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
