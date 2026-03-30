namespace ToDoList.Application.DTOs.TodoListItem;

public sealed class GetTodoListItemDto
{
    public Guid Id { get; init; }
    public Guid TodoListId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string Priority { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public DateTime? DueDate { get; init; }
    public DateTime? CompletedAt { get; init; }
}
