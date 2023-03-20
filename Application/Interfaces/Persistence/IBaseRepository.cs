
using ToDoApplication.Application.DTOs;
namespace ToDoApplication.Application.Interfaces.Repositories;

public interface IBaseRepository<TEntity>
{
    public void Create(TEntity entity);
    public void DeleteById(long id);
    public void Update(TEntity entity);
    public Task<TEntity> FindById(long id);
    public Task<IEnumerable<TEntity>> All();
    public abstract Task<IEnumerable<TEntity>> FindByConditions(BaseFilterDTO conditions, BaseOrderDTO order);
}