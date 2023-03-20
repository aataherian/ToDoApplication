using Microsoft.EntityFrameworkCore;


using ToDoApplication.Application.DTOs;
using ToDoApplication.Application.Interfaces.Repositories;
using ToDoApplication.Infrastructure.Persistence;


namespace ToDoApplication.Infrastructure.Persistence.Repositories;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity: class
{



    private readonly ToDoContext _db;



    public BaseRepository(ToDoContext todoContext)
    {
        _db = todoContext;
    }




    public async void Create(TEntity entity)
    {
        await _db.Set<TEntity>().AddAsync(entity);
    }



    public async void DeleteById(long id)
    {
        var entity = await _db.Set<TEntity>().FindAsync(id);

        if( entity is not null)
            _db.Set<TEntity>().Remove(entity);
        else
            return;
    }




    public  void Update(TEntity entity)
    {
        var result = _db.Set<TEntity>().SingleOrDefault<TEntity>();

        if (result is not null)
                _db.Set<TEntity>().Update(entity);
        else
            return;
    }




    public async Task<TEntity> FindById(long id)
    {
        var result =  await _db.Set<TEntity>().FindAsync(id);
        return result;
    }
    




    public async Task<IEnumerable<TEntity>> All()
    {
        return await _db.Set<TEntity>().AsNoTracking<TEntity>().ToListAsync();
    }


    public virtual Task<IEnumerable<TEntity>> FindByConditions(BaseFilterDTO conditions, BaseOrderDTO order)
    {
        throw new NotImplementedException("FindByConditions Method Must be implemented within each EntityRepository distinctively.");
        
    }
    
   


}