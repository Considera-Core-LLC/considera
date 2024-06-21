namespace Considera.Api.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> Get(Guid id);
    Task<IEnumerable<TEntity>> Get(IEnumerable<Guid> ids);
    Task<TEntity?> Add(TEntity entity);
    Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);
    Task<bool> Has(TEntity entity);
}