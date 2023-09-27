using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SiteECommerce_TP_.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Height(cm)")]
        public float Height { get; set; }

        [Required]
        [Display(Name = "Width(cm)")]
        public float Width { get; set; }

        [Required]
        [Display(Name = "Length(cm)")]
        public float Length { get; set; }
        
        [Required]
        [Display(Name = "Weight(kg)")]
        public float Weight { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Primary Color")]
        public string PrimaryColor { get; set; }

        [Required]
        [Display(Name = "Constructor")]
        public string Constructor { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Picture")]
        public IFormFile Picture { get; set; }
    }
}
