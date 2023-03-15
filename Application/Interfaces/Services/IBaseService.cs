using System.Linq.Expressions;
using ToDoApplication.Application.DTOs;

namespace ToDoApplication.Application.Interfaces.Services;

public interface IBaseService <TCreateRequest,TEntity>
{
    public TEntity Create(TCreateRequest entity);
    public int Update( TEntity entity);
    public int DeleteById(long id);
    public Task<TEntity> FindById(long id);
    public Task<IQueryable<TEntity>> FindByConditions(CardFilterDTO filter,CardOrderDTO order);    
    public Task<IQueryable<TEntity>> All();    
}