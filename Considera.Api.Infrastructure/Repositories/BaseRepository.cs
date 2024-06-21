using Considera.Api.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api.Infrastructure.Repositories;

public class BaseRepository<TEntity>
    where TEntity : class, IEntity
{
    protected DbContext Context { get; set; }

    protected BaseRepository(DbContext context) => 
        Context = context;
    
    public async Task<TEntity?> Get(Guid id) =>
        await Context.FindAsync<TEntity>(id);
    
    public async Task<IEnumerable<TEntity>> Get(IEnumerable<Guid> ids) =>
        await Context
            .Set<TEntity>()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
    
    public async Task<IEnumerable<TEntity>> GetAll() => 
        await Context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity); // Synchronous add to the context
        await Context.SaveChangesAsync(); // Asynchronous save to the database
        return entity;
    }
    
    public async Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities)
    {
        var entitiesList = entities.ToList();
        Context.Set<TEntity>().AddRange(entitiesList); // Synchronous add to the context
        await Context.SaveChangesAsync(); // Asynchronous save to the database
        return entitiesList;
    }
    
    public async Task<bool> Has(TEntity entity) => 
        await Context.FindAsync<TEntity>(entity.Id) == null;
}