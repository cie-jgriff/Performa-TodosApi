namespace Todo.Domain;

public class TodoItem
{
    public Guid Id { get; private set; }
    
    public string Title { get; private set; }
    
    public bool IsComplete { get; private set; }
    
    public TodoItem(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        IsComplete = false;
    }
    
    public void UpdateTitle(string title)
    {
        Title = title;
    }
}