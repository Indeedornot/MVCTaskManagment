using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Client.Models;
using Task = Client.Models.Task;

namespace Client.Controllers;

public class HomeController : Controller
{
    #region Default
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
    #endregion
    public async Task<IActionResult> Index()
    {
        var tasks = await ApiCommunicator.GetAllTasks();
        return View(model: tasks);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int taskId)

    {
        var task = await ApiCommunicator.GetTaskById(taskId);
        if (task is null) return Problem();
        return View(model: task);
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePost(Task? task)
    {
        if (task is null) return Problem();
        await ApiCommunicator.UpdateTaskById(task.Id, task);
        return RedirectToAction("Index");
    }
}