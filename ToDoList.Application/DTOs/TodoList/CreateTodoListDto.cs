namespace ToDoList.Application.DTOs.TodoList;

public sealed class CreateTodoListDto
{
    public string Title { get; init; } = string.Empty;
    public Guid OwnerId { get; init; }
    public DateTime? DueDate { get; init; }
}
