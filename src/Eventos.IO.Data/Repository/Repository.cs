using Eventos.IO.Data.Context;
using System.Linq.Expressions;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
{
    protected EventContext Db;
    protected DbSet<TEntity> DbSet;

    protected Repository(EventContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> QueryAsNoTracking => DbSet.AsNoTracking();

    public virtual async Task<TEntity> FindByIdAsync(Guid id) => await DbSet.FirstOrDefaultAsync(x => x.Id ==  id);

    public virtual async Task<bool> ExistAsync(Guid id) => await DbSet.AnyAsync(x => x.Id == id);

    public virtual void Delete(TEntity entity) => entity?.IsDeletedTrue();
   
    public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate) => DbSet.AsNoTracking().Where(predicate);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.ToListAsync();

    public async virtual void DeleteByIdAsync(Guid id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        entity?.IsDeletedTrue();
    }

    public virtual async Task<TEntity> RegisterAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public virtual void Update(TEntity entity)
    {
        entity.UpdatedAtNow();
        DbSet.Update(entity);
    }

    public int SaveChanges() => Db.SaveChanges();

    public void Dispose() => Db.Dispose();

}
