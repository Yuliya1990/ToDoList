using MediatR;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoListItems.Commands;

public sealed record DeleteTodoListItemCommand(Guid Id) : IRequest<Unit>;

public sealed class DeleteTodoListItemCommandHandler : IRequestHandler<DeleteTodoListItemCommand, Unit>
{
    private readonly ITodoListItemRepository _itemRepository;

    public DeleteTodoListItemCommandHandler(ITodoListItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(DeleteTodoListItemCommand command, CancellationToken cancellationToken)
    {
        await _itemRepository.DeleteAsync(command.Id, cancellationToken);
        await _itemRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
