namespace DocuWareEventManager.Core.Models
{
    public class CreateEventRegistrationDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int EventId { get; set; }
    }
}
