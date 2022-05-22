using Microsoft.EntityFrameworkCore;
using TaskApi.Data;

namespace TaskApi.Data;

public static class TasksDbInitializer
{
    public static void Initialize(TasksDbContext context)
    {
        if (context.Tasks.Any())
        {
            return;
        }

        var tasks = new Task[]
        {
            new()
            {
                Created = DateTime.Now.AddDays(-3),
                Deadline = DateTime.Now,
                Description = "Finish the project",
                IsFinished = false,
                Name = "Task 1",
            },
            new()
            {
                Created = DateTime.Now.AddDays(-2),
                Deadline = DateTime.Now,
                Description = "Finish the project 1",
                IsFinished = false,
                Name = "Task 2",
            },
        };
        foreach (var task in tasks)
        {
            context.Tasks.Add(task);
        }

        context.SaveChanges();
    }
}