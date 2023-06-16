namespace TaskBoard.App.Controllers;

using Microsoft.AspNetCore.Mvc;

using Extensions;
using Service.Interfaces;
using Web.ViewModels.Task;

using Microsoft.AspNetCore.Authorization;

using static Common.EntityExceptionMessages.Board;
using static Common.EntityExceptionMessages.Task;

[Authorize]
public class TaskController : Controller
{
    private readonly ITaskService taskService;
    private readonly IBoardService boardService;

    public TaskController(ITaskService taskService, IBoardService boardService)
    {
        this.taskService = taskService;
        this.boardService = boardService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaskFormViewModel addTaskViewModel = new TaskFormViewModel()
        {
            Boards = await boardService.AllBoardsDropdownSelectAsync()
        };

        return View(addTaskViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Boards = await boardService.AllBoardsDropdownSelectAsync();
            return View(viewModel);
        }

        bool boardExists = await boardService.ExistsByIdAsync(viewModel.BoardId);
        if (!boardExists)
        {
            ModelState.AddModelError(nameof(viewModel.BoardId), InvalidBoardIdMessage);
            viewModel.Boards = await boardService.AllBoardsDropdownSelectAsync();
            return View(viewModel);
        }

        string taskCreatorId = User.GetId();
        await taskService.AddAsync(taskCreatorId, viewModel);

        string createdTaskId = await taskService.FindIdOfLatestTaskAsync(taskCreatorId);

        return RedirectToAction("Details", "Task", new { id = createdTaskId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        string currentUserId = User.GetId();

        try
        {
            TaskFormViewModel editTaskViewModel = await taskService.GetForModificationAsync(id, currentUserId);
            editTaskViewModel.Boards = await boardService.AllBoardsDropdownSelectAsync();
            return View(editTaskViewModel);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Board");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, TaskFormViewModel editedTask)
    {
        if (!ModelState.IsValid)
        {
            editedTask.Boards = await boardService.AllBoardsDropdownSelectAsync();
            return View(editedTask);
        }

        bool boardExists = await boardService.ExistsByIdAsync(editedTask.BoardId);
        if (!boardExists)
        {
            ModelState.AddModelError(nameof(editedTask.BoardId), InvalidBoardIdMessage);
            editedTask.Boards = await boardService.AllBoardsDropdownSelectAsync();
            return View(editedTask);
        }

        string currentUserId = User.GetId();
        try
        {           
            await taskService.EditAsync(id, currentUserId, editedTask);
            return RedirectToAction("Details", "Task", new { id = id });
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Board");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        string currentUserId = User.GetId();

        try
        {
            TaskFormViewModel deleteTaskViewModel = await taskService.GetForModificationAsync(id, currentUserId);
            deleteTaskViewModel.Boards = await boardService.AllBoardsDropdownSelectAsync();
            return View(deleteTaskViewModel);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Board");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, TaskFormViewModel taskToDelete)
    {
        string currentUserId = User.GetId();

        try
        {
            await taskService.DeleteAsync(id, currentUserId, taskToDelete);           
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, DeletingTaskExceptionMessage);
            return View(taskToDelete);
        }

        return RedirectToAction("All", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        try
        {
            TaskDetailsViewModel taskDetails = await taskService.DisplayTaskDetailsAsync(id);
            return View(taskDetails);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Board");
        }
    }
}
