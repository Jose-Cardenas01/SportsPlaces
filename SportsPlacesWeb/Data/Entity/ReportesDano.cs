using System;

namespace SportsPlacesWeb.Data.Entity
{
    public partial class ReporteDano
    {
        public int Id { get; set; }
        public string Estado { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Evidencia { get; set; } = null!;

        public int UsuarioId { get; set; }
        public int EspacioId { get; set; }
        public int SedeId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual Escenario Espacio { get; set; } = null!;
        public virtual Sede Sede { get; set; } = null!;
    }
}

