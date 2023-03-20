
using ToDoApplication.Core.Entities;
using ToDoApplication.Application.DTOs;
using ToDoApplication.Application.Interfaces.Repositories;


namespace ToDoApplication.Infrastructure.Persistence.Repositories;

class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(ToDoContext todoContext) : base(todoContext){}

    public  IQueryable<Card> FindByConditionsAsync(CardFilterDTO filter, CardOrderDTO order)
    {
        return null;
    }
}