using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AppMVC.Infrastructure.Contexts;

namespace AppMVC.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly AppDbContext dbContext;
    public GenericRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        var entityEntry = await dbContext.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public IQueryable<TEntity> SelectAll() => 
        dbContext.Set<TEntity>().AsNoTracking();

    public async ValueTask<TEntity> SelectByIdAsync(int id) =>
        await dbContext.Set<TEntity>().FindAsync(id);
    
    public async ValueTask<TEntity> SelectByIdWithDetailsAsync(Expression<Func<TEntity, bool>> expression, string[] includes)
    {
        IQueryable<TEntity> entities = this.SelectAll();

        foreach (var include in includes)
        {
            entities = entities.Include(include);
        }

        return await entities.FirstOrDefaultAsync(expression);
    }
   
    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entryEntity = dbContext.Update(entity);

        await dbContext.SaveChangesAsync();

        return entryEntity.Entity;
    }
    public async ValueTask<TEntity> RemoveAsync(TEntity entity)
    {
        var entityEntry = dbContext.Remove(entity);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }
}
