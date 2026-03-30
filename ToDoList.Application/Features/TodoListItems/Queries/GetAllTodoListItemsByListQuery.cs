using MediatR;
using ToDoList.Application.DTOs.TodoListItem;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoListItems.Queries;

public sealed record GetAllTodoListItemsByListQuery(Guid TodoListId) : IRequest<IReadOnlyList<GetTodoListItemDto>>;

public sealed class GetAllTodoListItemsByListQueryHandler : IRequestHandler<GetAllTodoListItemsByListQuery, IReadOnlyList<GetTodoListItemDto>>
{
    private readonly ITodoListItemRepository _itemRepository;

    public GetAllTodoListItemsByListQueryHandler(ITodoListItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IReadOnlyList<GetTodoListItemDto>> Handle(GetAllTodoListItemsByListQuery query, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllByListAsNoTrackingAsync(query.TodoListId, cancellationToken);
        return items.Select(i => i.ToDto()).ToList();
    }
}
