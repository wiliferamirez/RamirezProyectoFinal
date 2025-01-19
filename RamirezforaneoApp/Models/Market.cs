using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamirezforaneoApp.Models
{
    public class Market
    {
        [Key]
        public int MarketItemId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        [ValidateNever]
        public string ItemSellerId { get; set; }

        [ValidateNever]
        public User ItemSeller { get; set; }

        [Required(ErrorMessage = "Please enter the name of the Item")]
        [StringLength(100, ErrorMessage = "Item Name cannot exceed 100 characters")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please enter the description of the item")]
        [StringLength(600, ErrorMessage = "Item description cannot exceed 600 characters")]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [Display(Name = "Image URL")]
        [ValidateNever]
        public string ItemImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter the price of the item")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal ItemPrice { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category Category { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "Creation Date")]
        [ValidateNever]
        public DateTime ItemCreationDate { get; set; } = DateTime.Now;

    }
}
