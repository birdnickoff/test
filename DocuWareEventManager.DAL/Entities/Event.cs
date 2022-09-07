using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuWareEventManager.DAL.Entities
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }
    }
}
