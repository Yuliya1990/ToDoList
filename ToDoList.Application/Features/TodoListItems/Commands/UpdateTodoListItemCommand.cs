using MediatR;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoListItems.Commands;

public sealed record UpdateTodoListItemCommand(
    Guid Id,
    string Title,
    string? Description,
    string Priority,
    DateTime? DueDate) : IRequest<Unit>;

public sealed class UpdateTodoListItemCommandHandler : IRequestHandler<UpdateTodoListItemCommand, Unit>
{
    private readonly ITodoListItemRepository _itemRepository;

    public UpdateTodoListItemCommandHandler(ITodoListItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(UpdateTodoListItemCommand command, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(command.Id, cancellationToken);
        if (item is null) return Unit.Value;

        var priority = Enum.Parse<Priority>(command.Priority, ignoreCase: true);

        item.Update(command.Title, command.Description, priority, command.DueDate);
        await _itemRepository.UpdateAsync(item, cancellationToken);
        await _itemRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
