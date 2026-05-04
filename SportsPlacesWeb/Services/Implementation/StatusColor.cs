namespace SportsPlacesWeb.Services.Implementation
{
    public static class StatusColor
    {
        public static string GetColorByStatus(int status)
        {
            return status switch
            {
                1 => "#28a745", // Verde para Disponible
                3 => "#ffc107", // Amarillo para Mantenimiento
                4 => "#007bff", // Azul para Practica Deportiva
                5 => "#dc3545", // Rojo para Practica libre
                _ => "#6c757d"  // Gris para estado desconocido
            };
        }
    }
}
