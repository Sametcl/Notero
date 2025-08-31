using Microsoft.EntityFrameworkCore;
using Notero.Application.Contracts.Persistance;
using Notero.Domain.Entities.Common;
using Notero.Persistance.Context;
using System.Linq.Expressions;

namespace Notero.Persistance.Concrete
{
    public class GenericRepository<TEntity>(AppDbContext _context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _table = _context.Set<TEntity>();
        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _table;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _table
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
    }
}
