using DocuWareEventManager.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocuWareEventManager.DAL.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetEvent(int id);

        Task<IEnumerable<Event>> GetEvents();

        Task<IEnumerable<Event>> GetEvents(int userId);

        Task CreateEvent(CreateEventDto newEvent);

        Task CreateEventRegistration(CreateEventRegistrationDto newRegistration);

        Task<IEnumerable<EventRegistration>> GetEventRegistrations(int eventId);

    }
}
