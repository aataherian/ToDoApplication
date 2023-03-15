
namespace ToDoApplication.Application.DTOs;

public class CardCreationDTO:BaseCreationDTO
{
    public string title { get ; set; }
    public string color { get; set; } =  "#ffffff";
    public int order { get; set; }
    public ICollection<TodoGroupDTO> todoGroups;

}