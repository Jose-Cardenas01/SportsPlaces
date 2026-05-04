using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Usuario : AuditBase
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string CorreoInstitucional { get; set; } = null!;

    public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();


    public virtual ICollection<ReporteDano> ReportesDano { get; set; } = new List<ReporteDano>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
