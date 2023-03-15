

namespace ToDoApplication.Application.DTOs;

public class CardOrderDTO:BaseOrderDTO
{
    public sbyte title { get ; set; } = 0;
    public sbyte order { get; set; } = -1;
    //TODO: Add Count of Task
}