using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class CrearNotificacionModel
    {
        [Required]
        public string Mensaje { get; set; } = null!;

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}

