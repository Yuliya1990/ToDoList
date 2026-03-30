using ToDoList.Application.DTOs.TodoListItem;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappers;

public static class TodoListItemMapper
{
    public static GetTodoListItemDto ToDto(this TodoListItem item) => new()
    {
        Id = item.Id,
        TodoListId = item.TodoListId,
        Title = item.Title,
        Description = item.Description,
        Priority = item.Priority.ToString(),
        IsCompleted = item.IsCompleted,
        CreatedAt = item.CreatedAt,
        UpdatedAt = item.UpdatedAt,
        DueDate = item.DueDate,
        CompletedAt = item.CompletedAt
    };
}
