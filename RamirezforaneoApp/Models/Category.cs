using System.ComponentModel.DataAnnotations;

namespace RamirezforaneoApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
