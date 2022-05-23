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

    public async Task<IActionResult> Index(string? searchValue, bool delete = false, int taskId = 0)
    {
        List<Task> tasks;
        if (string.IsNullOrEmpty(searchValue))
        {
            tasks = await ApiCommunicator.GetAllTasks();
        }
        else
        {
            tasks = await ApiCommunicator.GetTasksByName(searchValue);
        }

        ViewBag.delete = delete;
        ViewBag.searchValue = searchValue;
        ViewBag.taskId = taskId;
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

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddPost(Task? task)
    {
        if (task is null) return Problem();
        await ApiCommunicator.AddTask(task);
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Delete(int taskId)
    {
        await ApiCommunicator.DeleteTaskById(taskId);
        return RedirectToAction("Index");
    }
    
    public ActionResult DeleteOverlay(int taskId)
    {
        return PartialView("DeleteOverlay", taskId);        
    }
}