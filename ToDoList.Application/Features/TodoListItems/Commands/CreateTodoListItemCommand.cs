using MediatR;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoListItems.Commands;

public sealed record CreateTodoListItemCommand(
    Guid TodoListId,
    string Title,
    string? Description,
    string Priority,
    DateTime? DueDate) : IRequest<Guid>;

public sealed class CreateTodoListItemCommandHandler : IRequestHandler<CreateTodoListItemCommand, Guid>
{
    private readonly ITodoListItemRepository _itemRepository;

    public CreateTodoListItemCommandHandler(ITodoListItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Guid> Handle(CreateTodoListItemCommand command, CancellationToken cancellationToken)
    {
        var priority = Enum.Parse<Priority>(command.Priority, ignoreCase: true);

        var item = TodoListItem.Create(
            command.TodoListId,
            command.Title,
            command.Description,
            priority,
            command.DueDate);

        await _itemRepository.AddAsync(item, cancellationToken);
        await _itemRepository.SaveChangesAsync(cancellationToken);
        return item.Id;
    }
}
