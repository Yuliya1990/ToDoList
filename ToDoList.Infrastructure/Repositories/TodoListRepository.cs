using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

public class TodoListRepository : ITodoListRepository
{
  private readonly AppDbContext _context;

  public TodoListRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<TodoList?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.TodoLists
      .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
  }

  public async Task<TodoList?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.TodoLists
      .AsNoTracking()
      .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
  }

  public async Task<TodoList?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.TodoLists
      .Include(l => l.Items)
      .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
  }

  public async Task<TodoList?> GetByIdWithItemsAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.TodoLists
      .AsNoTracking()
      .Include(l => l.Items)
      .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
  }

  public async Task<IReadOnlyList<TodoList>> GetAllByOwnerAsNoTrackingAsync(Guid ownerId, CancellationToken cancellationToken = default)
  {
    return await _context.TodoLists
      .AsNoTracking()
      .Where(l => l.OwnerId == ownerId)
      .ToListAsync(cancellationToken);
  }

  public async Task AddAsync(TodoList todoList, CancellationToken cancellationToken = default)
  {
    await _context.TodoLists.AddAsync(todoList, cancellationToken);
  }

  public Task UpdateAsync(TodoList todoList, CancellationToken cancellationToken = default)
  {
    _context.TodoLists.Update(todoList);
    return Task.CompletedTask;
  }

  public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var list = await _context.TodoLists
      .FindAsync(new object[] { id }, cancellationToken);

    if (list is not null)
      _context.TodoLists.Remove(list);
  }

  public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    await _context.SaveChangesAsync(cancellationToken);
  }
}