using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity;

public partial class Usuario : AuditBase
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string Nombre { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string CorreoInstitucional { get; set; } = null!;

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<ReportesDano> ReportesDanos { get; set; } = new List<ReportesDano>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
