using MediatR;
using ToDoList.Application.DTOs.TodoListItem;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.TodoListItems.Queries;

public sealed record GetTodoListItemByIdQuery(Guid Id) : IRequest<GetTodoListItemDto?>;

public sealed class GetTodoListItemByIdQueryHandler : IRequestHandler<GetTodoListItemByIdQuery, GetTodoListItemDto?>
{
    private readonly ITodoListItemRepository _itemRepository;

    public GetTodoListItemByIdQueryHandler(ITodoListItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<GetTodoListItemDto?> Handle(GetTodoListItemByIdQuery query, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);
        return item?.ToDto();
    }
}
