namespace TaskApi.Controllers;

public static class ApiIps
{
    public const string GetAllTasks = "GetAllTasks";
    public const string GetTasksByIndex = "GetTasksByIndex/{indexStart:int}/{elementCount:int}";
    public const string GetTaskById = "GetTaskById/{id:int}";
    public const string GetTasksByName = "GetTasksByName/{name}";
    public const string GetTasksByStatus = "GetTasksByStatus/{status:bool}";

    public const string DeleteTaskById = "DeleteTaskById/{id:int}";

    public const string UpdateTaskById = "UpdateTaskById/{id:int}";

    public const string AddTask = "AddTask";
    
}