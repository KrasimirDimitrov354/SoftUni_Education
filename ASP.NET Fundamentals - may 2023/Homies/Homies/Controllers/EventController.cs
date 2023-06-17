namespace Homies.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Collections.Generic;

using Homies.Extensions;
using Homies.Service.Interfaces;
using Homies.Web.ViewModels.Event;

[Authorize]
public class EventController : Controller
{
    private readonly IEventService eventService;
    private readonly ITypeService typeService;

    public EventController(IEventService eventService, ITypeService typeService)
    {
        this.eventService = eventService;
        this.typeService = typeService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<DisplayEventViewModel> allEvents = await eventService.DisplayEventsAsync();

        return View(allEvents);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        EventFormViewModel viewModel = new EventFormViewModel()
        {
            Types = await typeService.DisplayAllTypesDropdownSelectAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Types = await typeService.DisplayAllTypesDropdownSelectAsync();
            return View(viewModel);
        }

        bool boardExists = await typeService.ExistsByIdAsync(viewModel.TypeId);
        if (!boardExists)
        {
            ModelState.AddModelError(nameof(viewModel.TypeId), "Invalid event type selected!");
            viewModel.Types = await typeService.DisplayAllTypesDropdownSelectAsync();
            return View(viewModel);
        }

        string eventCreatorId = User.GetId();
        await eventService.AddEventAsync(eventCreatorId, viewModel);

        return RedirectToAction("All", "Event");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        string currentUserId = User.GetId();

        try
        {
            EventFormViewModel eventModifyViewModel = await eventService.GetForModificationAsync(id, currentUserId);
            eventModifyViewModel.Types = await typeService.DisplayAllTypesDropdownSelectAsync();
            return View(eventModifyViewModel);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Event");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EventFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Types = await typeService.DisplayAllTypesDropdownSelectAsync();
            return View(viewModel);
        }

        bool boardExists = await typeService.ExistsByIdAsync(viewModel.TypeId);
        if (!boardExists)
        {
            ModelState.AddModelError(nameof(viewModel.TypeId), "Invalid event type selected!");
            viewModel.Types = await typeService.DisplayAllTypesDropdownSelectAsync();
            return View(viewModel);
        }

        string currentUserId = User.GetId();
        try
        {
            await eventService.EditAsync(id, currentUserId, viewModel);
            return RedirectToAction("All", "Event");
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Event");
        }
    }
}
