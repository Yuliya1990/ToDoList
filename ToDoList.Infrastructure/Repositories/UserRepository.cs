using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
  }

  public async Task<User?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .AsNoTracking()
      .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
  }

  public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
  }

  public async Task<User?> GetByEmailAsNoTrackingAsync(string email, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .AsNoTracking()
      .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
  }

  public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
  }

  public async Task<User?> GetByUsernameAsNoTrackingAsync(string username, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .AsNoTracking()
      .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
  }

  public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .ToListAsync(cancellationToken);
  }

  public async Task<IReadOnlyList<User>> GetAllAsNoTrackingAsync(int skip, int take, CancellationToken cancellationToken = default)
  {
    return await _context.Users
      .AsNoTracking()
      .Skip(skip)
      .Take(take)
      .ToListAsync(cancellationToken);
  }

  public async Task AddAsync(User user, CancellationToken cancellationToken = default)
  {
    await _context.Users.AddAsync(user, cancellationToken);
  }

  public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    await _context.SaveChangesAsync(cancellationToken);
  }
}