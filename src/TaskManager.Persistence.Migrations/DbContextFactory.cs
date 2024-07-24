using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskManager.Persistence.Migrations
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext_Sqlite>
    {
        public static string ConnectionString = "Data Source = ..\\TaskManager.Persistence.Migrations\\TaskManager.db";
        DataContext_Sqlite IDesignTimeDbContextFactory<DataContext_Sqlite>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext_Sqlite>();
            builder.UseSqlite(ConnectionString);
            return new DataContext_Sqlite(builder.Options);
        }
    }
}