using System;
using System.Collections.Generic;
using System.Text;

namespace DocuWareEventManager.Core.Models
{
    public class CreateEventDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int UserId { get; set; }
    }
}
