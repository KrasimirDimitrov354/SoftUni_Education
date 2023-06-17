namespace Homies.Service;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using Homies.Data;
using Homies.Data.Models;
using Homies.Service.Interfaces;
using Homies.Web.ViewModels.Event;

public class EventService : IEventService
{
    private readonly HomiesDbContext dbContext;

    public EventService(HomiesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddEventAsync(string userId, EventFormViewModel viewModel)
    {
        Event newEvent = new Event()
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            OrganiserId = userId,
            CreatedOn = DateTime.UtcNow,
            Start = DateTime.Parse(viewModel.Start),
            End = DateTime.Parse(viewModel.End),
            TypeId = viewModel.TypeId,
        };

        await dbContext.Events.AddAsync(newEvent);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<DisplayEventViewModel>> DisplayEventsAsync()
    {
        IEnumerable<DisplayEventViewModel> allEvents = await dbContext.Events
            .Select(e => new DisplayEventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start.ToString("g"),
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName
            })
            .ToArrayAsync();

        return allEvents;
    }

    public async Task<EventFormViewModel> GetForModificationAsync(int eventId, string userId)
    {
        EventFormViewModel eventToModify = await dbContext.Events
            .Where(e => e.OrganiserId == userId && e.Id == eventId)
            .Select(e => new EventFormViewModel
            {
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString("g"),
                End = e.End.ToString("g"),
                TypeId= e.TypeId
            })
            .FirstAsync();

        return eventToModify;
    }

    public async Task EditAsync(int eventId, string userId, EventFormViewModel viewModel)
    {
        Event eventToModify = await dbContext.Events
            .FirstAsync(e => e.OrganiserId == userId && e.Id == eventId);

        eventToModify.Name = viewModel.Name;
        eventToModify.Description = viewModel.Description;
        eventToModify.Start = DateTime.Parse(viewModel.Start);
        eventToModify.End = DateTime.Parse(viewModel.End);
        eventToModify.TypeId = viewModel.TypeId;

        await dbContext.SaveChangesAsync();
    }
}
