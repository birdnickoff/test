using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocuWareEventManager.UI.Models
{
    public class CreateEventViewModel : IValidatableObject
    {
        [Display(Name = "Name"), DataType(DataType.Text), StringLength(100), Required]
        public string Name { get; set; }

        [Display(Name = "Descripton"), DataType(DataType.Text), StringLength(300), Required]
        public string Descripton { get; set; }

        [Display(Name = "Location"), DataType(DataType.Text), StringLength(100), Required]
        public string Location { get; set; }

        [Display(Name = "Start Time"), DataType(DataType.DateTime), Required]
        public DateTime StartTime { get; set; }


        [Display(Name = "End Time"), DataType(DataType.DateTime), Required]
        public DateTime EndTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartTime > EndTime)
                yield return new ValidationResult("Invalid dates");
        }
    }
}
