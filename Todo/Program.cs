using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Todo;
using Todo.Extensions;

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
