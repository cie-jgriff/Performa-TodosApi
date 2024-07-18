using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Todo.Domain;
using Todo.Interfaces;

namespace Todo.Endpoints;

public class TodosModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/todos").WithOpenApi();

        group.MapGet("", (ApplicationDbContext dbContext) => GetTodos(dbContext));
    }
    
    private static async Task<Ok<List<Domain.TodoItem>>> GetTodos(ApplicationDbContext dbContext)
    {
        var todos = await dbContext.Todos.ToListAsync();
        return TypedResults.Ok(todos);
    }
    
    /// <summary>
    /// Create a new todo item and save it to the database
    /// </summary>
    private static async Task<Created<TodoItem>> CreateTodo(HttpContext context, ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Update a todo item and save it to the database 
    /// </summary>
    private static async Task<Ok<TodoItem>> UpdateTodo(HttpContext context, ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Delete a todo item and save it to the database 
    /// </summary>
    private static async Task<Ok> DeleteTodo(HttpContext context, ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }
}