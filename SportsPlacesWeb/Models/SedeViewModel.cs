using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class SedeViewModel
    {
        public Guid Id { get; set; }        // CORREGIDO: era int

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Direccion { get; set; }
    }
}
