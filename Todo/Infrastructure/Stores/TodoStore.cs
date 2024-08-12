using Microsoft.EntityFrameworkCore;
using Todo.Domain.DataModels;
using Todo.Domain.Stores;

namespace Todo.Infrastructure.Stores;

public class TodoStore(TodoDbContext context) : ITodoStore
{
    public async Task<List<TodoItem>> GetTodosAsync()
    {
        return await context.Todos.AsNoTrackingWithIdentityResolution().ToListAsync();
    }
}
