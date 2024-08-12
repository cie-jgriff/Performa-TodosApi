using Todo.Domain.DataModels;

namespace Todo.Domain.Stores;

public interface ITodoStore
{
    Task<List<TodoItem>> GetTodosAsync();
}
