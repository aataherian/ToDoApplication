using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

using ToDoApplication.Core.Entities;
using ToDoApplication.Application.Interfaces.Services;
using ToDoApplication.Application.DTOs;
using ToDoApplication.Application.Interfaces.Repositories;
using  ToDoApplication.Application.Valitaors;

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




	public async Task<(CardDTO?,List<ErrorDTO>)> Create(CardCreationDTO entity)
	{
		CardCreationValiadtor cardCreationValiadtor = new CardCreationValiadtor();
		var valiadtionResult = cardCreationValiadtor.Validate(entity);

		if (!valiadtionResult.IsValid)
			return (null, ErrorDTO.GetErrors(valiadtionResult));
		
			var card = mapper.Map<CardCreationDTO, Card>(entity);
			_db.cardRepository.Create(card);

			int result = await _db.SaveAsync() ;
			if (result > 0)
				return (mapper.Map<CardDTO>(card), null);
			else
				return (null,null);
	}



	public async  Task<(int,ErrorDTO?)> DeleteById(long id)
	{
		_db.cardRepository.DeleteById(id);
		 int result = await _db.SaveAsync();

		 if(result > 0)
		 	return (result, null);
		else
			return (0, new ErrorDTO("id",id,"404","id does not Exists") );
	}


	public async Task<IList<CardDTO>> All()
	{
		var result = await  _db.cardRepository.All();
		
		return mapper.Map<IList<CardDTO>>(result);
	}





	public async Task<IList<CardDTO>> FindByConditions(CardFilterDTO filter,CardOrderDTO order)
	{
		var result =await _db.cardRepository.FindByConditions(filter, order);
		return mapper.Map<IList<CardDTO>>(result);
	}





	public async Task<CardDTO> FindById(long id)
	{
	   Card result = await _db.cardRepository.FindById(id);
	   return mapper.Map<CardDTO>(result);
	}




	public async Task<(int,List<ErrorDTO>)> Update(CardDTO entity)
	{
		List<ErrorDTO> errors;

		CardValidator cardValiadtor = new CardValidator();
		var valiadtionResult = cardValiadtor.Validate(entity);

		if (!valiadtionResult.IsValid)
		{
			errors = ErrorDTO.GetErrors(valiadtionResult);
			return (0, errors);
		}
		
		var result = await _db.cardRepository.FindById(entity.id);
		if(result == null)
			{
				errors=new List<ErrorDTO>();
				errors.Add(new ErrorDTO("id",entity.id,"404","Card with the id, does not Exists"));
				return (0,  errors);
			}

		var e = mapper.Map<Card>(entity);
		_db.cardRepository.Update(e);
		int numberOfChanges = await _db.SaveAsync();
		
		if(numberOfChanges != 0)
			return (numberOfChanges, null);
		else
			{
				errors=new List<ErrorDTO>();
				errors.Add(new ErrorDTO("id",entity.id,"304","Update Failed."));
				return (0,  errors);
			}
	}
}