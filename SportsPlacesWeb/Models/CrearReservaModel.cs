using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class CrearReservaModel
    {
        public DateTime Fecha { get; set; }
        public TimeOnly Hora { get; set; }      // CORREGIDO: TimeOnly, no string
        public int UsuarioId { get; set; }      // CORREGIDO: int, no Guid
        public int EspacioId { get; set; }      // int
        public int SedeId { get; set; }         // int
    }
}