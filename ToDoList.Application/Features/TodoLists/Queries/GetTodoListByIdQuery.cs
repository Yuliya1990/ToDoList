using MediatR;
using ToDoList.Application.DTOs.TodoList;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Queries;

public sealed record GetTodoListByIdQuery(Guid Id) : IRequest<GetTodoListDto?>;

public sealed class GetTodoListByIdQueryHandler : IRequestHandler<GetTodoListByIdQuery, GetTodoListDto?>
{
    private readonly ITodoListRepository _todoListRepository;

    public GetTodoListByIdQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<GetTodoListDto?> Handle(GetTodoListByIdQuery query, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);
        return todoList?.ToDto();
    }
}
