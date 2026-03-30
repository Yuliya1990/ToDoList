using MediatR;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Commands;

public sealed record DeleteTodoListCommand(Guid Id) : IRequest<Unit>;

public sealed class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, Unit>
{
    private readonly ITodoListRepository _todoListRepository;

    public DeleteTodoListCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Unit> Handle(DeleteTodoListCommand command, CancellationToken cancellationToken)
    {
        await _todoListRepository.DeleteAsync(command.Id, cancellationToken);
        await _todoListRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
