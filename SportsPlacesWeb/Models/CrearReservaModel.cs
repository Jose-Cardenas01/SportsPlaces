using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class CrearReservaModel
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required, MaxLength(20)]
        public string Hora { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int EspacioId { get; set; }

        [Required]
        public int SedeId { get; set; }
    }
}