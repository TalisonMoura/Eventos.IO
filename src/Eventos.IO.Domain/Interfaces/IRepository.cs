using System.Linq.Expressions;
using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
{
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteByIdAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
    Task<TEntity> FindByIdAsync(Guid id);
    Task<TEntity> RegisterAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IQueryable<TEntity> QueryAsNoTracking { get; }
    IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    int SaveChanges();
}
