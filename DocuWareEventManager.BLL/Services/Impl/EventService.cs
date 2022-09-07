using DocuWareEventManager.Core.Models;
using DocuWareEventManager.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocuWareEventManager.BLL.Services.Impl
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateEvent(CreateEventDto newEvent)
        {
            await _repository.CreateEvent(newEvent);
        }

        public async Task CreateEventRegistration(CreateEventRegistrationDto newRegistration)
        {
            await _repository.CreateEventRegistration(newRegistration);
        }

        public Task<Event> GetEvent(int id)
        {
            return _repository.GetEvent(id);
        }

        public async Task<IEnumerable<EventRegistration>> GetEventRegistrations(int eventId)
        {
            return await _repository.GetEventRegistrations(eventId);
        }

        public Task<IEnumerable<Event>> GetEvents()
        {
            return _repository.GetEvents();
        }

        public Task<IEnumerable<Event>> GetEvents(int userId)
        {
            return _repository.GetEvents(userId);
        }
    }
}
