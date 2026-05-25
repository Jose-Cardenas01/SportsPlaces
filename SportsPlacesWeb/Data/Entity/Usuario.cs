using System;
using System.Collections.Generic;

namespace SportsPlacesWeb.Data.Entity
{
    public class Usuario : AuditBase
    {
        public string Nombre { get; set; } = null!;

        public string TipoUsuario { get; set; } = null!;

        public string CorreoInstitucional { get; set; } = null!;

        // Use the singular Notificacion entity type so the collection element type
        // matches the Notificacion entity used in the DbContext and Notificacion class.
        public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

        public virtual ICollection<ReportesDano> ReportesDano { get; set; } = new List<ReportesDano>();

        public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
    }
}
