using MediatR;
using ToDoList.Application.DTOs.User;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.Users.Queries;

public sealed record GetAllUsersQuery(int Page = 1, int PageSize = 20) : IRequest<IReadOnlyList<GetUserDto>>;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<GetUserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<GetUserDto>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var skip = (query.Page - 1) * query.PageSize;
        var users = await _userRepository.GetAllAsNoTrackingAsync(skip, query.PageSize, cancellationToken);
        return users.Select(u => u.ToDto()).ToList();
    }
}
