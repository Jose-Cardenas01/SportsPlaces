using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Data.Entity;

public partial class Notificaciones : AuditBase
{
    [Required]
    public required Guid Id { get; set; }
    [Required]
    [MaxLength(500, ErrorMessage = "El {0} no puede exceder los {1} caracteres")]
    public required string Mensaje { get; set; } = null!;
    public DateTime? FechaEnvio { get; set; }
    public string? TipoNotificacion { get; set; }
    // FK
    [Required]
    public required Guid UsuarioId { get; set; }

    // Navigation Property
    public virtual Usuario Usuario { get; set; } = null!;
}
