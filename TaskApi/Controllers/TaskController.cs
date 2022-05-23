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
    
    [HttpGet(ApiIps.GetTasksByIndex)]
    public async Task<List<Data.Task?>> GetTasksByIndex(int indexStart, int elementCount)
    {
        if(indexStart < 0 || elementCount < 0)
        {
            return null;
        }
        return _context.Tasks.Skip(indexStart).Take(elementCount).ToList();
    }
    
    
    [HttpGet(ApiIps.GetTaskById)]
    public async Task<Data.Task?> GetTaskById(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    [HttpGet(ApiIps.GetTasksByName)]
    public List<Data.Task?> GetTasksByName(string name)
    {
        return _context.Tasks.Where(x => x != null && x.Name.Contains(name)).ToList();
    }
    
    [HttpGet(ApiIps.GetTasksByStatus)]
    public List<Data.Task?> GetTasksByStatus(bool status)
    {
        return _context.Tasks.Where(x => x != null && x.IsFinished == status).ToList();
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