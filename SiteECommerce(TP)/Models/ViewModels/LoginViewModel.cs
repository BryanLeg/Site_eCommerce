using System.ComponentModel.DataAnnotations;

namespace SiteECommerce_TP_.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
