using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Domain;
using TaskManager.Core.Repositories;

namespace TaskManager.Persistence.Migrations
{
    public class DataContext_Sqlite : DbContext, IRepository
    {
        public DataContext_Sqlite(DbContextOptions<DataContext_Sqlite> options) : base(options) { }

        public DbSet<TodoTask> TodoTask { get; set; }
    }
}
