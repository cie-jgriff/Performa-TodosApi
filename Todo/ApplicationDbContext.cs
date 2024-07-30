using Microsoft.EntityFrameworkCore;
using Todo.Domain;

namespace Todo;

public class ApplicationDbContext : DbContext
{
    public DbSet<TodoItem> Todos { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}