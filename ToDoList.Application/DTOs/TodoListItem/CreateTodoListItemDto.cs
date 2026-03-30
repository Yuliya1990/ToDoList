namespace ToDoList.Application.DTOs.TodoListItem;

public sealed class CreateTodoListItemDto
{
    public Guid TodoListId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string Priority { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
}
