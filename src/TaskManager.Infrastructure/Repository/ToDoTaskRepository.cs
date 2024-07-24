using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Domain;
using TaskManager.Core.Repositories;
using TaskManager.Persistence.Migrations;

namespace TaskManager.Infrastructure.Repository
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly DataContext_Sqlite _context;

        public ToDoTaskRepository(DataContext_Sqlite context)
        {
            _context = context;
        }

        public async Task<TodoTask> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.TodoTask.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.TodoTask.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(TodoTask task, CancellationToken cancellationToken)
        {
            try {
                await _context.TodoTask.AddAsync(task);
                await _context.SaveChangesAsync(cancellationToken);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
            }

        }

        public async Task UpdateAsync(TodoTask task, CancellationToken cancellationToken)
        {
            _context.TodoTask.Update(task);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var task = _context.TodoTask.SingleOrDefault(t => t.Id == id);
            _context.TodoTask.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);
            await Task.CompletedTask;
        }
    }
}
