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
    private readonly ITodoListRepository _todoListRepository;

    public CreateTodoListItemCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Guid> Handle(CreateTodoListItemCommand command, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdWithItemsAsync(command.TodoListId, cancellationToken);
        if (todoList is null) throw new InvalidOperationException($"TodoList {command.TodoListId} not found.");

        var priority = Enum.Parse<Priority>(command.Priority, ignoreCase: true);

        var item = TodoListItem.Create(
            command.TodoListId,
            command.Title,
            command.Description,
            priority,
            command.DueDate);

        todoList.AddItem(item);

        await _todoListRepository.UpdateAsync(todoList, cancellationToken);
        await _todoListRepository.SaveChangesAsync(cancellationToken);
        return item.Id;
    }
}
