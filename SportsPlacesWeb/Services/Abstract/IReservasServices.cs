using SportsPlacesWeb.Data.Entity;

namespace SportsPlacesWeb.Services.Abstract
{
    public interface IReservasServices
    {
        public Task<IEnumerable<Reservas>> GetAllAsync();
        public Task<IEnumerable<Reservas>> GetByAsync(IQueryable<>);
    }
}
