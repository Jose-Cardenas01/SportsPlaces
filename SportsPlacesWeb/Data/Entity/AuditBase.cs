using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Data.Entity
{
    public abstract class AuditBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}