using Notero.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Notero.Application.Contracts.Persistance
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetQuery();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity,bool>> filter);
        Task CreateAsync(TEntity entity);   
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
