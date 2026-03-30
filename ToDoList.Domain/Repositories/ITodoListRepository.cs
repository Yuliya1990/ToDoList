using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories;

public interface ITodoListRepository
{
    Task<TodoList?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TodoList?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TodoList?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TodoList?> GetByIdWithItemsAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TodoList>> GetAllByOwnerAsNoTrackingAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task AddAsync(TodoList todoList, CancellationToken cancellationToken = default);
    Task UpdateAsync(TodoList todoList, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}