using DocuWareEventManager.BLL.Services;
using DocuWareEventManager.Core.Models;
using DocuWareEventManager.UI.Extensions;
using DocuWareEventManager.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DocuWareEventManager.UI.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILogger<HomeController> _logger;

        public EventController(IEventService eventService,
            ILogger<HomeController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }


        [HttpGet("MyEvents")]
        public async Task<IActionResult> MyEvents()
        {
            var events = await _eventService.GetEvents(User.GetId());
            var vm = new EventListViewModel
            {
                Items = events
            };

            return View(vm);
        }


        [HttpGet("EventRegistrations/{eventId}")]
        public async Task<IActionResult> EventRegistrations(int eventId)
        {
            var eventDetails = await _eventService.GetEvent(eventId);
            if (eventDetails == null)
            {
                return NotFound();
            }

            if (eventDetails.UserId != User.GetId())
            {
                return Forbid();
            }

            var registrations = await _eventService.GetEventRegistrations(eventId);
            var viewModel = new RegistrationsViewModel
            {
                Registrations = registrations,
                Event = eventDetails
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createEventRequest = new CreateEventDto
                    {
                        UserId = User.GetId(),
                        Name = model.Name,
                        Description = model.Descripton,
                        EndTime = model.EndTime,
                        Location = model.Location,
                        StartTime = model.StartTime
                    };

                    await _eventService.CreateEvent(createEventRequest);
                    return RedirectToAction("MyEvents");
                }

                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during event creation");
                ModelState.AddModelError("", "Unable to create event");
            }

            return View();
        }

        [HttpGet("RegisterToEvent/{eventId}")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterToEvent(int eventId)
        {
            var eventDetails = await _eventService.GetEvent(eventId);
            if (eventDetails == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost("RegisterToEvent/{eventId}")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterToEvent(CreateEventRegistrationViewModel model, int eventId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createEventRRequest = new CreateEventRegistrationDto
                    {
                        Name = model.Name,
                        Phone = model.Phone,
                        Email = model.Email,
                        EventId = eventId
                    };

                    await _eventService.CreateEventRegistration(createEventRRequest);
                    TempData["Message"] = "Successfully registered";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during registration to event");
                ModelState.AddModelError("", "Unable to register");
            }

            return View();
        }
    }
}
