namespace ToDoApplication.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    public ICardRepository  cardRepository{get;}
    public Task<int> SaveAsync();    
}