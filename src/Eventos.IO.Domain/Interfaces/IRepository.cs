using System.Linq.Expressions;
using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
{
    void Add(TEntity obj);
    void Update(TEntity obj);
    void Delete(Guid obj);
    TEntity GetById(Guid id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    int SaveChanges();
}
