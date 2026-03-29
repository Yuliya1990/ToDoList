using ToDoList.Domain.Common;

namespace ToDoList.Domain.Entities;

public class User : Entity
{
    private User() { }
    private readonly List<TodoList> _todoLists = [];
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public IReadOnlyList<TodoList> TodoLists => _todoLists.AsReadOnly();
    public static User Create(string username, string email) => new()
    {
        Username = username,
        Email = email
    };
}