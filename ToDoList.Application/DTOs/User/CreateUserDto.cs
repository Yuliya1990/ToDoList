namespace ToDoList.Application.DTOs.User;

public sealed class CreateUserDto
{
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
