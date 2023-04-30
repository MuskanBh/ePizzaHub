using System.ComponentModel.DataAnnotations;

namespace ePizzaHub.UI.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]


        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string PhoneNumber { get; set; }

    }
}
