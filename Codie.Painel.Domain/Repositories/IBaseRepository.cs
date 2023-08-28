using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                int? top = null,
                                                int? skip = null,
                                                params string[] includeProperties);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
