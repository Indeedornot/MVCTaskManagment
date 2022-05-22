namespace TaskApi.Controllers;

public static class ApiIps
{
    public const string GetAllTasks = "GetAllTasks";
    public const string GetTaskById = "GetTaskById/{id:int}";
    public const string GetTaskByName = "GetTaskByName/{name}";
    public const string GetTaskByStatus = "GetTaskByStatus/{status:bool}";
    public const string GetTaskByDeadlineDate = "GetTaskByDeadlineDate/{date:datetime}";
    public const string GetTaskByFinishDate = "GetTaskByFinishDate/{date:datetime}";
    public const string GetTaskByDate = "GetTaskByDate/{date:datetime}";
    
    public const string DeleteTaskById = "DeleteTaskById/{id:int}";
    public const string DeleteTaskByName = "DeleteTaskByName/{name}";
    public const string DeleteTaskByStatus = "DeleteTaskByStatus/{status:bool}";
    public const string DeleteTaskByDeadlineDate = "DeleteTaskByDeadlineDate/{date:datetime}";
    public const string DeleteTaskByFinishDate = "DeleteTaskByFinishDate/{date:datetime}";
    public const string DeleteTaskByDate = "DeleteTaskByDate/{date:datetime}";
    
    public const string UpdateTaskById = "UpdateTaskById/{id:int}";
    public const string UpdateTaskByName = "UpdateTaskByName/{name}";
    public const string UpdateTaskByStatus = "UpdateTaskByStatus/{status:bool}";
    public const string UpdateTaskByDeadlineDate = "UpdateTaskByDeadlineDate/{date:datetime}";
    public const string UpdateTaskByFinishDate = "UpdateTaskByFinishDate/{date:datetime}";
    public const string UpdateTaskByDate = "UpdateTaskByDate/{date:datetime}";
    
    public const string AddTask = "AddTask";
    
}