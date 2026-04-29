using SportsPlacesWeb.Data.Entity;

namespace SportsPlacesWeb.Services.Abstract
{
    public interface ISedeServices
    {
        public Task<IEnumerable<Sedes>> GetAllAsync();
    }
}
