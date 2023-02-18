using System.Linq.Expressions;

namespace AppMVC.Infrastructure.Repositories;

public interface IGenericRepository<TEntity>
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    IQueryable<TEntity> SelectAll();
    ValueTask<TEntity> SelectByIdAsync(int id);

    ValueTask<TEntity> SelectByIdWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);

    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<TEntity> RemoveAsync(TEntity entity);
}
