
namespace ToDoApplication.Core.Entities;

public class Card
{
 
  

    public string id { get ; set; }
    public string title { get ; set; }
    public string color { get; set; } =  "#ffffff";
    public int order { get; set; }

    private ICollection<TodoGroup> _todogroups;
    public ICollection<TodoGroup> TodoGroups { get => _todogroups; set => _todogroups = value; }

    public Card(string Title, string color = "#ffffff", int Order = 1)
    {
        this.title = Title;
        this.color = color;
        this.order = Order;
    }
    
}