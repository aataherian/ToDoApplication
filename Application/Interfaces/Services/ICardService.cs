using ToDoApplication.Application.DTOs;

namespace ToDoApplication.Application.Interfaces.Services;
public interface ICardService : IBaseService<CardCreationDTO,CardDTO> {}