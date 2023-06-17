namespace Homies.Service.Interfaces;

using Homies.Web.ViewModels.Event;

public interface IEventService
{
    Task<IEnumerable<DisplayEventViewModel>> DisplayEventsAsync();

    Task AddEventAsync(string userId, EventFormViewModel viewModel);

    Task<EventFormViewModel> GetForModificationAsync(int eventId, string userId);

    Task EditAsync(int eventId, string userId, EventFormViewModel viewModel);
}
