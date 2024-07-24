using System;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Domain;
using TaskManager.Core.Repositories;

namespace TaskManager.Infrastructure.Extensions
{
    public static class ToDoTaskRepositoryExtensions
    {
        public static async Task<TodoTask> GetOrFailAsyncIfEmpty(this IToDoTaskRepository repository, Guid id, CancellationToken cancellationToken)
        {
            var task = await repository.GetByIdAsync(id, cancellationToken);
            if (task == null)
            {
                throw new Exception($"There is no such task: '{id}'");
            }
            return task;
        }
    }
}
