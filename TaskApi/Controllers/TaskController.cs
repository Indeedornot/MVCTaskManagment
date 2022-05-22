using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using Task = System.Threading.Tasks.Task;

namespace TaskApi.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly TasksDbContext _context;
    public TaskController(TasksDbContext context)
    {
        _context = context;
    }
    
    #region GetTask all, by id, created, finished, deadline, title, status
    [HttpGet(ApiIps.GetAllTasks)]
    public List<Data.Task?> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }
    
    
    [HttpGet(ApiIps.GetTaskById)]
    public async Task<Data.Task?> GetTaskById(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }
    
    [HttpGet(ApiIps.GetTaskByDate)]

    public Data.Task? GetTaskByDate(DateTime date)
    {
        return _context.Tasks.FirstOrDefault(x => x != null && x.Created == date);
    }
    
    [HttpGet(ApiIps.GetTaskByFinishDate)]
    public Data.Task? GetTaskByFinishDate(DateTime date)
    {
        return _context.Tasks.FirstOrDefault(x => x != null && x.Finished == date);
    }
    
    [HttpGet(ApiIps.GetTaskByDeadlineDate)]
    public Data.Task? GetTaskByDeadlineDate(DateTime date)
    {
        return _context.Tasks.FirstOrDefault(x => x != null && x.Deadline == date);
    }
    
    [HttpGet(ApiIps.GetTaskByName)]
    public Data.Task? GetTaskByName(string name)
    {
        return _context.Tasks.FirstOrDefault(x => x != null && x.Name == name);
    }
    
    [HttpGet(ApiIps.GetTaskByStatus)]
    public Data.Task? GetTaskByStatus(bool status)
    {
        return _context.Tasks.FirstOrDefault(x => x != null && x.IsFinished == status);
    }
    
    #endregion
    
    #region Delete Task by id, created, finished, deadline, title, status
    
    [HttpDelete(ApiIps.DeleteTaskById)]
    public async Task<Data.Task?> DeleteTaskById(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    [HttpDelete(ApiIps.DeleteTaskByDate)]
    public async Task<Data.Task?> DeleteTaskByDate(DateTime date)
    {
        var task = _context.Tasks.FirstOrDefault(x=> x != null && x.Created == date);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    [HttpDelete(ApiIps.DeleteTaskByFinishDate)]
    public async Task<Data.Task?> DeleteTaskByFinishDate(DateTime date)
    {
        var task = _context.Tasks.FirstOrDefault(x=> x != null && x.Finished == date);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    [HttpDelete(ApiIps.DeleteTaskByDeadlineDate)]
    public async Task<Data.Task?> DeleteTaskByDeadlineDate(DateTime date)
    {
        var task = _context.Tasks.FirstOrDefault(x=> x!.Deadline == date);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    [HttpDelete(ApiIps.DeleteTaskByName)]
    public async Task<Data.Task?> DeleteTaskByName(string name)
    {
        var task = _context.Tasks.FirstOrDefault(x=> x != null && x.Name == name);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    [HttpDelete(ApiIps.DeleteTaskByStatus)]
    public async Task<Data.Task?> DeleteTaskByStatus(bool status)
    {
        var task = _context.Tasks.FirstOrDefault(x=> x != null && x.IsFinished == status);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    #endregion
    
    #region Update Task by id, created, finished, deadline, title, status
    
    [HttpPut(ApiIps.UpdateTaskById)]
    public async Task<Data.Task?> UpdateTaskById(int id, [FromBody] Data.Task task)
    {
        var oldTask = await _context.Tasks.FindAsync(id);
        if (oldTask == null)
        {
            return null;
        }

        oldTask.Created = task.Created ?? oldTask.Created;
        oldTask.Finished = task.Finished ?? oldTask.Finished;
        oldTask.Deadline = task.Deadline ?? oldTask.Deadline;
        oldTask.Name = task.Name ?? oldTask.Name;
        oldTask.IsFinished = task.IsFinished ?? oldTask.IsFinished;

        await _context.SaveChangesAsync();

        return oldTask;
    }
    
    [HttpPut(ApiIps.UpdateTaskByDate)]
    public async Task<Data.Task?> UpdateTaskByDate(DateTime date, [FromBody] Data.Task task)
    {
        var oldTask = _context.Tasks.FirstOrDefault(x=> x != null && x.Created == date);
        if (oldTask == null)
        {
            return null;
        }

        oldTask.Created = task.Created ?? oldTask.Created;
        oldTask.Finished = task.Finished ?? oldTask.Finished;
        oldTask.Deadline = task.Deadline ?? oldTask.Deadline;
        oldTask.Name = task.Name ?? oldTask.Name;
        oldTask.IsFinished = task.IsFinished ?? oldTask.IsFinished;

        await _context.SaveChangesAsync();

        return oldTask;
    }
    
    [HttpPut(ApiIps.UpdateTaskByFinishDate)]
    public async Task<Data.Task?> UpdateTaskByFinishDate(DateTime date, [FromBody] Data.Task task)
    {
        var oldTask = _context.Tasks.FirstOrDefault(x=> x != null && x.Finished == date);
        if (oldTask == null)
        {
            return null;
        }

        oldTask.Created = task.Created ?? oldTask.Created;
        oldTask.Finished = task.Finished ?? oldTask.Finished;
        oldTask.Deadline = task.Deadline ?? oldTask.Deadline;
        oldTask.Name = task.Name ?? oldTask.Name;
        oldTask.IsFinished = task.IsFinished ?? oldTask.IsFinished;

        await _context.SaveChangesAsync();

        return oldTask;
    }
    
    [HttpPut(ApiIps.UpdateTaskByDeadlineDate)]
    public async Task<Data.Task?> UpdateTaskByDeadlineDate(DateTime date, [FromBody] Data.Task task)
    {
        var oldTask = _context.Tasks.FirstOrDefault(x=> x != null && x.Deadline == date);
        if (oldTask == null)
        {
            return null;
        }

        oldTask.Created = task.Created ?? oldTask.Created;
        oldTask.Finished = task.Finished ?? oldTask.Finished;
        oldTask.Deadline = task.Deadline ?? oldTask.Deadline;
        oldTask.Name = task.Name ?? oldTask.Name;
        oldTask.IsFinished = task.IsFinished ?? oldTask.IsFinished;

        await _context.SaveChangesAsync();

        return oldTask;
    }
    
    [HttpPut(ApiIps.UpdateTaskByName)]
    public async Task<Data.Task?> UpdateTaskByName(string name, [FromBody] Data.Task task)
    {
        var oldTask = _context.Tasks.FirstOrDefault(x=> x != null && x.Name == name);
        if (oldTask == null)
        {
            return null;
        }

        oldTask.Created = task.Created ?? oldTask.Created;
        oldTask.Finished = task.Finished ?? oldTask.Finished;
        oldTask.Deadline = task.Deadline ?? oldTask.Deadline;
        oldTask.Name = task.Name ?? oldTask.Name;
        oldTask.IsFinished = task.IsFinished ?? oldTask.IsFinished;

        await _context.SaveChangesAsync();

        return oldTask;
    }
    
    [HttpPut(ApiIps.UpdateTaskByStatus)]
    public async Task<Data.Task?> UpdateTaskByStatus(bool status, [FromBody] Data.Task task)
    {
        var oldTask = _context.Tasks.FirstOrDefault(x=> x != null && x.IsFinished == status);
        if (oldTask == null)
        {
            return null;
        }

        oldTask.Created = task.Created ?? oldTask.Created;
        oldTask.Finished = task.Finished ?? oldTask.Finished;
        oldTask.Deadline = task.Deadline ?? oldTask.Deadline;
        oldTask.Name = task.Name ?? oldTask.Name;
        oldTask.IsFinished = task.IsFinished ?? oldTask.IsFinished;

        await _context.SaveChangesAsync();

        return oldTask;
    }
    
    #endregion
    
    #region Add Task
    
    [HttpPost(ApiIps.AddTask)]
    public async Task<Data.Task?> AddTask([FromBody] Data.Task? task)
    {
        if(task == null)
        {
            return null;
        }

        var existingTask = await _context.Tasks.FindAsync(task.Id);
        if(existingTask != null)
        {
            return null;
        }
        
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }
    
    #endregion
}