using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) {}

    public DbSet<MyTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MyTask>().HasKey(t => t.Id);
    }
}