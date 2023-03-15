using ToDoApplication.Core.Enums;
namespace ToDoApplication.Application.DTOs;

public class TodoDTO : BaseDTO
{
    public long id { get; set; }
    public string title { get; set; }
    public int order { get; set; } = 0;
    public Priority priority { get; set; } = Priority.Low;
    public bool isDone { get; set; } = false;
    public ICollection<byte[]> attachments;
}

