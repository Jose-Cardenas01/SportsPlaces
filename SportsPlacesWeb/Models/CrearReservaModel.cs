using SportsPlacesWeb.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPlacesWeb.Models
{
    public class CrearReservaModel
    {
        public DateTime Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }      // CORREGIDO: TimeOnly, no string
        public TimeOnly HoraFin { get; set; }         // CORREGIDO: TimeOnly, no string
        public ReservasStatus Status { get; set; } = ReservasStatus.PracticaLibre;

        public Guid UsuarioId { get; set; }      // CORREGIDO: int, no Guid
        public Guid EspacioId { get; set; }      // int
    }
}