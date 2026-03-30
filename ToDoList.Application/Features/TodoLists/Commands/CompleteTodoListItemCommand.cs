using MediatR;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Commands;

public sealed record CompleteTodoListItemCommand(Guid ListId, Guid ItemId) : IRequest<Unit>;

public sealed class CompleteTodoListItemCommandHandler : IRequestHandler<CompleteTodoListItemCommand, Unit>
{
    private readonly ITodoListRepository _todoListRepository;

    public CompleteTodoListItemCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Unit> Handle(CompleteTodoListItemCommand command, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdWithItemsAsync(command.ListId, cancellationToken);
        if (todoList is null) return Unit.Value;

        todoList.CompleteItem(command.ItemId);
        await _todoListRepository.UpdateAsync(todoList, cancellationToken);
        await _todoListRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
