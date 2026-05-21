using SportsPlacesWeb.Data.Entity;

public partial class ReporteDano
{
    public Guid Id { get; set; }
    public string? Descripcion { get; set; }
    public DateOnly Fecha { get; set; }
    public byte[]? Evidencia { get; set; }

    // Foreign Keys
    public Guid UsuarioId { get; set; }
    public Guid EscenarioId { get; set; }
    public Guid SedeId { get; set; }

    // Navigation Properties
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Escenario Escenario { get; set; } = null!;
    public virtual Sede Sede { get; set; } = null!;
}


