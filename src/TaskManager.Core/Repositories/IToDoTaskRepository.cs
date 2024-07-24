using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Domain;

namespace TaskManager.Core.Repositories
{
    public interface IToDoTaskRepository : IRepository
    {
        Task<IEnumerable<TodoTask>> GetAllAsync(CancellationToken cancellationToken);
        Task<TodoTask> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(TodoTask task, CancellationToken cancellationToken);
        Task UpdateAsync(TodoTask task, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
