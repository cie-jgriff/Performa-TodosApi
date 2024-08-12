using AutoMapper;
using Todo.Domain.Features.TodoFeature.Dtos;

namespace Todo.Domain.DataModels;

public class TodoItem(string title)
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = title;

    public bool IsComplete { get; set; } = false;
}

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<TodoItem, TodoItemDto>();
    }
}
