using System.ComponentModel.DataAnnotations;

namespace WebManarApplication.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage ="first name requird")]
        public string FName { get; set; }
        [Required(ErrorMessage = "last name requird")]

        public string LName { get; set; }
        [Required(ErrorMessage = " email requird")]
        [EmailAddress(ErrorMessage = " email valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = " email requird")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = " email requird")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="confirm password not match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }


    }
}
