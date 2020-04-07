using Microsoft.EntityFrameworkCore;
using R2.Todo.Domain.Entities;

namespace R2.Todo.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(a => a.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(a => a.Done);
            modelBuilder.Entity<TodoItem>().Property(a => a.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(a => a.User);
        }
    }
}