using AutoMapper;
using MediatR;
using Todo.Domain.Features.TodoFeature.Dtos;
using Todo.Domain.Stores;

namespace Todo.Domain.Features.TodoFeature.Queries;

public class GetTodosRequest : IRequest<List<TodoItemDto>>
{

}

public class GetTodosHandler : IRequestHandler<GetTodosRequest, List<TodoItemDto>>
{
    private readonly ITodoStore _todoStore;
    private readonly IMapper _mapper;

    public GetTodosHandler(ITodoStore todoStore, IMapper mapper)
    {
        _todoStore = todoStore;
        _mapper = mapper;
    }

    public async Task<List<TodoItemDto>> Handle(GetTodosRequest request, CancellationToken cancellationToken)
    {
        var todos = await _todoStore.GetTodosAsync();
        return _mapper.Map<List<TodoItemDto>>(todos);
    }
}
