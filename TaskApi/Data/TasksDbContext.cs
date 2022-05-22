using Microsoft.EntityFrameworkCore;

namespace TaskApi.Data;

public class TasksDbContext : DbContext
{
    public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
    { }

    public DbSet<Task?> Tasks { get; set; }
}