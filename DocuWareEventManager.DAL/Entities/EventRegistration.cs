using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuWareEventManager.DAL.Entities
{
    [Table("EventRegistrations")]
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
