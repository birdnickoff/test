using System.ComponentModel.DataAnnotations;

namespace DocuWareEventManager.UI.Models
{
    public class CreateEventRegistrationViewModel 
    {
        [Display(Name = "Name"), DataType(DataType.Text), StringLength(100), Required]
        public string Name { get; set; }

        [Display(Name = "Phone"), DataType(DataType.PhoneNumber), StringLength(100), Required]
        public string Phone { get; set; }

        [Display(Name = "Email"), DataType(DataType.EmailAddress), StringLength(100), Required]
        public string Email { get; set; }

    }
}
