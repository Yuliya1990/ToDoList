using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.TodoListItem;
using ToDoList.Application.Features.TodoListItems.Commands;
using ToDoList.Application.Features.TodoListItems.Queries;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TodoListItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoListItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoListItemDto dto, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(
            new CreateTodoListItemCommand(dto.TodoListId, dto.Title, dto.Description, dto.Priority, dto.DueDate),
            cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoListItemByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("list/{todoListId:guid}")]
    public async Task<IActionResult> GetAllByList(Guid todoListId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllTodoListItemsByListQuery(todoListId), cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoListItemDto dto, CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateTodoListItemCommand(id, dto.Title, dto.Description, dto.Priority, dto.DueDate),
            cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteTodoListItemCommand(id), cancellationToken);
        return NoContent();
    }
}
