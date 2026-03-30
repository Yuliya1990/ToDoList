using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

public class TodoListRepository : ITodoListRepository
{
  public Task AddAsync(TodoList todoList, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<IReadOnlyList<TodoList>> GetAllByOwnerAsNoTrackingAsync(Guid ownerId, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<TodoList?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<TodoList?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<TodoList?> GetByIdWithItemsAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<TodoList?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(TodoList todoList, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}