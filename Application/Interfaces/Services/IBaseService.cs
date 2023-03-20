
using ToDoApplication.Application.DTOs;

namespace ToDoApplication.Application.Interfaces.Services;

public interface IBaseService <TCreateRequest,TEntity>
{
    public Task<TEntity> Create(TCreateRequest entity);
    public Task<int> Update( TEntity entity);
    public Task<int> DeleteById(long id);
    public Task<TEntity> FindById(long id);
    public Task<IList<TEntity>> FindByConditions(CardFilterDTO filter,CardOrderDTO order);    
    public Task<IList<TEntity>> All();    
}