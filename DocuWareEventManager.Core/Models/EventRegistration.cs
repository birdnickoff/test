using System;

namespace DocuWareEventManager.Core.Models
{
    public class EventRegistration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int EventId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
