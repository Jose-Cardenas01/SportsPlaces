using SportsPlacesWeb.Data;
using SportsPlacesWeb.Services.Abstract;

namespace SportsPlacesWeb.Services.Implementation
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {
        private readonly AppDbContext _context;
        public T /*async Task<T> */ CreateAsync(T entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                return entity;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error"); ;
            }
        }

        public Task<T> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByAsync(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
