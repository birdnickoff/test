
using DocuWareEventManager.Core.Models;
using System.Collections.Generic;

namespace DocuWareEventManager.UI.Models
{
    public class EventListViewModel
    {
        public IEnumerable<Event> Items { get; set; }
    }
}
