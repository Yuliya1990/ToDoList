using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories;

public interface ITodoListItemRepository
{
    Task<TodoListItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TodoListItem?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TodoListItem>> GetAllByListAsNoTrackingAsync(Guid todoListId, CancellationToken cancellationToken = default);
    Task AddAsync(TodoListItem item, CancellationToken cancellationToken = default);
    Task UpdateAsync(TodoListItem item, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}