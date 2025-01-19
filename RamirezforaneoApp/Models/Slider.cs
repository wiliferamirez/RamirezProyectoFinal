using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RamirezforaneoApp.Models
{
    public class Slider
    {
        [Key]
        public int SliderImageId { get; set; }
        [Required(ErrorMessage ="Please select an image to upload")]
        [DataType(DataType.ImageUrl)]
        public string SliderUrlImage { get; set; }
        [ValidateNever]
        public Boolean ImageStatus { get; set; } = true;
    }
}
