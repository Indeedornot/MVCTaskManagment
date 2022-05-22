using System.Net.Mime;
using System.Text;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Task = Client.Models.Task;

namespace Client.Controllers;

public static class ApiCommunicator
{
    private static HttpContext HttpContext => new HttpContextAccessor().HttpContext!;
    
    private static async Task<HttpClient> SetToken()
    {
        string? token = await HttpContext.GetTokenAsync("access_token");
        var apiClient = new HttpClient();
        apiClient.SetBearerToken(token);
        return apiClient;
    }

    private static async Task<string?> GetToken()
    {
        return await HttpContext.GetTokenAsync("access_token");
    }

    #region GetTask
    public static async Task<List<Task>> GetAllTasks()
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetAllTasks);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Task>>(content);
    }
    
    public static async Task<Task?> GetTaskById(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetTaskById(id));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> GetTaskByName(string name)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetTaskByName(name));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> GetTaskByStatus(bool status)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetTaskByStatus(status));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }

    public static async Task<Task?> GetTaskByDeadlineDate(DateTime date)
    {
            using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetTaskByDeadlineDate(date));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> GetTaskByFinishDate(DateTime date)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetTaskByFinishDate(date));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> GetTaskByDate(DateTime date)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(ApiIps.GetTaskByDate(date));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    #endregion
    
    #region DeleteTask
    public static async Task<Task?> DeleteTaskById(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.DeleteAsync(ApiIps.DeleteTaskById(id));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> DeleteTaskByName(string name)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.DeleteAsync(ApiIps.DeleteTaskByName(name));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> DeleteTaskByStatus(bool status)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.DeleteAsync(ApiIps.DeleteTaskByStatus(status));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> DeleteTaskByDeadlineDate(DateTime date)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.DeleteAsync(ApiIps.DeleteTaskByDeadlineDate(date));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> DeleteTaskByFinishDate(DateTime date)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.DeleteAsync(ApiIps.DeleteTaskByFinishDate(date));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> DeleteTaskByDate(DateTime date)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.DeleteAsync(ApiIps.DeleteTaskByDate(date));
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    #endregion
    
    #region UpdateTask
    //They return old tasks
    public static async Task<Task?> UpdateTaskById(int id, Task task)
    {
        using var apiClient = new HttpClient();
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(ApiIps.UpdateTaskById(id)),
            Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json")
        };
        request.SetBearerToken(await GetToken());
        var response = await apiClient.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> UpdateTaskByName(string name, Task task)
    {
        using var apiClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(ApiIps.UpdateTaskByName(name)),
            Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8,
                MediaTypeNames.Application.Json /* or "application/json" in older versions */),
        };
        request.SetBearerToken(await GetToken());
        var response = await apiClient.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> UpdateTaskByStatus(bool status, Task task)
    {
        using var apiClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(ApiIps.UpdateTaskByStatus(status)),
            Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8,
                MediaTypeNames.Application.Json /* or "application/json" in older versions */),
        };
        request.SetBearerToken(await GetToken());
        var response = await apiClient.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> UpdateTaskByDeadlineDate(DateTime date, Task task)
    {
        using var apiClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(ApiIps.UpdateTaskByDeadlineDate(date)),
            Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8,
                MediaTypeNames.Application.Json /* or "application/json" in older versions */),
        };
        request.SetBearerToken(await GetToken());
        var response = await apiClient.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> UpdateTaskByFinishDate(DateTime date, Task task)
    {
        using var apiClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(ApiIps.UpdateTaskByFinishDate(date)),
            Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8,
                MediaTypeNames.Application.Json /* or "application/json" in older versions */),
        };
        request.SetBearerToken(await GetToken());
        var response = await apiClient.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    public static async Task<Task?> UpdateTaskByDate(DateTime date, Task task)
    {
        using var apiClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(ApiIps.UpdateTaskByDate(date)),
            Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8,
                MediaTypeNames.Application.Json /* or "application/json" in older versions */),
        };
        request.SetBearerToken(await GetToken());
        var response = await apiClient.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }
    
    #endregion

    #region AddTask
    
    public static async Task<Task?> AddTask(Task task)
    {
        using var apiClient = await SetToken();

        var requestContent = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8,
                MediaTypeNames.Application.Json /* or "application/json" in older versions */);
        var response = await apiClient.PostAsync(ApiIps.AddTask, requestContent);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Task>(content);
    }

    #endregion
}