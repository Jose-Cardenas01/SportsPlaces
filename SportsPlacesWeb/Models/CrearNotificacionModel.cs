using System.ComponentModel.DataAnnotations;

public class CrearNotificacionModel
{
    [Required]
    public string Mensaje { get; set; } = null!;

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public Guid UsuarioId { get; set; }   // <-- cambiar a Guid
}


