using ToDoList.Application.DTOs.User;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappers;

public static class UserMapper
{
    public static GetUserDto ToDto(this User user) => new()
    {
        Id = user.Id,
        Username = user.Username,
        Email = user.Email,
        CreatedAt = user.CreatedAt
    };
}
