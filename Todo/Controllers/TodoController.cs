using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Todo.Domain.Features.TodoFeature.Dtos;
using Todo.Domain.Features.TodoFeature.Queries;

namespace Todo.Controllers;


[Route("api/v1/[controller]")]
[ApiController]

public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(template: "all")]
    [SwaggerResponse((int)HttpStatusCode.OK, description: "Returns all todos.", typeof(List<TodoItemDto>))]
    public async Task<ActionResult<List<TodoItemDto>>> GetTodos()
    {
        var request = new GetTodosRequest();
        var todos = await _mediator.Send(request);
        return Ok(todos);
    }

}
