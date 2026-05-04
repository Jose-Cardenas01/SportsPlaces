namespace SportsPlacesWeb.Services.Abstract
{
    public interface IGenericServices<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> GetByAsync(IQueryable<T> query);
        public T CreateAsync(T entity);
        public Task<T> UpdateAsync(Guid id);
        public Task<T> DeleteAsync(Guid id);
    }
}
