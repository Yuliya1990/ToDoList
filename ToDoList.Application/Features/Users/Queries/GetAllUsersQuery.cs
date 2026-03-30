using MediatR;
using ToDoList.Application.DTOs.User;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.Users.Queries;

public sealed record GetAllUsersQuery(int Skip = 0, int Take = 20) : IRequest<IReadOnlyList<GetUserDto>>;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<GetUserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<GetUserDto>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsNoTrackingAsync(query.Skip, query.Take, cancellationToken);
        return users.Select(u => u.ToDto()).ToList();
    }
}
