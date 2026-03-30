using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  public Task AddAsync(User user, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<IReadOnlyList<User>> GetAllAsNoTrackingAsync(int skip, int take, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByEmailAsNoTrackingAsync(string email, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByUsernameAsNoTrackingAsync(string username, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}