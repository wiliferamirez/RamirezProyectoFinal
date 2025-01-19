using System.ComponentModel.DataAnnotations;

namespace RamirezforaneoAppAPI.Model
{
    public class CategoryAPI
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
