using ToDoList.Domain.Common;

namespace ToDoList.Domain.Entities;

public class TodoList : Entity
{
    private TodoList() { }

    private readonly List<TodoListItem> _items = [];
    public string Title { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }
    public Guid OwnerId { get; private set; }
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; private set; }
    public DateTime? DueDate { get; private set; }
    public User? Owner { get; private set; }
    public IReadOnlyList<TodoListItem> Items => _items.AsReadOnly();

    public static TodoList Create(string title, Guid ownerId, DateTime? dueDate = null) => new()
    {
        Title = title,
        OwnerId = ownerId,
        DueDate = dueDate
    };

    public void Update(string title, DateTime? dueDate)
    {
        Title = title;
        DueDate = dueDate;
        UpdatedAt = DateTime.UtcNow;
    }

    public void CompleteItem(Guid itemId)
    {
        var item = _items.First(i => i.Id == itemId);
        item.Complete();

        if (_items.All(i => i.IsCompleted))
        {
            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void AddItem(TodoListItem item)
    {
        _items.Add(item);

        if (IsCompleted)
        {
            IsCompleted = false;
            CompletedAt = null;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}