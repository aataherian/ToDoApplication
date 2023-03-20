using ToDoApplication.Application.Interfaces.Repositories;
using ToDoApplication.Infrastructure.Persistence.Repositories;

namespace ToDoApplication.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ToDoContext _db;

    private ICardRepository _cardRepo;
    public ICardRepository cardRepository
    {
        get
        {
            if (_cardRepo != null)
                return _cardRepo;
            else
                _cardRepo = new CardRepository(_db);
            return _cardRepo;
        }
    }


    public UnitOfWork(ToDoContext todoContext)
    {
        _db = todoContext;
    }

    

    public async Task<int> SaveAsync()
    {
        return await _db.SaveChangesAsync();
    }
}