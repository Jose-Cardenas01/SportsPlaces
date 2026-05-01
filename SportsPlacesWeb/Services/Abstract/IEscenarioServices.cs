using SportsPlacesWeb.Data.Entity;

namespace SportsPlacesWeb.Services.Abstract
{
    public interface IEscenarioServices
    {
        public Task<IEnumerable<Escenarios>> GetAllAsync();
    }
}
