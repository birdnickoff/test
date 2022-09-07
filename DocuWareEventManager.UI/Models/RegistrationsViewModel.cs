using DocuWareEventManager.Core.Models;
using System.Collections.Generic;

namespace DocuWareEventManager.UI.Models
{
    public class RegistrationsViewModel
    {
        public IEnumerable<EventRegistration> Registrations { get; set; }


        public Event Event { get; set; }
    }
}
