using System.Linq.Expressions;
using ToDoApplication.Application.DTOs;
namespace ToDoApplication.Application.Interfaces.Repositories;

public interface IBaseRepository<TEntity>
{
    public TEntity Create(TEntity entity);
    public void Update(TEntity entity);
    public void DeleteById(long id);
    public Task<TEntity> FindById(long id);
    public Task<IQueryable<TEntity>> FindByCondition(BaseFilterDTO conditions, BaseOrderDTO order);
    public Task<IQueryable<TEntity>> All();
        
}