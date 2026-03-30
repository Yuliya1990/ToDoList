using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

public class TodoListItemRepository : ITodoListItemRepository
{
  private readonly AppDbContext _context;

  public TodoListItemRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<TodoListItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.TodoListItems
      .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
  }

  public async Task<TodoListItem?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.TodoListItems
      .AsNoTracking()
      .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
  }

  public async Task<IReadOnlyList<TodoListItem>> GetAllByListAsNoTrackingAsync(Guid todoListId, CancellationToken cancellationToken = default)
  {
    return await _context.TodoListItems
      .AsNoTracking()
      .Where(i => i.TodoListId == todoListId)
      .ToListAsync(cancellationToken);
  }

  public async Task AddAsync(TodoListItem item, CancellationToken cancellationToken = default)
  {
    await _context.TodoListItems.AddAsync(item, cancellationToken);
  }

  public Task UpdateAsync(TodoListItem item, CancellationToken cancellationToken = default)
  {
    _context.TodoListItems.Update(item);
    return Task.CompletedTask;
  }

  public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var item = await _context.TodoListItems
      .FindAsync(new object[] { id }, cancellationToken);

    if (item is not null)
      _context.TodoListItems.Remove(item);
  }

  public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    await _context.SaveChangesAsync(cancellationToken);
  }
}