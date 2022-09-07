using DocuWareEventManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DocuWareEventManager.DAL.Repositories.Impl
{
    public class EventRepository : IEventRepository
    {
        private readonly DocuWareEventManagerContext _context;

        public EventRepository(DocuWareEventManagerContext context)
        {
            _context = context;
        }

        public async Task CreateEvent(CreateEventDto newEvent)
        {
            var newEventDb = new Entities.Event
            {
                CreateDate = DateTime.UtcNow,
                Description = newEvent.Description,
                EndTime = newEvent.EndTime,
                Location = newEvent.Location,
                Name = newEvent.Name,
                StartTime = newEvent.StartTime,
                UserId = newEvent.UserId
            };

            await _context.Events.AddAsync(newEventDb);
            await _context.SaveChangesAsync();
        }

        public async Task CreateEventRegistration(CreateEventRegistrationDto newRegistration)
        {
            var newEventRegistrationDb = new Entities.EventRegistration
            {
                CreateDate = DateTime.UtcNow,
                Name = newRegistration.Name,
                Phone = newRegistration.Phone,
                Email = newRegistration.Email,
                EventId = newRegistration.EventId,
            };

            await _context.EventRegistrations.AddAsync(newEventRegistrationDb);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEvent(int id)
        {
            var dbItem = await _context.Events.AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
            return MapEvent(dbItem);
        }

        public async Task<IEnumerable<EventRegistration>> GetEventRegistrations(int eventId)
        {
            return await _context.EventRegistrations.AsNoTracking()
                .Where(i => i.EventId == eventId)
                .OrderByDescending(e => e.CreateDate)
                .Select(i => new EventRegistration
                {
                    CreateDate = i.CreateDate,
                    Email = i.Email,
                    EventId = i.EventId,
                    Id = i.Id,
                    Name = i.Name,
                    Phone = i.Phone
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return (await _context.Events.AsNoTracking()
                .OrderBy(e => e.CreateDate)
                .ToListAsync()).Select(MapEvent).ToList();
        }

        public async Task<IEnumerable<Core.Models.Event>> GetEvents(int userId)
        {
            return (await _context.Events.AsNoTracking()
                .Where(i => i.UserId == userId)
                .OrderBy(e => e.CreateDate)
                .ToListAsync()).Select(MapEvent).ToList();
        }

        private Event MapEvent(Entities.Event dbEvent) 
        {
            if(dbEvent == null)
            {
                return null;
            }

            return new Event
            {
                Id = dbEvent.Id,
                Description = dbEvent.Description,
                Name = dbEvent.Name,
                StartDate = dbEvent.StartTime,
                EndDate = dbEvent.EndTime,
                Location = dbEvent.Location,
                UserId = dbEvent.UserId
            };
        }
    }
}
