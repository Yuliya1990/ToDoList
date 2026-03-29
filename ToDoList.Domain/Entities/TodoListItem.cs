using ToDoList.Domain.Common;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities;

public class TodoListItem : Entity
{
    private TodoListItem() { }

    public Guid TodoListId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Priority Priority { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    public TodoList? TodoList { get; private set; }

    public static TodoListItem Create(Guid todoListId, string title, string? description, Priority priority, DateTime? dueDate) => new()
    {
        TodoListId = todoListId,
        Title = title,
        Description = description,
        Priority = priority,
        DueDate = dueDate
    };

    public void Update(string title, string? description, Priority priority, DateTime? dueDate)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DueDate = dueDate;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        if (IsCompleted) return;
        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}