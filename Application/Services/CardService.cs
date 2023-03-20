using AutoMapper;

using ToDoApplication.Core.Entities;
using ToDoApplication.Application.Interfaces.Services;
using ToDoApplication.Application.DTOs;
using ToDoApplication.Application.Interfaces.Repositories;

namespace ToDoApplication.Application.Services;

public class CardServices : ICardService
{

	IUnitOfWork _db;
	IMapper mapper;
	public CardServices(IUnitOfWork unitOfWork, IMapper mapper)
	{
		this._db = _db;
		this.mapper = mapper;
	}




	public async Task<CardDTO> Create(CardCreationDTO entity)
	{
		var card = mapper.Map<CardCreationDTO, Card>(entity);
		_db.cardRepository.Create(card);

		int result = await _db.SaveAsync() ;
		if (result > 0)
			return mapper.Map<CardDTO>(card);
		return null;
	}





	public async  Task<int> DeleteById(long id)
	{
		_db.cardRepository.DeleteById(id);
		 int result = await _db.SaveAsync();
		 return result > 0 ? result : 0 ;
	}




	public async Task<IList<CardDTO>> All()
	{
		var result = await  _db.cardRepository.All();
		
		return mapper.Map<IList<CardDTO>>(result);
	}





	public async Task<IList<CardDTO>> FindByConditions(CardFilterDTO filter,CardOrderDTO order)
		//Expression<Func<CardDTO, bool>> conditions)
	{

		var result =await _db.cardRepository.FindByConditions(filter, order);
		return mapper.Map<IList<CardDTO>>(result);
		
	}





	public async Task<CardDTO> FindById(long id)
	{
	   Card result = await _db.cardRepository.FindById(id);
	   return mapper.Map<CardDTO>(result);

	}




	public async Task<int> Update(CardDTO entity)
	{
		
		var result = await _db.cardRepository.FindById(entity.id);
		if(result == null)
			throw new KeyNotFoundException("Not Found");

		var e = mapper.Map<Card>(entity);
		_db.cardRepository.Update(e);
		return await _db.SaveAsync();
		//TODO: if ==0 throw exception
	}
}