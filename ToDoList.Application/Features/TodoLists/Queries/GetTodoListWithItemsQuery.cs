using MediatR;
using ToDoList.Application.DTOs.TodoList;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoLists.Queries;

public sealed record GetTodoListWithItemsQuery(Guid Id) : IRequest<GetTodoListWithItemsDto?>;

public sealed class GetTodoListWithItemsQueryHandler : IRequestHandler<GetTodoListWithItemsQuery, GetTodoListWithItemsDto?>
{
    private readonly ITodoListRepository _todoListRepository;

    public GetTodoListWithItemsQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<GetTodoListWithItemsDto?> Handle(GetTodoListWithItemsQuery query, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdWithItemsAsNoTrackingAsync(query.Id, cancellationToken);
        return todoList?.ToDtoWithItems();
    }
}
