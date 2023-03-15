

namespace ToDoApplication.Application.DTOs;

public class CardFilterDTO:BaseFilterDTO
{
    public string title { get ; set; }
    public string color { get; set; } =  "#ffffff";
}
