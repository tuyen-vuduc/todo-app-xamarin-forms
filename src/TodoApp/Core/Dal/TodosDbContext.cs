using System.IO;
using Microsoft.EntityFrameworkCore;


namespace TodoApp
{
    public class TodosDbContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }

        public string ConnectionString { get; private set; }

        public TodosDbContext(string connectionString = null)
        {
            ConnectionString = connectionString;

            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionString = string.IsNullOrWhiteSpace(ConnectionString)
                ? $"Filename={Path.Combine(FileSystem.AppDataDirectory, "todos.db3")}"
                : ConnectionString;

            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}
