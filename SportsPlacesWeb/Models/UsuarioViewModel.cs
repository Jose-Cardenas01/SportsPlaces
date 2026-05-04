using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string TipoUsuario { get; set; } // Estudiante, Docente, Admin, Mantenimiento

        [Required, MaxLength(50)]
        [EmailAddress]
        public string CorreoInstitucional { get; set; }
    }
}
