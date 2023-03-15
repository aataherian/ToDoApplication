using System.Collections.Generic;
using System.Linq.Expressions;

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




	public CardDTO Create(CardCreationDTO entity)
	{
		var card = mapper.Map<CardCreationDTO, Card>(entity);
		card = _db.cardRepository.Create(card);

		if (_db.Save() > 0)
			return mapper.Map<CardDTO>(card);
		return null;
	}





	public int DeleteById(long id)
	{
		_db.cardRepository.DeleteById(id);
		 int result = _db.Save();
		 return result > 0 ? result : 0 ;
	}




	public async Task<IQueryable<CardDTO>> All()
	{
		var result = await  _db.cardRepository.All();
		return mapper.ProjectTo<CardDTO>(result);
	}





	public async Task<IQueryable<CardDTO>> FindByConditions(CardFilterDTO filter,CardOrderDTO order)
		//Expression<Func<CardDTO, bool>> conditions)
	{

		var result =await _db.cardRepository.FindByCondition(filter, order);
		return mapper.ProjectTo<CardDTO>(result);
		
	}





	public async Task<CardDTO> FindById(long id)
	{
	   Card result = await _db.cardRepository.FindById(id);
	   return mapper.Map<CardDTO>(result);

	}




	public int Update(CardDTO entity)
	{
		
		var result = _db.cardRepository.FindById(entity.id);
		if(result == null)
			throw new KeyNotFoundException("Not Found");

		var e = mapper.Map<Card>(entity);
		_db.cardRepository.Update(e);
		return _db.Save();
		//TODO: if ==0 throw exception
	}
}