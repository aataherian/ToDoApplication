namespace ToDoApplication.Core.Entities;
public class TodoGroup

{
    public string id { get; set; }
    public string title { get; set; }
    public int order { get; set;} = 0;
    private ICollection<Todo> _todos;
    public ICollection<Todo> Todos { get => _todos; set => _todos = value; }
   
   public Card card;

   public TodoGroup(string Title, int Order=1)
   {
    this.title = Title;
    this.order=Order;
   }
   

  
    
}