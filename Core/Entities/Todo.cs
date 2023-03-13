using ToDoApplication.Core.Enums;
namespace ToDoApplication.Core.Entities;

public class Todo
{
    public string id { get; set; }
    public string title { get; set; }
    public int order { get; set; } = 0;
    public Priority priority {get; set;} = Priority.Low;
    public bool isDone {get; set;} = false;
    
    ICollection<byte[]> _attachfiles;
    public ICollection <byte[]> attachments {get => _attachfiles; set => _attachfiles = value;}

    public TodoGroup todoGroup;
    
    public Todo(string id, string title, int order = 0, Priority priority = Priority.Low, bool isDone = false)
    {
        this.id = id;
        this.title = title;
        this.order = order;
        this.priority = priority;
        this.isDone = isDone;
    }





}