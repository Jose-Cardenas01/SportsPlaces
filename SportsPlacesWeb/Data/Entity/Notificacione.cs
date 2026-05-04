using SportsPlacesWeb.Data.Entity;
using System;
using System.Collections.Generic;
public partial class Notificacion
{
    public int Id { get; set; }
    public string Mensaje { get; set; } = null!;
    public DateOnly Fecha { get; set; }
    public int UsuarioId { get; set; }

    // Propiedad de navegación
    public virtual Usuario Usuario { get; set; } = null!;
}

