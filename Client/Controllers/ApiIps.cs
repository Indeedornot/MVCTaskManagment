namespace Client.Controllers;

public static class ApiIps
{
    private const string ApiUrl = "https://localhost:6001";
    public const string GetAllTasks = $"{ApiUrl}/GetAllTasks";
    public static string GetTaskById(int id) => $"{ApiUrl}/GetTaskById/{id}";
    public static string GetTaskByName(string name) => $"{ApiUrl}/GetTaskByName/{name}";
    public static string GetTaskByStatus(bool status) => $"{ApiUrl}/GetTaskByStatus/{status}";
    public static string GetTaskByDeadlineDate(DateTime date) => $"{ApiUrl}/GetTaskByDeadlineDate/{date}";
    public static string GetTaskByFinishDate(DateTime date) => $"{ApiUrl}/GetTaskByFinishDate/{date}";
    public static string GetTaskByDate(DateTime date) => $"{ApiUrl}/GetTaskByDate/{date}";
    
    public static string DeleteTaskById(int id) => $"{ApiUrl}/DeleteTaskById/{id}";
    public static string DeleteTaskByName(string name) => $"{ApiUrl}/DeleteTaskByName/{name}";
    public static string DeleteTaskByStatus(bool status) => $"{ApiUrl}/DeleteTaskByStatus/{status}";
    public static string DeleteTaskByDeadlineDate(DateTime date) => $"{ApiUrl}/DeleteTaskByDeadlineDate/{date}";
    public static string DeleteTaskByFinishDate(DateTime date) => $"{ApiUrl}/DeleteTaskByFinishDate/{date}";
    public static string DeleteTaskByDate(DateTime date) => $"{ApiUrl}/DeleteTaskByDate/{date}";
    
    public static string UpdateTaskById(int id) => $"{ApiUrl}/UpdateTaskById/{id}";
    public static string UpdateTaskByName(string name) => $"{ApiUrl}/UpdateTaskByName/{name}";
    public static string UpdateTaskByStatus(bool status) => $"{ApiUrl}/UpdateTaskByStatus/{status}";
    public static string UpdateTaskByDeadlineDate(DateTime date) => $"{ApiUrl}/UpdateTaskByDeadlineDate/{date}";
    public static string UpdateTaskByFinishDate(DateTime date) => $"{ApiUrl}/UpdateTaskByFinishDate/{date}";
    public static string UpdateTaskByDate(DateTime date) => $"{ApiUrl}/UpdateTaskByDate/{date}";
    
    public const string AddTask = $"{ApiUrl}/AddTask";
}
