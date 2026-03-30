using MediatR;
using ToDoList.Application.DTOs.User;
using ToDoList.Application.Mappers;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Features.Users.Queries;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<GetUserDto?>;

public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserDto?> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);
        return user?.ToDto();
    }
}
