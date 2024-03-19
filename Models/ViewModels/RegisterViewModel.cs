using System.ComponentModel.DataAnnotations;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Please enter a username.")]
		[StringLength(255)]
		[RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Field takes only alphabets and numbers")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Please enter a first name.")]
		[RegularExpression("^[A-Za-z]+$", ErrorMessage = "Field takes only alphabets")]
		[StringLength(255)]
		public string Firstname { get; set; }

		[Required(ErrorMessage = "Please enter a last name.")]
		[StringLength(255)]
		public string Lastname { get; set; }

		[Required(ErrorMessage = "Please enter an email address.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a password.")]
		[DataType(DataType.Password)]
		[Compare("ConfirmPassword")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please confirm your password.")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
	}
}