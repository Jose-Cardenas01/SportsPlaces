using SportsPlacesWeb.Data.Entity;
using System;
using System.Collections.Generic;
public partial class Notificacion
{
    public Guid Id { get; set; }   // <-- Guid
    public string Mensaje { get; set; } = null!;
    public DateOnly Fecha { get; set; }
    public Guid UsuarioId { get; set; }   // <-- Guid también

    public virtual Usuario Usuario { get; set; } = null!;
}


