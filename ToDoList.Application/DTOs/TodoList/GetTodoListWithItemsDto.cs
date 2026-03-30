using ToDoList.Application.DTOs.TodoListItem;

namespace ToDoList.Application.DTOs.TodoList;

public sealed class GetTodoListWithItemsDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
    public Guid OwnerId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public DateTime? DueDate { get; init; }
    public DateTime? CompletedAt { get; init; }
    public IReadOnlyList<GetTodoListItemDto> Items { get; init; } = [];
}
