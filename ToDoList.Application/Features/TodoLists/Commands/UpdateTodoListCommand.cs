using MediatR;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Commands;

public sealed record UpdateTodoListCommand(Guid Id, string Title, DateTime? DueDate) : IRequest<Unit>;

public sealed class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand, Unit>
{
    private readonly ITodoListRepository _todoListRepository;

    public UpdateTodoListCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Unit> Handle(UpdateTodoListCommand command, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdAsync(command.Id, cancellationToken);
        if (todoList is null) return Unit.Value;

        todoList.Update(command.Title, command.DueDate);
        await _todoListRepository.UpdateAsync(todoList, cancellationToken);
        await _todoListRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
