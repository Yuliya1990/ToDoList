using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

public class TodoListItemRepository : ITodoListItemRepository
{
  public Task AddAsync(TodoListItem item, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<IReadOnlyList<TodoListItem>> GetAllByListAsNoTrackingAsync(Guid todoListId, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<TodoListItem?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<TodoListItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(TodoListItem item, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}