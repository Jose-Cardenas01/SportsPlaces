using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.Services.Abstract;

namespace SportsPlacesWeb.Services.Implementation
{
    public class GenericServices<TEntity, TDTO> where TEntity : AuditBase 
    {
        private readonly AppDbContext _context;
        private readonly IMapper _map;
        public GenericServices(AppDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        public async Task<TDTO> CreateAsync(TDTO dto) 
        {
            try
            {
                if (dto is null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }

                var entity = _map.Map<TEntity>(dto);
                entity.Id = Guid.NewGuid();

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return dto;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error"); ;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity is null)
                {
                    throw new Exception("El registro no existe");
                }

                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Ha ocurrido un error");
            }
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            try
            {
                var list = await _context.Set<TEntity>().ToListAsync();
                if (list.Count <= 0)
                {
                    throw new Exception("No se encontraron registros");
                }

                return _map.Map<IEnumerable<TDTO>>(list);
            }
            catch
            {
                throw new Exception("Ha ocurrido un error");
            }
        }

        public async Task UpdateAsync(TDTO dto, Guid id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity is null)
                {
                    throw new Exception("El registro no existe");
                }

                _map.Map(dto, entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Ha ocurrido un error");
            }
        }
    }
}
