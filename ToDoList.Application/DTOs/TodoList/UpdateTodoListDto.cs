namespace ToDoList.Application.DTOs.TodoList;

public sealed class UpdateTodoListDto
{
    public string Title { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
}
