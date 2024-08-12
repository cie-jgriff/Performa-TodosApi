using Microsoft.EntityFrameworkCore;
using Todo.Extensions;
using Todo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCore(new HttpClient());
builder.Services.AddDbContext<TodoDbContext>(opt => opt.UseInMemoryDatabase("TodosDb"));
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
