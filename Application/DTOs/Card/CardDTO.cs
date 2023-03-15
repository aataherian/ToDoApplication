
namespace ToDoApplication.Application.DTOs;

public class CardDTO:BaseDTO
{
    public long id { get ; set; }
    public string title { get ; set; }
    public string color { get; set; } =  "#ffffff";
    public int order { get; set; }
    public ICollection<TodoGroupDTO> todoGroups;
    
}