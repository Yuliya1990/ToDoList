namespace ToDoList.Application.DTOs.TodoListItem;

public sealed class UpdateTodoListItemDto
{
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string Priority { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
}
