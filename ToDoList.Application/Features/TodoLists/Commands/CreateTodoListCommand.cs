using MediatR;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Commands;

public sealed record CreateTodoListCommand(string Title, Guid OwnerId, DateTime? DueDate) : IRequest<Guid>;

public sealed class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly ITodoListRepository _todoListRepository;

    public CreateTodoListCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Guid> Handle(CreateTodoListCommand command, CancellationToken cancellationToken)
    {
        var todoList = TodoList.Create(command.Title, command.OwnerId, command.DueDate);
        await _todoListRepository.AddAsync(todoList, cancellationToken);
        await _todoListRepository.SaveChangesAsync(cancellationToken);
        return todoList.Id;
    }
}
