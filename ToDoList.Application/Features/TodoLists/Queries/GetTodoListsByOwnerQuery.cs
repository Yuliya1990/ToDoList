using MediatR;
using ToDoList.Application.DTOs.TodoList;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Queries;

public sealed record GetTodoListsByOwnerQuery(Guid OwnerId) : IRequest<IReadOnlyList<GetTodoListDto>>;

public sealed class GetTodoListsByOwnerQueryHandler : IRequestHandler<GetTodoListsByOwnerQuery, IReadOnlyList<GetTodoListDto>>
{
    private readonly ITodoListRepository _todoListRepository;

    public GetTodoListsByOwnerQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<IReadOnlyList<GetTodoListDto>> Handle(GetTodoListsByOwnerQuery query, CancellationToken cancellationToken)
    {
        var todoLists = await _todoListRepository.GetAllByOwnerAsNoTrackingAsync(query.OwnerId, cancellationToken);
        return todoLists.Select(l => l.ToDto()).ToList();
    }
}
