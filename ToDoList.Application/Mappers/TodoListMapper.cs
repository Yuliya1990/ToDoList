using ToDoList.Application.DTOs.TodoList;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappers;

public static class TodoListMapper
{
    public static GetTodoListDto ToDto(this TodoList list) => new()
    {
        Id = list.Id,
        Title = list.Title,
        IsCompleted = list.IsCompleted,
        OwnerId = list.OwnerId,
        CreatedAt = list.CreatedAt,
        UpdatedAt = list.UpdatedAt,
        DueDate = list.DueDate,
        CompletedAt = list.CompletedAt
    };

    public static GetTodoListWithItemsDto ToDtoWithItems(this TodoList list) => new()
    {
        Id = list.Id,
        Title = list.Title,
        IsCompleted = list.IsCompleted,
        OwnerId = list.OwnerId,
        CreatedAt = list.CreatedAt,
        UpdatedAt = list.UpdatedAt,
        DueDate = list.DueDate,
        CompletedAt = list.CompletedAt,
        Items = list.Items.Select(i => i.ToDto()).ToList()
    };
}
