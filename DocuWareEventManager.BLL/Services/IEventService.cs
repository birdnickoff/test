using DocuWareEventManager.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocuWareEventManager.BLL.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Core.Models.Event>> GetEvents();

        Task<IEnumerable<Core.Models.Event>> GetEvents(int userId);

        Task CreateEvent(CreateEventDto newEvent);

        Task CreateEventRegistration(CreateEventRegistrationDto newRegistration);

        Task<Event> GetEvent(int id);

        Task<IEnumerable<EventRegistration>> GetEventRegistrations(int eventId);

    }
}
