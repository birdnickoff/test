﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DocuWareEventManager.Core.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
    }
}
