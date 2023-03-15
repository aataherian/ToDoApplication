namespace ToDoApplication.Application.DTOs;

    public class TodoGroupDTO:BaseDTO
    {
    public long id { get; set; }
    public string title { get; set; }
    public int order { get; set;} = 0;
    private ICollection<TodoDTO> todos;
    }
