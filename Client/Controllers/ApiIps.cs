namespace Client.Controllers;

public static class ApiIps
{
    private const string ApiUrl = "https://localhost:6001";
    public const string GetAllTasks = $"{ApiUrl}/GetAllTasks";
    public static string GetTasksByIndex(int indexStart, int elementCount) => $"{ApiUrl}/GetTasksByIndex/{indexStart}/{elementCount}";

    public static string GetTaskById(int id) => $"{ApiUrl}/GetTaskById/{id}";
    public static string GetTasksByName(string name) => $"{ApiUrl}/GetTasksByName/{name}";
    public static string GetTasksByStatus(bool status) => $"{ApiUrl}/GetTasksByStatus/{status}";
    
    public static string DeleteTaskById(int id) => $"{ApiUrl}/DeleteTaskById/{id}";

    public static string UpdateTaskById(int id) => $"{ApiUrl}/UpdateTaskById/{id}";

    public const string AddTask = $"{ApiUrl}/AddTask";
}
