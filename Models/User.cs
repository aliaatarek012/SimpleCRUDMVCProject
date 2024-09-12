using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIFinalProject.Models
{
    public class User
    {
        public int UserId { get; set; }


        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "First Name is Required.")]
        [DisplayName("User First Name")]
        public string FirstName { get; set; }


        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Last Name is Required.")]
        [DisplayName("User Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("User Email")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
