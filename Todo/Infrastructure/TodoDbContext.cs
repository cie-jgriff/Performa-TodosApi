using Microsoft.EntityFrameworkCore;
using Todo.Domain.DataModels;

namespace Todo;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> Todos { get; set; }

    public TodoDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
    }
}
