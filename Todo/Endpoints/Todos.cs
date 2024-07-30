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

        group.MapGet("", async (ApplicationDbContext dbContext) => await GetTodos(dbContext));
        
        //todo: Implement the remaining endpoints
    }
    
    private static async Task<Ok<List<Domain.TodoItem>>> GetTodos(ApplicationDbContext dbContext)
    {
        var todos = await dbContext.Todos.ToListAsync();
        return TypedResults.Ok(todos);
    }
    
    /// <summary>
    /// Create a new todo item and save it to the database
    /// Returns a 201 Created status code with the created todo item
    /// </summary>
    private static async Task<Created<TodoItem>> CreateTodo(/*todo: add the necessary parameters for this request*/)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Update a todo item and save it to the database
    /// Returns a 200 OK status code with the updated todo item
    /// </summary>
    private static async Task<Ok<TodoItem>> UpdateTodo(/*todo: add the necessary parameters for this request*/)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Delete a todo item and save it to the database
    /// Returns a 200 OK status code with the deleted todo item
    /// </summary>
    private static async Task<Ok> DeleteTodo(/*todo: add the necessary parameters for this request*/)
    {
        throw new NotImplementedException();
    }
}