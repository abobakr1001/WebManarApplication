using System.ComponentModel.DataAnnotations;

namespace WebManarApplication.Models
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = " email requird")]
        [EmailAddress(ErrorMessage = " email valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = " email requird")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemmberMe { get; set; }
    }
}
