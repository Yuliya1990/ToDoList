using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.TodoList;
using ToDoList.Application.Features.TodoLists.Commands;
using ToDoList.Application.Features.TodoLists.Queries;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TodoListsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoListsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoListDto dto, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new CreateTodoListCommand(dto.Title, dto.OwnerId, dto.DueDate), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoListByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("{id:guid}/items")]
    public async Task<IActionResult> GetWithItems(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoListWithItemsQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("owner/{ownerId:guid}")]
    public async Task<IActionResult> GetByOwner(Guid ownerId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoListsByOwnerQuery(ownerId), cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoListDto dto, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateTodoListCommand(id, dto.Title, dto.DueDate), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteTodoListCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost("{listId:guid}/items/{itemId:guid}/complete")]
    public async Task<IActionResult> CompleteItem(Guid listId, Guid itemId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CompleteTodoListItemCommand(listId, itemId), cancellationToken);
        return NoContent();
    }
}
