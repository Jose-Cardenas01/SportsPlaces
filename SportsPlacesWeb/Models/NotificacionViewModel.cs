using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class NotificacionViewModel
    {
        public int Id { get; set; }
        public string Mensaje { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string UsuarioNombre { get; set; } = null!;
    }
}
